using System.IO;
using System.Linq;

namespace Frapid.Mailgun
{
    internal static class FileHelper
    {
        internal static void DeleteFiles(params string[] files)
        {
            foreach (string file in files.Where(file => !string.IsNullOrWhiteSpace(file)).Where(File.Exists))
            {
                File.Delete(file);
            }
        }
    }
}