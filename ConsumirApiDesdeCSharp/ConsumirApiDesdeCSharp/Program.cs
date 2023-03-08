using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ConsumirApi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ApiGet_Obtener();
            ApiPost_Insert();
            ApiPut_Update();
            ApiPatch_Update();
            ApiDelete_Delete();
        }

        private static void ApiGet_Obtener()
        {
            using (var client = new HttpClient())
            {
                string urlApi = "https://jsonplaceholder.typicode.com";

                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Add("Authorization", "sssadajhjakh446");

                //var response = client.GetAsync(urlApi + "/posts/1");
                var responseResult = client.GetAsync(urlApi + "/posts/1").Result;

                //var res = response.Result.Content.ReadAsStringAsync().Result;
                var resResult = responseResult.Content.ReadAsStringAsync().Result;

                dynamic r = JObject.Parse(resResult);

                Console.WriteLine(resResult);
                Console.WriteLine("\b");
                Console.WriteLine(r);
            }
        }

        private static void ApiPost_Insert()
        {
            using (var client = new HttpClient())
            {
                var urlApi = "https://jsonplaceholder.typicode.com";

                client.DefaultRequestHeaders.Clear();

                var parametros = "{'title': 'Codigo con C#', 'body': 'Bienvenidos al curso', 'userId': 23}";

                dynamic jsonString = JObject.Parse(parametros);

                var httpContent = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");
                var response = client.PostAsync(urlApi + "/posts/", httpContent).Result;

                var res = response.Content.ReadAsStringAsync().Result;

                dynamic r = JObject.Parse(res);

                Console.WriteLine(r);
            }
        }

        private static void ApiPut_Update()
        {
            using (var client = new HttpClient())
            {
                var urlApi = "https://jsonplaceholder.typicode.com";

                client.DefaultRequestHeaders.Clear();

                var parametros = "{'title': 'Codigo ACTUALIZADO mediante PUT'}";

                dynamic jsonString = JObject.Parse(parametros);

                var httpContent = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");
                var response = client.PutAsync(urlApi + "/posts/1", httpContent).Result;

                var res = response.Content.ReadAsStringAsync().Result;

                dynamic r = JObject.Parse(res);

                Console.WriteLine(r);
            }
        }

        private static void ApiPatch_Update()
        {
            using (var client = new HttpClient())
            {
                var urlApi = "https://jsonplaceholder.typicode.com";

                client.DefaultRequestHeaders.Clear();

                var parametros = "{'title': 'Codigo ACTUALIZADO mediante PATCH'}";

                dynamic jsonString = JObject.Parse(parametros);

                var httpContent = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");
                var response = client.PatchAsync(urlApi + "/posts/1", httpContent).Result;

                var res = response.Content.ReadAsStringAsync().Result;

                dynamic r = JObject.Parse(res);

                Console.WriteLine(r);
            }
        }

        private static void ApiDelete_Delete()
        {
            using (var client = new HttpClient())
            {
                var urlApi = "https://jsonplaceholder.typicode.com";

                client.DefaultRequestHeaders.Clear();

                var response = client.DeleteAsync(urlApi + "/posts/1").Result;

                var res = response.Content.ReadAsStringAsync().Result;

                dynamic r = JObject.Parse(res);

                Console.WriteLine(r);
            }
        }
    }
}