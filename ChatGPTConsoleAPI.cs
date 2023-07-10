namespace chatgptapi
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    class Program
    {
        static async Task Main()
        {
            // OpenAI API bilgilerinizi girin
            string apiKey = "API-KEY";
            string endpoint = "https://api.openai.com/v1/engines/davinci-codex/completions";

            // Giriş metnini al
            Console.Write("Mesajı girin: ");
            string inputText = Console.ReadLine();

            // OpenAI'ya isteği gönder ve yanıtı al
            string response = await GetCompletionAsync(apiKey, endpoint, inputText);

            // Yanıtı etikete yazdır
            Console.WriteLine("GPT-3.5 Yanıtı:");
            Console.WriteLine(response);
        }

        static async Task<string> GetCompletionAsync(string apiKey, string endpoint, string inputText)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

                var requestBody = new
                {
                    prompt = inputText,
                    max_tokens = 100,
                    temperature = 0.7,
                    top_p = 1.0,
                    n = 1,
                    stop = "###"
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var httpResponse = await httpClient.PostAsync(endpoint, content);
                var responseJson = await httpResponse.Content.ReadAsStringAsync();

                dynamic responseObject = JsonConvert.DeserializeObject(responseJson);
                string completionText = responseObject.choices[0].text;

                return completionText;
            }
        }
    }


}