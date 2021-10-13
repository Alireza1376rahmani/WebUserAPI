﻿using Domain;
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
using WebUserAPI.Model;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class PrincipalManagementStepDefinition : IClassFixture<CustomWebApplicationFactory<TestStartup>>
    {
        private CreatePrincipalCommand command;
        private WebApplicationFactory<TestStartup> _factory;
        private List<Guid> _identidiers;
        private Principal principal = null;

        //public PrincipalManagementStepDefinition(ScenarioContext scenarioContext)
        //{
        //    _scenarioContext = scenarioContext;
        //}

        private HttpClient _client { get; set; }
        protected HttpResponseMessage Response { get; set; }

        public PrincipalManagementStepDefinition(CustomWebApplicationFactory<TestStartup> factory)
        {
            _identidiers = new List<Guid>();

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

        public async Task WhenIGetThePrincipalByIdAsync()
        {
            var getRelativeUri = new Uri($"Principal/{{{_identidiers[0]}}}", UriKind.Relative);
            principal = await _client.GetFromJsonAsync<User>(getRelativeUri);
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
            _identidiers.Add(Guid.Parse((await Response.Content.ReadAsStringAsync()).Replace('"', ' ').Trim()));
        }

        [When(@"I get the user by Id")]
        public async Task WhenIGetTheUserByIdAsync()
        {
            var getRelativeUri = new Uri($"Principal/{{{_identidiers[0]}}}", UriKind.Relative);
            try { principal = await _client.GetFromJsonAsync<User>(getRelativeUri); } catch { principal = null; }
        }

        [Then(@"I will find the user")]
        public void ThenIWillFindThePrincipal()
        {
            Assert.NotNull(principal);
            Assert.Equal(command.Name, principal.Name);
            Assert.Equal(_identidiers[0], principal.Id);
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
            UpdatePrincipalCommand uCommand = table.CreateInstance<UpdatePrincipalCommand>();
            uCommand.Id = _identidiers[0];

            var putRelativeUri = new Uri("principal", UriKind.Relative);
            Response = await _client.PutAsJsonAsync(putRelativeUri, uCommand).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
            _identidiers.Add(Guid.Parse((await Response.Content.ReadAsStringAsync()).Replace('"', ' ').Trim()));
        }

        [Then(@"I will find the user with updated values")]
        public void ThenIWillFindThePrincipalWithUpdatedValues()
        {
            ThenIWillFindThePrincipal();
        }

        [When(@"I Delete the user")]
        public async Task WhenIDeleteThePrincipal()
        {
            var deleteRelativeUri = new Uri($"principal/{{{_identidiers[0]}}}", UriKind.Relative);
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

        [Given(@"A user with groups is defined as:")]
        public void GivenAUserWithGroupsIsDefinedAs(Table table)
        {

        }

        [When(@"I join the user to the group")]
        public async Task WhenIJoinTheUserToTheGroup()
        {
            var userId = _identidiers[0];
            var groupId = _identidiers[1];
             var jCommand = new PrincipalJoinsToGroupCommand
            {
                GroupId = groupId,
                PrincipalId = userId
            };

            var putRelativeUri = new Uri("principal/join", UriKind.Relative);
            Response = await _client.PutAsJsonAsync(putRelativeUri, jCommand).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
        }

        [Then(@"I will find the user with the group")]
        public void ThenIWillFindTheUserWithTheGroup()
        {
            Assert.NotNull(principal);
            Assert.Equal(_identidiers[0], principal.Id);
            Assert.NotNull(principal.Groups.Find(g => g.Id.Equals(_identidiers[1])));
        }



    }
}
