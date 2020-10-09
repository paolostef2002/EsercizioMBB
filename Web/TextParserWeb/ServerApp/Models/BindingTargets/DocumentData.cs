using System;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models.BindingTargets
{
    public class DocumentData
    {
        [Required]
        public string Filename { get => Document.Filename; set => Document.Filename = value; }

        [Required]
        public string Content { get => Document.Content; set => Document.Content = value; }

        [Required]
        public string OriginPath { get => Document.OriginPath; set => Document.OriginPath = value; }

        [Required]
        public DateTime ImportDate { get => Document.ImportDate; set => Document.ImportDate = value; }

        public Document Document { get; set; } = new Document();
    }
}