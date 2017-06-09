using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using static System.String;
using System.Globalization;
using System;

namespace Frapid.Configuration
{
    public class LocalStorage : IStorage
    {        
        public string MapPath(string filePath, params object[] args)
        {
            string Path = Format(CultureInfo.InvariantCulture, filePath, args);
            string fileStorage = HostingEnvironment.MapPath($"{Path}");
            return fileStorage;// != null && !DirectoryExists(fileStorage) ? Empty : fileStorage;
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public void CreateFile(string path, Stream fileStream)
        {
            using (var localStream = File.Create(path))
            {
                fileStream.CopyTo(localStream);
            }
        }

        public void WriteAllText(string path, string contents, UTF8Encoding uTF8Encoding)
        {
            File.WriteAllText(path, contents, uTF8Encoding);
        }

        public string ReadAllText(string path, Encoding encoding)
        {
            return File.ReadAllText(path, encoding);
        }

        public List<string> GetFiles(string path, string[] format)
        {
            var directory = new DirectoryInfo(path);
            var files = directory.EnumerateFiles().Where(f => format.Contains(f.Extension.ToLower()));
            return files.Select(file => file.Name).ToList();
        }

        public List<string> GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            var directory = new DirectoryInfo(path);
            var files = directory.GetFiles(searchPattern, searchOption);
            return files.Select(file => file.Name).ToList();
        }

        public string GetLocalFilePath(string path, bool returnAsRelativePath)
        {
            return path;
        }

        public string GetLocalDirectoryPath(string path)
        {
            return path;
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void DeleteDirectory(string path, bool recursive)
        {
            Directory.Delete(path, recursive);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public List<string> GetDirectories(string path)
        {
            var directories = Directory.GetDirectories(path);
            return directories.Select(directory => new DirectoryInfo(directory).Name).ToList();
        }

        public List<string> GetDirectories(string path, string searchPattern)
        {
            var areaRoot = new DirectoryInfo(path);
            var directories = areaRoot.GetDirectories().Where(x => x.GetDirectories(searchPattern, SearchOption.AllDirectories).Any());
            return directories.Select(directory => directory.Name).ToList();
        }

        public void CopyDirectory(string origin, string destination)
        {
            var source = new DirectoryInfo(origin);
            var target = new DirectoryInfo(destination);
            CopyFilesRecursively(source, target);
        }

        private void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target, bool overwrite = true)
        {
            foreach (var dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name), overwrite);
            foreach (var file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name), overwrite);
        }
    }
}
