using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace DemoDashboardDevice.Models
{
    public class Tools
    {
        static string RutaAPIHost = Environment.GetEnvironmentVariable("API");
        public static List<Person> GetListEmployee(List<Person> employee)
        {
            Dictionary<int, string> company_name = new Dictionary<int, string>();
            try
            {
                HttpClient client = GetClientForAPI("", "Obtener empleados");
                var response = client.GetAsync($"https://{RutaAPIHost}/employees").GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Library.WriteInfoLog(responseBody);
                    employee = JsonSerializer.Deserialize<List<Person>>(responseBody);
                    foreach (var em in employee)
                    {
                        em.name = Normalizar(em.name);
                    }
                }
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog("Exception en GetListEmployee2");
                Library.WriteErrorLog(ex);
            }
            return employee;
        }
        public static List<Device> GetListDevice(List<Device> devices)
        {
            List<Device> dvList = new List<Device>();
            try
            {
                HttpClient client = GetClientForAPI("", "Obtener Terminales");
                var response = client.GetAsync($"https://{RutaAPIHost}/devices").GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Library.WriteInfoLog(responseBody);
                    dvList = JsonSerializer.Deserialize<List<Device>>(responseBody);
                }
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog("Exception en TerminalesAPI");
                Library.WriteErrorLog(ex);
            }
            return devices;
        }
        private static Person GetPersonAPI(int id)
        {
            Person person = new Person();
            HttpClient client = GetClientForAPI("", $"Obtener Persona: {id}");
            var response = client.GetAsync($"https://{RutaAPIHost}/employees/" + id).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                person = JsonSerializer.Deserialize<Person>(responseBody);
            }
            else
            {
                string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Library.WriteErrorLog($"Exception en GetPersonAPI con responseBody: {System.Environment.NewLine} {responseBody},{System.Environment.NewLine} Respuesta :{System.Environment.NewLine} {response}");
                return null;
            }
            return person;
        }
        public static HttpClient GetClientForAPI(string json, string comment, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            HttpClient client;
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "kqrTnH7KGFQXSybAkuK6rx7q3tCJZZTQ");
                var productValue = new ProductInfoHeaderValue("Demo", "1.0");
                client.DefaultRequestHeaders.UserAgent.Add(productValue);
            }
            catch (Exception ex)
            {
                client = null;
                Library.WriteErrorLog($"Exception en {memberName} al: {comment}");
                Library.WriteErrorLog(ex);
            }
            return client;
        }
        public static string Normalizar(string texto,int max = 24)
        {
            if (texto.Length > 24)
            {
                texto = texto.Substring(0, 24);
            }
            return texto;
        }
        public static string SinTildes(string texto) =>
            new String(
                texto.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray()
            )
            .Normalize(NormalizationForm.FormC);
    }
}
