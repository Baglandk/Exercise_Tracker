
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ExersiceModel;

namespace Operations_list
{
    internal class Operations
    {
        private static HttpClient client { get; set; } = new HttpClient();
        public static void BasicInfo()
        {
            client.BaseAddress = new Uri("https://localhost:7045/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        internal static async Task<IEnumerable<ExersiceDTO>> GetAllAsync()
        {

            using (HttpResponseMessage responce = await client.GetAsync("api/excercise"))
            {
                responce.EnsureSuccessStatusCode();
                if (responce.IsSuccessStatusCode)
                {
                    var shiftItems = await responce.Content.ReadFromJsonAsync<IEnumerable<ExersiceDTO>>();
                    return shiftItems;
                }
                else
                {
                    throw new Exception(responce.ReasonPhrase);
                }
            }
        }
        internal static async Task<ExersiceDTO> GetOneAsync()
        {
            System.Console.WriteLine("Which one you want to see:");
            int id = Convert.ToInt32(System.Console.ReadLine());
            using (HttpResponseMessage responce = await client.GetAsync($"api/excercise/{id}"))
            {
                responce.EnsureSuccessStatusCode();
                if (responce.IsSuccessStatusCode)
                {
                    var shiftItem = await responce.Content.ReadFromJsonAsync<ExersiceDTO>();
                    return shiftItem;
                }
                else
                {
                    throw new Exception(responce.ReasonPhrase);
                }
            }
        }
        internal static async Task PostAsync()
        {
            ExersiceDTO shift = ExersiceDTO.GenerateShift();
            var stringContent = new StringContent(JsonConvert.SerializeObject(shift), Encoding.UTF8, "application/json");
            using (HttpResponseMessage responce = await client.PostAsync($"api/excercise", stringContent))
            {
                responce.EnsureSuccessStatusCode();
                if (responce.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("The shift was successfully added");
                }
                else
                {
                    Console.WriteLine("Could not add the shift");
                }
            }
        }

        internal static async Task UpdateAsync()
        {
            System.Console.WriteLine("Which one you want to update:");
            int id = Convert.ToInt32(System.Console.ReadLine());

            ExersiceDTO shift = ExersiceDTO.GenerateShift();
            var stringContent = new StringContent(JsonConvert.SerializeObject(shift), Encoding.UTF8, "application/json");

            using (HttpResponseMessage responce = await client.PutAsync($"api/excercise/{id}", stringContent))
            {
                responce.EnsureSuccessStatusCode();
                if (responce.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("The entity was updated");
                }
                else
                {
                    Console.WriteLine("No result found");
                }
            }

        }
        internal static async Task DeleteAsync()
        {
            System.Console.WriteLine("Which one you want to delete:");
            int id = Convert.ToInt32(System.Console.ReadLine());
            using (HttpResponseMessage responce = await client.DeleteAsync($"api/excercise/{id}"))
            {
                responce.EnsureSuccessStatusCode();

                if (responce.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Successfully Deleted");
                }
                else
                {
                    Console.WriteLine("No result found");
                }
            }
        }
    }
}