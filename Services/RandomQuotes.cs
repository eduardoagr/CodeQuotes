using System.Net.Http.Json;

using CodeQuotes.Model;

namespace CodeQuotes.Services;
public class RandomQuotes
{
    public static async Task<Quote> GetRandomQuote()
    {
        var accessType = Connectivity.Current.NetworkAccess;

        if (accessType == NetworkAccess.Internet)
        {
            var client = new HttpClient();
            var url = "https://programming-quotes-api.herokuapp.com/Quotes/random";

            var res = await client.GetAsync(url);

            if (res.IsSuccessStatusCode)
            {
                var quote = await res.Content.ReadFromJsonAsync<Quote>();

                return quote;
            }
        }

        return null;
    }
}
