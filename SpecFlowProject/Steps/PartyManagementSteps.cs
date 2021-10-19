using Domain;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebUserAPI;
using Xunit;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class PartyManagementStepDefenition : PrincipalManagementStepDefinition
    {
        public PartyManagementStepDefenition(CustomWebApplicationFactory<TestStartup> factory) : base(factory) { }

        public Party party { get; set; }
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
             party = await _client.GetFromJsonAsync<Party>(getRelativeUri); 
        }

        [Then(@"I will find the party")]
        public void ThenIWillFindTheParty()
        {
            Assert.NotNull(party);
            Assert.Equal(cCommand.Type, party.GetType().ToString());
            Assert.Equal(cCommand.Name, party.Name);
            Assert.Equal(_identifiers[0], party.Id);
        }

    }
}
