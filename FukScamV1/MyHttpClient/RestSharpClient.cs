using FukScamV1.Helpers;
using FukScamV1.Models;
using RestSharp;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace FukScamV1.MyHttpClient
{
    public static class RestSharpClient
    {
        public static string Cookies = "";
        private static RestRequest BuildPostRequest(string apiUrl)
        {
            var request = new RestRequest(apiUrl, Method.Post)
            {
                AlwaysMultipartFormData = true,
            };

            request.AddHeader("Cookie", Cookies);
            request.AddHeader("x-requested-with", "XMLHttpRequest");

            return request;
        }

        public static async Task<(bool success, string tranInfo)> SendBankInfoRequest(string apiUrl, List<string[]> requestData)
        {
            var client = new RestClient();
            var request = BuildPostRequest(apiUrl);


            foreach (var item in requestData)
            {
                request.AddParameter(item[0], item[1]);
            }


            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var result = JsonSerializer.Deserialize<ResponseBankInfoModel>(response.Content);

                string pattern = @"name=\""tran_info\"" value=\""([^\""]*)\""";

                if (result?.Html is not null)
                {
                    Match match = Regex.Match(result.Html, pattern);

                    if (match.Success)
                    {
                        string tranInfoValue = match.Groups[1].Value;
                        return (true, tranInfoValue);
                    }
                }

                else
                {
                    Console.WriteLine("Không tìm thấy giá trị 'tran_info'");
                }
                return (false, "");
            }
            else
            {
                Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                return (false, "");
            }
        }

        public static async Task<bool> SendOTPRequest(string apiUrl, List<string[]> requestData)
        {
            var client = new RestClient();
            var request = BuildPostRequest(apiUrl);

            foreach (var item in requestData)
            {
                request.AddParameter(item[0], item[1]);
            }
            var response = await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }

        public static async Task<(string? token, string? cookie)> GetCookie(string apiUri)
        {
            var client = new RestClient();
            var request = new RestRequest(apiUri, Method.Get);

            var response = await client.ExecuteAsync(request);

            var CSRFToken =  Helper.ExtractCSRFToken(response.Content);


            var cookies = new StringBuilder();


            for(int i = response.Headers.Count() - 1; i >= 0; i--)
            {
                if (response.Headers.ElementAt(i).Name == "Set-Cookie")
                {
                    Console.WriteLine(response.Headers.ElementAt(i).Value.ToString());
                    var value = response.Headers.ElementAt(i).Value.ToString().Split(";")[0];
                    cookies.Append(value).Append("; ");
                }
            }
            
            return (CSRFToken, cookies.ToString().Remove(cookies.Length - 2));
        }
    }
}
