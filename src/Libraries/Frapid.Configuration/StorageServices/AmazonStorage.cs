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
using System.Runtime.InteropServices;

namespace Frapid.Configuration
{
    public class AmazonStorage : IStorage
    {        
        private readonly string awsBucketName = System.Configuration.ConfigurationManager.AppSettings["AWSBucketName"];
        private readonly string awsRegion = System.Configuration.ConfigurationManager.AppSettings["AWSRegion"];
        private readonly string awsAccessKey = System.Configuration.ConfigurationManager.AppSettings["AWSAccessKey"];
        private readonly string awsSecretKey = System.Configuration.ConfigurationManager.AppSettings["AWSSecretKey"];

        public string MapPath(string filePath, params object[] args)
        {
            string path = Format(CultureInfo.InvariantCulture, filePath, args);

            path = SanitizePath(path);
            string url = $"https://s3-{awsRegion}.amazonaws.com/{awsBucketName}/{path}";
            //if (url.EndsWith("/")) url = url.TrimLastCharacter();
            return url;
        }

        public bool FileExists(string path)
        {
            path = SanitizePath(path);
            S3FileInfo s3FileInfo = new S3FileInfo(GetAmazonS3Client(), awsBucketName, path);
            return s3FileInfo.Exists;
        }

        public void DeleteFile(string path)
        {
            path = SanitizePath(path);
            S3FileInfo fileToDelete = new S3FileInfo(GetAmazonS3Client(), awsBucketName, path);
            fileToDelete.Delete();
        }

        public void CreateFile(string path, Stream fileStream)
        {
            path = SanitizePath(path);
            S3FileInfo s3FileInfo = new S3FileInfo(GetAmazonS3Client(), awsBucketName, path);
            using (Stream s3Stream = s3FileInfo.Create())
            {
                fileStream.CopyTo(s3Stream);
            }
        }

        public void WriteAllText(string path, string contents, UTF8Encoding uTF8Encoding)
        {
            path = SanitizePath(path);
            S3FileInfo s3FileInfo = new S3FileInfo(GetAmazonS3Client(), awsBucketName, path);
            using (Stream s3Stream = s3FileInfo.Create())
            {
                (new MemoryStream(Encoding.UTF8.GetBytes(contents ?? ""))).CopyTo(s3Stream);
                //contents.ToStream().CopyTo(s3Stream);
            }
        }

