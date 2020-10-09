namespace ServerApp.Models
{
    public class Fragment
    {
        public long FragmentId { get; set; }
        public int RowIndex { get; set; }
        public string Identifier { get; set; }
        public string Text { get; set; }
        public string DestPath { get; set; }
        public string Filename { get; set; }
        public Document Document { get; set; }  //navigation property -> access to related data (one Document object)
    }
}
