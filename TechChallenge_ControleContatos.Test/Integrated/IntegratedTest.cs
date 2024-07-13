using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge_ControleContatos.Test.Integrated
{
    public class IntegratedTest
    {
        [Fact, Trait("Category", "Integration")]
        public async Task CapturaComSucessoTodosContatos()
        {
            var httpClient = new HttpClient();
            var tokenClient = new TokenClient();
            var contactsClient = new ContactsClient(httpClient);

            string username = "Admin";
            string password = "1234";
            int roleType = 0;

            string token = await tokenClient.GetTokenAsync(username, password, roleType);
            Console.WriteLine($"Token: {token}");

            var x = await contactsClient.GetAllContacts(token);

            Assert.NotNull(x);

        }
    }
}
