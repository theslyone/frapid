using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using static System.String;
using System.Globalization;
using Amazon.S3;
using Amazon;
using Amazon.S3.IO;
using System;

namespace Frapid.Configuration
{
    public class Storage
    {
        private const string amazon = "amazons3";
        private const string local = "local";
        
        private static string FileStorageConfig = System.Configuration.ConfigurationManager.AppSettings["FileStorage"];

        private static IStorage Store;

        private static IStorage GetStorage()
        {
            if (Store != null) return Store;

            switch (FileStorageConfig.ToLower())
            {
                case amazon:
                    Store = new AmazonStorage();
                    break;
                case local:
                default:
                    Store = new LocalStorage();
                    break;               
            }
            return Store;
        }

        public static string MapPath(string filePath, params object[] args)
        {
            return GetStorage().MapPath(filePath, args);
        }

        public static bool FileExists(string path)
        {
            return GetStorage().FileExists(path);
        }

        public static void CopyDirectory(string origin, string destination)
        {
            GetStorage().CopyDirectory(origin, destination);
        }

        public static void DeleteFile(string path)
        {
            GetStorage().DeleteFile(path);
        }

        public static void CreateFile(string path, Stream fileStream)
        {
            GetStorage().CreateFile(path, fileStream);
        }

        public static void WriteAllText(string path, string contents, UTF8Encoding uTF8Encoding)
        {
            GetStorage().WriteAllText(path, contents, uTF8Encoding);
        }
        
        public static string ReadAllText(string path, Encoding encoding)
        {
            return GetStorage().ReadAllText(path, encoding);
        }

        public static List<string> GetFiles(string path, string[] format)
        {
            return GetStorage().GetFiles(path, format);
        }

        public static List<string> GetFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return GetStorage().GetFiles(path, searchPattern, searchOption);
        }

        public static string GetLocalFilePath(string path, bool returnAsRelativePath = false)
        {
            return GetStorage().GetLocalFilePath(path, returnAsRelativePath);
        }

        public static string GetLocalDirectoryPath(string path)
        {
            return GetStorage().GetLocalDirectoryPath(path);
        }

        public static bool DirectoryExists(string path)
        {
            return GetStorage().DirectoryExists(path);
        }

        public static void DeleteDirectory(string path, bool recursive)
        {
            GetStorage().DeleteDirectory(path, recursive);
        }

        public static void CreateDirectory(string path)
        {
            GetStorage().CreateDirectory(path);
        }

        public static List<string> GetDirectories(string path)
        {
            return GetStorage().GetDirectories(path);
        }

        public static List<string> GetDirectories(string path, string searchPattern)
        {
            return GetStorage().GetDirectories(path, searchPattern);
        }
    }

    public static class StorageExtensions
    {
        public static Stream ToStream(this string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static string TrimLastCharacter(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            else
            {
                return str.TrimEnd(str[str.Length - 1]);
            }
        }
    }
}
