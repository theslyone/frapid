using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Configuration
{
    public interface IStorage
    {
        string MapPath(string filePath, params object[] args);

        bool FileExists(string path);
        void DeleteFile(string path);
        void CreateFile(string path, Stream fileStream);
        void WriteAllText(string path, string contents, UTF8Encoding uTF8Encoding);
        string ReadAllText(string path, Encoding encoding);
        List<string> GetFiles(string path, string[] format);
        List<string> GetFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly);
        string GetLocalFilePath(string path, bool returnAsRelativePath);

        bool DirectoryExists(string path);
        void DeleteDirectory(string path, bool recursive);
        void CreateDirectory(string path);
        List<string> GetDirectories(string path);
        List<string> GetDirectories(string path, string searchPattern);
        void CopyDirectory(string origin, string destination);
        string GetLocalDirectoryPath(string path);
    }
}
