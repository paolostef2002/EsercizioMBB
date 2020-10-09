using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using ServerApp.Models.BindingTargets;
using Microsoft.AspNetCore.JsonPatch;
using System.Text.Json;
using System.Reflection;
using System.ComponentModel;
using System;

namespace ServerApp.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentValuesController : Controller
    {
        private DataContext context;
        
        public DocumentValuesController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public Document GetDocument(long id)
        {
            Document result = context.Documents
                .Include(p => p.Fragments)
                .FirstOrDefault(p => p.DocumentId == id);
            
            if (result != null)
            {
                if (result.Fragments != null)
                {
                    foreach (Fragment r in result.Fragments)
                    {
                        r.Document = null; //x bloccare i riferimenti circolari
                    }
                }
            }
            return result;
        }

        [HttpGet]
        public IEnumerable<Document> GetDocuments(DateTime? importdate, string search, bool related = false)
        {
            IQueryable<Document> query = context.Documents;
            
            //filtro per categoria (ricerca testo)
            if (importdate.HasValue)
            {
                query = query.Where(p => p.ImportDate == importdate.Value);
            }

            //filtro per descrizione prodotto (ricerca testo)
            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(p => p.Filename.ToLower().Contains(searchLower));
            }

            if (related)
            {
                //inserisce nella query i dati collegati del fornitore e dei rating
                query = query.Include(p => p.Fragments);

                List<Document> data = query.ToList();
                data.ForEach(p =>
                {
                    if (p.Fragments != null)
                    {
                        p.Fragments.ForEach(r => r.Document = null); //evita loop infinito
                    }
                });
                return data;
            }
            else
            {
                return query;
            }
        }

        [HttpPost]
        public IActionResult CreateDocument([FromBody] DocumentData pdata)
        {
            if (ModelState.IsValid)
            {
                Document p = pdata.Document;
                context.Add(p);
                context.SaveChanges();
                return Ok(p.DocumentId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceDocument(long id, [FromBody] DocumentData pdata)
        {
            if (ModelState.IsValid)
            {
                Document p = pdata.Document;
                p.DocumentId = id;
                context.Update(p);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateDocument(long id, [FromBody] JsonPatchDocument<DocumentData> patch)
        {
            Document document = context.Documents.First(p => p.DocumentId == id);

            DocumentData pdata = new DocumentData { Document = document };
            
            patch.ApplyTo(pdata, ModelState);
            
            if (ModelState.IsValid && TryValidateModel(pdata))
            {
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteDocument(long id)
        {
            context.Documents.Remove(new Document { DocumentId = id });
            context.SaveChanges();
        }

    }
}