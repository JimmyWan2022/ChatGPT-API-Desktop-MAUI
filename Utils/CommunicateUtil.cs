using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MauiBatchChatGPT.Utils
{
    class CommunicateUtil
    {

 public    static   async Task<string> GetResponse(string prompt_text,String apiKey)
        {
            string prompt = cleanprompt(prompt_text);
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(20);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            const string apiEndpoint = "https://api.openai.com/v1/chat/completions";
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                }
            };
            var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, apiEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            request.Content = requestContent;

            // Send API request
            HttpResponseMessage response;
            try
            {
                response = await httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                string errorMessage = "HTTP request failed: " + ex.Message;
                //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Process API response
            string responseContent;
            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                taxes(JsonConvert.DeserializeObject(responseContent));
                return responseContent;
            }
            else
            {
                responseContent = await response.Content.ReadAsStringAsync();
                string errorMessage = $"API request failed with status code {response.StatusCode}. Reason: {response.ReasonPhrase}. Response content: {responseContent}";
                //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public static  void taxes(dynamic jsonResponse)
        {
            int prompt_tokens = jsonResponse.usage.prompt_tokens;
            int completion_tokens = jsonResponse.usage.completion_tokens;
            int total_tokens = jsonResponse.usage.total_tokens;

            //int total_spent;
            //if (string.IsNullOrEmpty(total_spent_box.Text) || !int.TryParse(total_spent_box.Text, out total_spent))
            //{
            //    total_spent = 0;
            //}
            //total_spent += total_tokens;
            //total_spent_box.Text = total_spent.ToString();
            //prompt_token_box.Text = prompt_tokens.ToString();
            //completion_token_box.Text = completion_tokens.ToString();
            //total_token_box.Text = total_tokens.ToString();
            //current_spent_box.Text = (0.000002 * total_tokens).ToString("0.000000") + "$";
            //total_m_spent_box.Text = (0.000002 * total_spent).ToString("0.000000") + "$";
        }
        public static string cleanprompt(string prompt_text)
        {
            string cleanded_prompt = prompt_text?.Replace(Environment.NewLine, "\\n")?.Replace("\t", " ").Replace("\"", "\\\"");
            cleanded_prompt = System.Text.RegularExpressions.Regex.Replace(cleanded_prompt, @"\s+", " ");
            return cleanded_prompt;
        }

        public static async Task<bool> CheckApiKey(string apiKey)
        {
            try
            {
                OpenAI_API.OpenAIAPI api = new OpenAI_API.OpenAIAPI(apiKey);
                var result = await api.Completions.GetCompletion("One Two Three One Two");
                Console.WriteLine(result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
