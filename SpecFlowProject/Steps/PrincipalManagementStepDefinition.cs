using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebUserAPI.Controllers;
using WebUserAPI.Domain;
using WebUserAPI.Model;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class PrincipalManagementStepDefinition : IClassFixture<CustomWebApplicationFactory<TestStartup>>
    {

        private readonly ScenarioContext _scenarioContext;

        private CreatePrincipalCommand command;
        private WebApplicationFactory<TestStartup> _factory;
        private Guid newPrincipalId;
        private Principal principal = null;

        //public PrincipalManagementStepDefinition(ScenarioContext scenarioContext)
        //{
        //    _scenarioContext = scenarioContext;
        //}

        private HttpClient _client { get; set; }
        protected HttpResponseMessage Response { get; set; }

        public PrincipalManagementStepDefinition(CustomWebApplicationFactory<TestStartup> factory, ScenarioContext scenarioContext)
        {
            _factory = factory.WithWebHostBuilder(builder => builder.ConfigureServices(services =>
            {

            }));
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost/")
            });
            _scenarioContext = scenarioContext;
        }

        [Given(@"A Principal is defined as:")]
        public void GivenAPrincipalIsDefinedAs(Table table)
        {
            command = table.CreateInstance<CreatePrincipalCommand>();
            command.Type = "user";
        }

        [When(@"I register the principal")]
        public async Task WhenIRegisterThePrincipalAsync()
        {
            var postRelativeUri = new Uri("principal", UriKind.Relative);
            Response = await _client.PostAsJsonAsync(postRelativeUri, command).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
            newPrincipalId = Guid.Parse((await Response.Content.ReadAsStringAsync()).Replace('"', ' ').Trim());
        }

        [When(@"I get the principal by Id")]
        public async Task WhenIGetThePrincipalByIdAsync()
        {
            var getRelativeUri = new Uri($"Principal/{{{newPrincipalId}}}",UriKind.Relative);
            try { principal = await _client.GetFromJsonAsync<User>(getRelativeUri); } catch { principal = null; }
        }

        [Then(@"I will find the principal")]
        public void ThenTheResultShouldBe()
        {
            Assert.NotNull(principal);
            Assert.Equal(command.Name, principal.Name);
            Assert.Equal(newPrincipalId, principal.Id);
        }
    }
}
