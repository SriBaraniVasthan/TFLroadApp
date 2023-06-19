using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{

    class Program
    {
        //update your AppId and Appkey for API call below

        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            String roadId = null;
            for (int i = 0; i < args.Length; i++)
            {
                roadId = args.GetValue(i).ToString();
            }

            Program program = new Program();
            if (roadId != null)
            {
                await program.apiCall(roadId);
            }
            else if (roadId == null)
            {
                Console.WriteLine("No road Id specified");

            }
        }

        private async Task apiCall(String roadId)
        {
            String myAppId = "";
            String myAppKey = "";
            if (myAppId.Equals("") || myAppKey.Equals(""))
            {
                Console.WriteLine("Pls add a valid API Id or Key");
            }
            else
            {
                var result = (dynamic)null;
                try
                {

                    String url = "https://api.tfl.gov.uk/Road/" + roadId + "?app_id=" + myAppId + "&app_key=" + myAppKey;
                    var request = await client.GetAsync(url);
                    var response = request.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<dynamic>(response);
                    var temp = result.First;
                    if (temp == null)
                    {
                        if (result.ContainsKey("httpStatus"))
                        {
                            Console.WriteLine(roadId + " is not a valid road");
                        }
                    }
                    else
                    {
                        if (temp.ContainsKey("displayName"))
                        {
                            Console.WriteLine("The status of the " + roadId + " is as follows:");
                            Console.WriteLine("Road Status is " + temp.statusSeverity);
                            Console.WriteLine("Road description is " + temp.statusSeverityDescription);

                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Error during road API call");
                }
            }
        }
    }
}