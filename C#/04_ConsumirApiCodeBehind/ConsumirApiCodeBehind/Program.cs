using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using RestSharp;

namespace ConsumirApi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region HttpClient

            ApiGet_Obtener();
            ApiPost_Insert();
            ApiPut_Update();
            ApiPatch_Update();
            ApiDelete_Delete();

            #endregion HttpClient

            #region RestClient

            GetItem_ObtenerId(10);
            GetItems_ObtenerTodos();
            PostItem_Insertar();
            PostItem_InsertarConJson();

            #endregion RestClient
        }

        #region HttpClient

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

        #endregion HttpClient

        #region RestClient

        private static void GetItem_ObtenerId(int id)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest($"todos/{id}", Method.Get);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private static void GetItems_ObtenerTodos()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest($"todos", Method.Get);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private static void PostItem_Insertar()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest($"posts", Method.Post);

            request.AddParameter("title", "Codigo titulo");
            request.AddParameter("body", "bodysss");

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private static void PostItem_InsertarConJson()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest($"posts", Method.Post);

            request.AddJsonBody(new { title = "titulo nuevo", body = "nombre de Body", uerId = 999 });

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        #endregion RestClient
    }
}