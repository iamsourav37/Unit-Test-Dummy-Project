using System.Diagnostics;
using System.Net;

namespace Program
{

    public class ReturnMessage
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Value { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public int Add(int a, int b)
        {
            return a + b + 1;
        }

        public ReturnMessage SendGetRequest(string requestUrl)
        {
            var returnMessage = new ReturnMessage();

            try
            {
                // api call code here
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetAsync(requestUrl).Result;
                    var responseBody = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        returnMessage.Status = true;
                        returnMessage.Value = responseBody;
                    }
                    else
                    {
                        returnMessage.Status = false;
                        returnMessage.Message = responseBody;
                    }
                }

            }
            catch (Exception ex)
            {
                returnMessage.Status = false;
            }

            return returnMessage;
        }

        public string MakeFullName(string firstname, string lastname)
        {
            return $"{firstname} {lastname}";
        }

        public List<int> FibonacciNumbers = new List<int>() { 1, 1, 2, 3, 5, 8, 13, 21};
    }
}