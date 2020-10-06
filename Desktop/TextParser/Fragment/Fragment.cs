using System;
using System.IO;
using System.Text;

namespace TextParser

{
    public class Fragment
    {
        #region Variabili interne


        #endregion


        #region Costruttori
        public Fragment()
        {
        }

        public Fragment(string rootPath, string filename, int row, string identifier, string text)
        {
            RootPath = rootPath;
            Filename = filename;
            Row = row;
            Identifier = identifier;
            Text = text;
        }

        #endregion

        #region Proprietà

        public string RootPath { get; set; } = String.Empty;
        public string Filename { get; set; } = String.Empty;
        public int Row { get; set; } = 0;
        public string Identifier { get; set; } = String.Empty;
        public string Text { get; set; } = String.Empty;

        #endregion

        #region Metodi

        public bool Save(string DestinationFolder, ref string error)
        {
            bool res = false;

            if (!Directory.Exists(Path.Combine(DestinationFolder, Identifier)))
                Directory.CreateDirectory(Path.Combine(DestinationFolder, Identifier));

            if (!File.Exists(Path.Combine(DestinationFolder, Identifier, Filename)))
            {
                try
                {
                    using (FileStream fs = File.Create(Path.Combine(DestinationFolder, Identifier, Filename)))
                    {
                        Byte[] txt = new UTF8Encoding(true).GetBytes(Text);
                        fs.Write(txt, 0, txt.Length);
                    }
                    res = true;
                }
                catch (System.Exception ex)
                {
                    error = ex.Message;
                    res = false;
                }
            }
            else
            {
                error = "File " + Path.Combine(DestinationFolder, Identifier, Filename) + " esistente.";
                res = false;
            }

            return res;
        }
        #endregion
    }
}
