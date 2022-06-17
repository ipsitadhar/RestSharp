using System;
using Xunit;
using RestSharp;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using TestStack.BDDfy;
using static TestStack.BDDfy.Reporters.Diagnostics.StoryDiagnostic;

namespace ReqResTesting
{
    public class ApiEndpointFeature : IClassFixture<TestFixture>
    {
             
        [Fact]
        public async Task TestGetEndPoint()
        {
            //TestFixture.CreateRestClient();
            TestFixture.CreateGetRestRequest();
            await TestFixture.GetResponseAsync();
            TestFixture.AssertGetResponse();

        }   
        [Fact]
        public async Task TestPostEndPoint()
        {
            this.Given(step ApiEndpointFeature => step.IHaveAnApiGetEndPoint())
            //TestFixture.CreateRestClient();
            TestFixture.CreatePostRestRequest();
            await TestFixture.GetResponseAsync();
            TestFixture.AssertPostResponse();

        }
    }
 
    
}
