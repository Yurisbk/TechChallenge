using IntegratedTest.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ContactsClient
{
    private readonly HttpClient _httpClient;

    public ContactsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:5217/api/ContactsInfo/");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private void AddAuthorizationHeader(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<string> GetAllContacts(string token)
    {
        AddAuthorizationHeader(token);
        HttpResponseMessage response = await _httpClient.GetAsync("GetAllContacts");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new Exception($"Erro ao obter todos os contatos: {response.ReasonPhrase}");
        }
    }


    public async Task<string> GetContact(int id, string token)
    {
        AddAuthorizationHeader(token);
        HttpResponseMessage response = await _httpClient.GetAsync($"GetContact?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new Exception($"Erro ao obter contato: {response.ReasonPhrase}");
        }
    }


    public async Task<ContactDto> CreateContact(ContactDto contact, string token)
    {
        AddAuthorizationHeader(token);
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("CreateContact", contact);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<ContactDto>();
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro ao criar contato: {error}");
        }
    }



    public async Task<ContactDto> UpdateContact(ContactDto contact, string token)
    {
        AddAuthorizationHeader(token);
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync("UpdateContact", contact);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<ContactDto>();
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro ao atualizar contato: {error}");
        }
    }



    public async Task<string> DeleteContact(int id, string token)
    {
        AddAuthorizationHeader(token);
        HttpResponseMessage response = await _httpClient.DeleteAsync($"DeleteContact?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro ao deletar contato: {error}");
        }
    }

}