        public string ReadAllText(string path, Encoding encoding)
        {
            path = SanitizePath(path);
            S3FileInfo s3FileInfo = new S3FileInfo(GetAmazonS3Client(), awsBucketName, path);
            using (var stream = s3FileInfo.OpenText())
            {
                return stream.ReadToEnd();
            }
        }
        public List<string> GetFiles(string path, string[] format)
        {
            path = SanitizePath(path).Replace("/", "\\");
            S3DirectoryInfo s3DirectoryInfo;
            if (IsNullOrWhiteSpace(path)) s3DirectoryInfo = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName);
            else s3DirectoryInfo = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName, path);
            //var s3Files = s3DirectoryInfo.EnumerateFiles().Where(f => format.Contains(f.Extension.ToLower())).ToList();
            var s3Files = s3DirectoryInfo.GetFiles().ToList();
            var filteredFiles = s3Files.Where(f => format.Contains(f.Extension.ToLower())).ToList();
            return s3Files.Select(file => SanitizePath(file.Name)).ToList();
        }

        public List<string> GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            path = SanitizePath(path).Replace("/", "\\");
            S3DirectoryInfo s3DirectoryInfo;
            if(string.IsNullOrWhiteSpace(path)) s3DirectoryInfo = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName);
            else s3DirectoryInfo = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName, path);
            var s3Files = s3DirectoryInfo.GetFiles(searchPattern, searchOption);
            return s3Files.Select(file => SanitizePath(file.FullName)).ToList();
        }

        public string GetLocalFilePath(string path, bool returnAsRelativePath)
        {
            path = SanitizePath(path);

            var fileDirectory = Path.GetDirectoryName(HostingEnvironment.MapPath($"~/{path}"));
            if (!Directory.Exists(fileDirectory)) Directory.CreateDirectory(fileDirectory);

            var fileName = Path.GetFileName(path);
            string relativeFilePath = Path.Combine("~/", path);
            string absoluteFilePath = Path.Combine(fileDirectory, fileName);

            if (File.Exists(absoluteFilePath) && File.GetLastWriteTime(absoluteFilePath) < DateTime.Now.AddMinutes(10))
            {

            }
            else
            {
                try
                {
                    File.Delete(absoluteFilePath);                    
                }
                catch (IOException)
                {
                    //IO exception, file probably locked and in use.
                }
                finally
                {
                    S3FileInfo s3FileInfo = new S3FileInfo(GetAmazonS3Client(), awsBucketName, path);
                    if (s3FileInfo.Exists)
                    {
                        if (!IsFileLocked(absoluteFilePath))
                            s3FileInfo.CopyToLocal(absoluteFilePath, true);
                    }
                }
            }
            return returnAsRelativePath ? relativeFilePath: absoluteFilePath;
        }

        public bool DirectoryExists(string path)
        {
            path = SanitizePath(path).Replace("/", "\\");
            S3DirectoryInfo s3DirectoryInfo = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName, path);
            return s3DirectoryInfo.Exists;
        }

        public void DeleteDirectory(string path, bool recursive)
        {
            path = SanitizePath(path).Replace("/", "\\");
            S3DirectoryInfo directoryToDelete = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName, path);
            directoryToDelete.Delete(true); // true will delete recursively in folder inside
        }

        public void CreateDirectory(string path)
        {
            path = SanitizePath(path).Replace("/", "\\");
            S3DirectoryInfo s3DirectoryInfo = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName, path);
            s3DirectoryInfo.Create();
        }

        public List<string> GetDirectories(string path)
        {
            path = SanitizePath(path).Replace("/", "\\");
            S3DirectoryInfo s3DirectoryInfo = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName, path);
            return s3DirectoryInfo.GetDirectories().Select(directory => directory.Name).ToList();
        }

        public List<string> GetDirectories(string path, string searchPattern)
        {
            path = SanitizePath(path).Replace("/", "\\");
            S3DirectoryInfo s3DirectoryInfo = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName, path);
            return s3DirectoryInfo.GetDirectories(searchPattern, SearchOption.AllDirectories).Select(directory => directory.Name).ToList();
        }
        
        public void CopyDirectory(string origin, string destination)
        {
            origin = SanitizePath(origin).Replace("/", "\\");
            destination = SanitizePath(destination).Replace("/", "\\");
            var source = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName, origin);
            var target = new S3DirectoryInfo(GetAmazonS3Client(), awsBucketName, destination);
            if (!target.Exists) target.Create();
            CopyFilesRecursively(source, target);
        }

        public string GetLocalDirectoryPath(string path)
        {
            path = SanitizePath(path);
            var directory = HostingEnvironment.MapPath(path);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return Path.Combine("~/", path);
        }

        private AmazonS3Client GetAmazonS3Client()
        {
            AmazonS3Config cfg = new AmazonS3Config();
            switch (awsRegion)
            {
                case "eu-central-1":
                    cfg.RegionEndpoint = RegionEndpoint.EUCentral1;
                    break;
                case "eu-west-1":
                    cfg.RegionEndpoint = RegionEndpoint.EUWest1;
                    break;
                case "eu-west-2":
                    cfg.RegionEndpoint = RegionEndpoint.EUWest2;
                    break;
                case "us-west-1":
                    cfg.RegionEndpoint = RegionEndpoint.USWest1;
                    break;
                case "us-west-2":
                    cfg.RegionEndpoint = RegionEndpoint.USWest2;
                    break;
                default:
                    cfg.RegionEndpoint = RegionEndpoint.EUCentral1;
                    break;
            }
            AmazonS3Client s3Client = new AmazonS3Client(awsAccessKey, awsSecretKey, cfg);
            return s3Client;
        }


        private void CopyFilesRecursively(S3DirectoryInfo source, S3DirectoryInfo target, bool overwrite = true)
        {
            foreach (var dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name), overwrite);
            foreach (var file in source.GetFiles())
            {
                //var toKey = SanitizePath(file.FullName);
                var toPath = SanitizePath(target.FullName);
                var key = Path.Combine(toPath, file.Name);
                file.CopyTo(awsBucketName, key, overwrite);
            }            
        }

        private string SanitizePath(string path)
        {
            if (path.StartsWith("~/")) path = path.Remove(0, 2);
            if (path.StartsWith("/")) path = path.Remove(0, 1);

            if (path.ToLower().Contains($"/{awsBucketName}/"))
                path = path.Split(new string[] { $"/{awsBucketName}/" }, StringSplitOptions.None)[1];

            if (path.ToLower().Contains($"{awsBucketName}:\\"))
                path = path.Split(new string[] { $"{awsBucketName}:\\" }, StringSplitOptions.None)[1];

            if (path.EndsWith("/")) path = path.TrimLastCharacter();

            return path.Replace("//", "/").Replace("\\", "/").Replace("\\\\", "/");
        }

        public bool IsFileLocked(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return false;

                using (File.Open(filePath, FileMode.Open)) { }
            }
            catch (IOException e)
            {
                var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);

                return errorCode == 32 || errorCode == 33;
            }

            return false;
        }
    }
}
