using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebUserAPI.Controllers;
using WebUserAPI.Model;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class PrincipalManagementStepDefinition : IClassFixture<CustomWebApplicationFactory<TestStartup>>
    {
        private CreatePrincipalCommand command;
        private WebApplicationFactory<TestStartup> _factory;
        private List<Guid> _identifiers;
        private Principal principal = null;

        private HttpClient _client { get; set; }
        protected HttpResponseMessage Response { get; set; }

        public PrincipalManagementStepDefinition(CustomWebApplicationFactory<TestStartup> factory)
        {
            _identifiers = new List<Guid>();

            _factory = factory.WithWebHostBuilder(builder => builder.ConfigureServices(services =>
            {

            }));
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost/")
            });

        }

        public void GivenAPrincipalIsDefinedAs(Table table, string type)
        {
            command = table.CreateInstance<CreatePrincipalCommand>();
            command.Type = type;
        }

        [Given(@"A user is defined as:")]
        public void GivenAUserIsDefinedAs(Table table)
        {
            GivenAPrincipalIsDefinedAs(table, "user");
        }

        [When(@"I register the principal")]
        public async Task WhenIRegisterThePrincipalAsync()
        {
            var postRelativeUri = new Uri("principal", UriKind.Relative);
            Response = await _client.PostAsJsonAsync(postRelativeUri, command).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
            _identifiers.Add(Guid.Parse((await Response.Content.ReadAsStringAsync()).Replace('"', ' ').Trim()));
        }

        [When(@"I get the user by Id")]
        public async Task WhenIGetTheUserByIdAsync()
        {
            var getRelativeUri = new Uri($"Principal/{{{_identifiers.Last()}}}", UriKind.Relative);
            try
            {
                principal = await _client.GetFromJsonAsync<Principal>(getRelativeUri);
            }
            catch
            { principal = null; }
        }

        [Then(@"I will find the user")]
        public void ThenIWillFindThePrincipal()
        {
            Assert.NotNull(principal);
            Assert.Equal(command.Name, principal.Name);
            Assert.Equal(_identifiers[0], principal.Id);
        }

        [Given(@"A user is registered as:")]
        public async Task GivenAUserIsRegisteredAs(Table table)
        {
            GivenAPrincipalIsDefinedAs(table, "user");
            await WhenIRegisterThePrincipalAsync();
        }

        [When(@"I Update the user to:")]
        public async Task WhenIUpdateThePrincipalTo(Table table)
        {
            command = table.CreateInstance<CreatePrincipalCommand>();
            PatchPrincipalCommand uCommand = new PatchPrincipalCommand
            {
                Name = command.Name,
                Order = PrincipalPatchType.ChangeName,
            };
            uCommand.Id = _identifiers[0];

            var putRelativeUri = new Uri($"Principal/{{{_identifiers.Last()}}}", UriKind.Relative);
            var content = new StringContent(JsonSerializer.Serialize(uCommand), Encoding.UTF8, "application/json-patch+json");
            Response = await _client.PatchAsync(putRelativeUri, content).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
            _identifiers.Add(Guid.Parse((await Response.Content.ReadAsStringAsync()).Replace('"', ' ').Trim()));
        }

        [Then(@"I will find the user with updated values")]
        public void ThenIWillFindThePrincipalWithUpdatedValues()
        {
            ThenIWillFindThePrincipal();
        }

        [When(@"I Delete the user")]
        public async Task WhenIDeleteThePrincipal()
        {
            var deleteRelativeUri = new Uri($"principal/{{{_identifiers[0]}}}", UriKind.Relative);
            Response = await _client.DeleteAsync(deleteRelativeUri).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
        }

        [Then(@"I will not find the user")]
        public void ThenIWillNotFindThePrincipal()
        {
            Assert.Null(principal);
        }

        [When(@"I register the user")]
        public async Task WhenIRegisterTheUser()
        {
            await WhenIRegisterThePrincipalAsync();
        }

        [Given(@"A Group is registered as:")]
        public async Task GivenAGroupIsRegisteredAs(Table table)
        {
            GivenAPrincipalIsDefinedAs(table, "group");
            await WhenIRegisterThePrincipalAsync();
        }

        [When(@"I join the user to the group")]
        public async Task WhenIJoinTheUserToTheGroup()
        {
            var jCommand = new PatchPrincipalCommand
            {
                Order = PrincipalPatchType.JoinToGroup,
                GroupId = _identifiers[0],
            };
            var patchRelativeUri = new Uri($"Principal/{{{_identifiers.Last()}}}", UriKind.Relative);
            Response = await _client.PutAsJsonAsync(patchRelativeUri, jCommand).ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
        }

        [Then(@"I will find the user with the group")]
        public void ThenIWillFindTheUserWithTheGroup()
        {
            Assert.NotNull(principal);
            Assert.Equal(_identifiers[1], principal.Id);
            Assert.NotNull(principal.Groups.Find(g => g.GroupId.Equals(_identifiers[0])));
        }

        [Given(@"the user is in group")]
        public async Task GivenTheUserIsInGroup()
        {
            await WhenIJoinTheUserToTheGroup();
        }

        [When(@"I leave the user from group")]
        public async Task WhenILeaveTheUserFromGroup()
        {
            var lCommand = new PatchPrincipalCommand
            {
                Order = PrincipalPatchType.LeaveGroup,
                GroupId = _identifiers[0],
            };

            var putRelativeUri = new Uri($"Principal/{{{ _identifiers.Last() }}}", UriKind.Relative);
            Response = await _client.PutAsJsonAsync(putRelativeUri, lCommand).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
        }

        [Then(@"I will not find the group in groups of user")]
        public void ThenIWillNotFindTheGroupInGroupsOfUser()
        {
            Assert.NotNull(principal);
            Assert.Equal(_identifiers[1], principal.Id);
            Assert.Null(principal.Groups.Find(g => g.GroupId == _identifiers[1]));
        }

        [Then(@"I will find the user with his groups")]
        public void ThenIWillFindTheUserWithHisGroups()
        {
        }

        [When(@"I register the user with registered group as default")]
        public async Task WhenIRegisterTheUserWithRegisteredGroupAsDefault()
        {
            var postRelativeUri = new Uri("principal", UriKind.Relative);
            CreatePrincipalCommand theCommand = new CreatePrincipalCommand
            {
                Name = command.Name,
                Type = "user",
                Groups = _identifiers
            };

            Response = await _client.PostAsJsonAsync(postRelativeUri, theCommand).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
            _identifiers.Add(Guid.Parse((await Response.Content.ReadAsStringAsync()).Replace('"', ' ').Trim()));
        }


    }
}
