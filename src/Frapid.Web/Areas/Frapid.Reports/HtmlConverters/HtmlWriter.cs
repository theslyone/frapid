using System.IO;
using System.Text;
using Frapid.Configuration;

namespace Frapid.Reports.HtmlConverters
{
    public static class HtmlWriter
    {
        public static void WriteHtml(string path, string html)
        {
            string contents = PathMapper.MapPath(path);

            if (contents != null)
            {
                File.WriteAllText(contents, html, new UTF8Encoding(false));
            }
        }
    }
}