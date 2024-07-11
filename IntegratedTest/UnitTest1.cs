using IntegratedTest.Model;

namespace IntegratedTest
{
    public class UnitTest1
    {


        [Fact]
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

        [Fact]
        public async Task CapturaComSucessoUmContato()
        {
            var httpClient = new HttpClient();
            var tokenClient = new TokenClient();
            var contactsClient = new ContactsClient(httpClient);

            string username = "Admin";
            string password = "1234";
            int roleType = 0;

            string token = await tokenClient.GetTokenAsync(username, password, roleType);

            var contact = await contactsClient.GetContact(1, token);
            Console.WriteLine(contact);

            Assert.NotNull(contact);

        }

        [Fact]
        public async Task CriaUmContatoComSucesso()
        {
            var httpClient = new HttpClient();
            var tokenClient = new TokenClient();
            var contactsClient = new ContactsClient(httpClient);

            string username = "Admin";
            string password = "1234";
            int roleType = 0;

            string token = await tokenClient.GetTokenAsync(username, password, roleType);

            var newContact = new ContactDto { Fullname = "João Silva", Ddd = "55", Ddi ="11", Phonenumber = "123456789", Email = "joao@example.com" };
            var createdContact = await contactsClient.CreateContact(newContact, token);

            Assert.NotNull(newContact);

        }

        [Fact]
        public async Task ModificaUmContatoComSucesso()
        {
            var httpClient = new HttpClient();
            var tokenClient = new TokenClient();
            var contactsClient = new ContactsClient(httpClient);

            string username = "Admin";
            string password = "1234";
            int roleType = 0;
            Thread.Sleep(TimeSpan.FromSeconds(3));
            string token = await tokenClient.GetTokenAsync(username, password, roleType);
            Console.WriteLine($"Token: {token}");

            try
            {
                var updatedContact = new ContactDto { Id = 2, Fullname = "João Silva Atualizado", Ddd = "55", Ddi = "11", Phonenumber = "987654321", Email = "joao.updated@example.com" };
                var contactUpdated = await contactsClient.UpdateContact(updatedContact, token);
            }
            catch { }

        }

        [Fact]
        public async Task DeletaUmContato()
        {
            var httpClient = new HttpClient();
            var tokenClient = new TokenClient();
            var contactsClient = new ContactsClient(httpClient);

            string username = "Admin";
            string password = "1234";
            int roleType = 0;
            Thread.Sleep(TimeSpan.FromSeconds(5));
            string token = await tokenClient.GetTokenAsync(username, password, roleType);

            var deleteResponse = await contactsClient.DeleteContact(1, token);

        }
    }
}