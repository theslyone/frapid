using System;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Frapid.Configuration;

namespace Frapid.Reports.HtmlConverters
{
    public class ToOpenOfficeWord : IExportTo
    {
        public bool Enabled { get; set; } = true;
        public string Extension => "docx";

        public string Export(string tenant, string html, string destination = "")
        {
            string documentName = Guid.NewGuid().ToString();

            if (string.IsNullOrWhiteSpace(destination))
            {
                destination = $"/Tenants/{tenant}/Documents/{documentName}.docx";
            }

            using (var doc = WordprocessingDocument.Create(PathMapper.MapPath(destination), WordprocessingDocumentType.Document))
            {
                string id = "html2doc";
                
                var main = doc.AddMainDocumentPart();

                main.Document = new Document();
                main.Document.AppendChild(new Body());

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(html));

                var importPart = main.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.Html, id);

                // Feed HTML data into format import part (chunk).
                importPart.FeedData(ms);
                var altChunk = new AltChunk {Id = id};

                // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                main.Document.Body.Append(altChunk);

                doc.Save();
            }

            //HtmlWriter.WriteHtml(destination, html);
            return destination;
        }
    }
}