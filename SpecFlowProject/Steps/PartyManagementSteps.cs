using Domain;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebUserAPI;
using WebUserAPI.Model.mappings;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class PartyManagementStepDefenition : PrincipalManagementStepDefinition
    {
        public PartyManagementStepDefenition(CustomWebApplicationFactory<TestStartup> factory) : base(factory) { }

        public PartyDto party { get; set; }
        public CreatePartyCommand cCommand { get; set; }

        [Given(@"A party is defined as :")]
        public void GivenAPartyIsDefinedAs(Table table)
        {
            cCommand = table.CreateInstance<CreatePartyCommand>();
        }

        [When(@"I register the party")]
        public async Task WhenIRegisterTheParty()
        {
            var postRelativeUri = new Uri("party", UriKind.Relative);
            Response = await _client.PostAsJsonAsync(postRelativeUri, cCommand).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
            _identifiers.Add(Guid.Parse((await Response.Content.ReadAsStringAsync()).Replace('"', ' ').Trim()));
        }

        [When(@"I get the party by Id")]
        public async Task WhenIGetThePartyById()
        {
            var getRelativeUri = new Uri($"Party/{{{_identifiers[0]}}}", UriKind.Relative);
            try { party = await _client.GetFromJsonAsync<PartyDto>(getRelativeUri); }
            catch { party = null; }
        }

        [Then(@"I will find the party")]
        public void ThenIWillFindTheParty() 
        {
            Assert.NotNull(party);
            Assert.Equal(cCommand.Type, party.Type);
            Assert.Equal(cCommand.Name, party.Name);
            Assert.Equal(_identifiers[0], party.Id);
        } 

        [Given(@"A Party is registered as:")]
        public async Task GivenAPartyIsRegisteredAs(Table table)
        {
            GivenAPartyIsDefinedAs(table);
            await WhenIRegisterTheParty();
        }

        [When(@"I delete the party")]
        public async Task WhenIDeleteTheParty()
        {
            var deleteRelativeUri = new Uri($"party/{{{_identifiers[0]}}}", UriKind.Relative);
            Response = await _client.DeleteAsync(deleteRelativeUri).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
        }

        [Then(@"I will not find the party")]
        public void ThenIWillNotFindTheParty()
        {
            Assert.Null(party);
        }

        [When(@"I Update party's name to ""(.*)""")]
        public async Task WhenIUpdatePartySNameTo(string newName)
        {
            var uCommand = new PatchPartyCommand
            {
                Name = newName,
            };
            cCommand.Name = newName;

            var patchRelativeUri = new Uri($"party/{{{_identifiers.Last()}}}", UriKind.Relative);
            var content = new StringContent(JsonSerializer.Serialize(uCommand), Encoding.UTF8, "application/json-patch+json");

            Response = await _client.PatchAsync(patchRelativeUri, content).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
            
        }

        [Then(@"I will find the party with updated name")]
        public void ThenIWillFindThePartyWithUpdatedName()
        {
            Assert.NotNull(party);
            Assert.Equal(_identifiers[0], party.Id);
            Assert.Equal(cCommand.Name,party.Name);
        }


    }
}
