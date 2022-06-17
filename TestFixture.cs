using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace ReqResTesting
{
    public class TestFixture
    {
        public TestFixture()
        {
            CreateRestClient();
        }

        private static RestClient client;
        private static RestRequest request;
        private static RestResponse response;

        private static void CreateRestClient()
        {
            client = new RestClient(new Uri("https://reqres.in"));
        }

        public static void CreateGetRestRequest()
        {

            request = new RestRequest("/api/users", Method.Get);
            request.AddHeader("content-type", "application/json");

        }

        public static void CreatePostRestRequest()
        {

            request = new RestRequest("/api/users/2", Method.Post);
            request.AddHeader("content-type", "application/json");
            request.AddBody(new reqres
            {
                Name = "morpheus",
                Job = "leader",
                Id = 308,
                CreationTime = DateTime.Now
            }
            );

        }

        public static async Task GetResponseAsync()
        {
            response=await client.ExecuteAsync(request);
        }

        public static void AssertGetResponse()
        {
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        public static void AssertPostResponse()
        {
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var content = JsonSerializer.Deserialize<reqres>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            Assert.NotNull(content);
            Assert.Equal("morpheus", content.Name);
            Assert.Equal("leader", content.Job);
            Assert.Equal(308, content.Id);
        }
    }
}

