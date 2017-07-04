using Amazon;
using Amazon.S3;
using Amazon.S3.IO;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Frapid.Configuration.Tests.StorageServices
{
    public class AmazonStorageTests
    {        
        [Fact]
        public void DeleteDirecties()
        {
            AmazonS3Config cfg = new AmazonS3Config();
            cfg.RegionEndpoint = RegionEndpoint.USWest2;
            AmazonS3Client amazonS3Client = new AmazonS3Client("AKIAJKYWWGKLKFZGVU6A", "ziZeDnKBDMkhPRGPr8WUwZUi/iCDuCdgtEQuZ4MX", cfg);
            var buckets = amazonS3Client.ListBuckets().Buckets.Where(b => !b.BucketName.Contains("-bucket")).ToList();

            foreach (var bucket in buckets)
            {
                try
                {
                    //new S3DirectoryInfo(amazonS3Client, bucket.BucketName).Delete(true);

                    ListObjectsResponse response = amazonS3Client.ListObjects(new ListObjectsRequest() { BucketName = bucket.BucketName });
                    if (response.S3Objects.Count > 0)
                    {
                        List<KeyVersion> keys = response.S3Objects.Select(obj => new KeyVersion()).ToList();
                        DeleteObjectsRequest deleteObjectsRequest = new DeleteObjectsRequest
                        {
                            BucketName = bucket.BucketName,
                            Objects = keys
                        };
                        amazonS3Client.DeleteObjects(deleteObjectsRequest);
                    }

                    DeleteBucketRequest request = new DeleteBucketRequest
                    {
                        BucketName = bucket.BucketName
                    };
                    amazonS3Client.DeleteBucket(request);
                }
                catch (Exception)
                {

                }
            }

            buckets = amazonS3Client.ListBuckets().Buckets;
            Assert.Equal(buckets.Count, 2);
        }
    }
}
