using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace NovelEditor
{
    class MainDocMgr
    {
        public static FlowDocument ContentToDocument(byte[] Content)
        {
            FlowDocument doc = new FlowDocument();
            TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
            if (Content == null || Content.Length == 0 || Content[0] == 0) { return null; }
            using (MemoryStream stream = new MemoryStream(Content))
            {
                range.Load(stream, "Xaml");
            }
            return doc;
        }

        public static string DocumentToText(FlowDocument doc)
        {
            TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
            return range.Text;
        }
        public static void SetDefaultDoc(byte[] Content)
        {
            FlowDocument doc = new FlowDocument();
            TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
            using (MemoryStream stream = new MemoryStream(Content))
            {
                range.Save(stream, "Xaml");
            }
        }
        public static void SaveDocmentToMemory(RichTextBox box, byte[] Content)
        {
            FlowDocument doc = box.Document;
            TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
            using (MemoryStream stream = new MemoryStream(Content))
            {
                range.Save(stream, "Xaml");
            }
        }

        public static void ReadDocFromMemory(RichTextBox box, byte[] Content)
        {
            try
            {
                FlowDocument doc = box.Document;
                TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
                //没有任何字符的asc是0
                if(Content == null || Content.Length == 0 || Content[0] == 0) { return; }
                using (MemoryStream stream = new MemoryStream(Content))
                {
                    range.Load(stream, "Xaml");
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
