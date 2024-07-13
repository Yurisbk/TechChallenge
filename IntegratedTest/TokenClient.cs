using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class TokenClient
{
    public async Task<string> GetTokenAsync(string username, string password, int roleType)
    {

        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5217/api/Token");
        request.Headers.Add("accept", "*/*");
        var content = new StringContent("{\n  \"username\": \"Admin\",\n  \"passwordvalue\": \"1234\",\n  \"roletype\": 0\n}", null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro ao obter token: {error}");
        }
    }
}
