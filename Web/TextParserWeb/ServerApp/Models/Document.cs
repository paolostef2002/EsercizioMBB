using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServerApp.Models
{
    public class Document
    {
        public long DocumentId { get; set; }

        public string OriginPath { get; set; }

        public string Filename { get; set; }

        public string Content { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ImportDate { get; set; }

        public List<Fragment> Fragments { get; set; } //navigation property -> access to related data (multiple Fragment objects)
    }
}