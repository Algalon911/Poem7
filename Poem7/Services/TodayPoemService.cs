using System.Text.Json;

namespace Poem7.Services;

public class TodayPoemService : ITodayPoemService
{
    private HttpClient httpClient;

    public TodayPoemService()
    {
        this.httpClient = new() { BaseAddress = new Uri("https://v2.jinrishici.com/") };
    }

    public async Task<TodayPoem> GetTodayPoemAsync()
    {
        var token = await GetTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            return await GetRadomPoemAsync();
        }
        httpClient.DefaultRequestHeaders.Add("X-User-Token", token);
        HttpResponseMessage response;
        try
        {
            response = await httpClient.GetAsync("sentence");
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            return await alertAndReturnLocalPoem(ex);
        }

        var json = await response.Content.ReadAsStringAsync();
        JinrishiciSentence jinrishiciSentence;
        try
        {
            jinrishiciSentence =
                JsonSerializer.Deserialize<JinrishiciSentence>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? throw new JsonException();
        }
        catch (Exception ex)
        {
            return await alertAndReturnLocalPoem(ex);
        }

        try
        {
            return new TodayPoem
            {
                Snippet =
                    jinrishiciSentence.Data?.Content ??
                    throw new JsonException(),
                Name =
                    jinrishiciSentence.Data.Origin?.Title ??
                    throw new JsonException(),
                Dynasty =
                    jinrishiciSentence.Data.Origin.Dynasty ??
                    throw new JsonException(),
                Author =
                    jinrishiciSentence.Data.Origin.Author ??
                    throw new JsonException(),
                Content =
                    string.Join("\n",
                        jinrishiciSentence.Data.Origin.Content ??
                        throw new JsonException()),
                Source = TodayPoemSources.Jinrishici
            };
        }
        catch (Exception ex)
        {
            return await alertAndReturnLocalPoem(ex);
        }



        async Task<TodayPoem> alertAndReturnLocalPoem(Exception ex)
        {
            return await GetRadomPoemAsync();
        }
    }

    public async Task<string> GetTokenAsync()
    {
        //using var httpClient = new HttpClient();
        HttpResponseMessage response;
        try
        {
            //response = await httpClient.GetAsync("https://v2.jinrishici.com/token");
            response = await httpClient.GetAsync("token");
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };//大小写问题
        var jinrishiciToken = JsonSerializer.Deserialize<JinrishiciToken>(json, options);
        return jinrishiciToken.Data;
    }

    public async Task<TodayPoem> GetRadomPoemAsync()
    {
        return new TodayPoem()
        {
            Snippet = "加载失败",
            Name = "加载失败",
            Dynasty = "加载失败",
            Author = "加载失败",
            Content = "加载失败",
            Source = TodayPoemSources.Local
        };
    }

}


public class JinrishiciToken
{
    public string Status { get; set; }
    public string Data { get; set; }
}


public class JinrishiciOrigin
{
    public string Title { get; set; } = string.Empty;
    public string Dynasty { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public List<string> Content { get; set; } = new();
    public List<string> Translate { get; set; } = new();
}

public class JinrishiciData
{
    public string Content { get; set; } = string.Empty;
    public JinrishiciOrigin Origin { get; set; } = new();
}

public class JinrishiciSentence
{
    public JinrishiciData Data { get; set; } = new();
}

