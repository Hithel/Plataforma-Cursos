using System.Net.Http;
using System.Text; // Para usar Encoding
using System.Net.Http.Headers; // Para usar MediaTypeHeaderValue




namespace Frontend.Services;

public class ApiService
{
    private readonly HttpClient httpClient;

    public ApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<string> GetCurso()
    {
        return await httpClient.GetStringAsync("http://localhost:5258/api/Curso");
    }

    public async Task<string> GetCursoId(int Id)
    {
        return await httpClient.GetStringAsync($"http://localhost:5258/api/Curso/{Id}");
    }

    public async Task<string> GetInstructor(int Id)
    {
        return await httpClient.GetStringAsync($"http://localhost:5258/api/Instructor/{Id}");
    }

    public async Task<string> GetCalificacion()
    {
        return await httpClient.GetStringAsync("http://localhost:5258/api/Calificacion");
    }

    public async Task<string> PostUser(string jsonData)
    {
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


        var response = await httpClient.PostAsync("http://localhost:5258/api/User/Login", content);

 
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;

        }
        else
        {
 
            return "Error al Loggearse.";
        }
    }

    public async Task<string> PostEvaluacion(string jsonData)
    {
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("http://localhost:5258/api/Calificacion", content);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;

        }
        else
        {
 
            return "Se jodio esta monda!!.";
        }

    }
    
}

