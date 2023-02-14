using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

namespace WebApiClientCSharp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ClearScreen();
            Console.Write("Please enter the port number: ");

            int port = GetInteger("Please enter the port number where the program is running: ");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(string.Format("https://localhost:{0}/", port));

                ClearScreen();
                Console.WriteLine("Here is a list of the forums:");
                await ShowAllForums(client);

                Console.WriteLine();
                Console.WriteLine("Now, we're going to add a forum");
                Console.Write("Enter the title of the new forum: ");
                string title = Console.ReadLine();

                await AddForum(client, title);
                Console.WriteLine("Done");
                Console.WriteLine();

                Console.WriteLine("Here is the new list of the forums:");
                await ShowAllForums(client);
            }
        }


        private static async Task ShowAllForums(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // HTTP GET
            HttpResponseMessage response = await client.GetAsync("api/Forum");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                IEnumerable<Forum> forums = JsonSerializer.Deserialize<IEnumerable<Forum>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                foreach (var forum in forums)
                {
                    Console.WriteLine("  " + forum.Title);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Forum GET failure reason : " + response.ReasonPhrase);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static async Task AddForum(HttpClient client, string title)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // HTTP POST
            var forum = new Forum { Title = title };
            string json = JsonSerializer.Serialize<Forum>(forum, new JsonSerializerOptions { DictionaryKeyPolicy = JsonNamingPolicy.CamelCase });
            var response = await client.PostAsync("/api/Forum", new StringContent(json, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Forum POST failure reason : " + response.ReasonPhrase);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void ClearScreen()
        {
            Console.Clear();
            Console.WriteLine("QA Forums");
            Console.WriteLine("=========");
            Console.WriteLine();
        }

        static int GetInteger(string message)
        {
            int result;

            Console.Write(message);
            string input = Console.ReadLine();

            while (!int.TryParse(input, out result))
            {
                Console.Write("That is not a valid number, try again: ");
                input = Console.ReadLine();
            }

            return result;
        }
    }
}
