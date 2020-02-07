using AllNotesFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AllNotesFront.Helpers
{
    public static class HttpClientHelper
    {
        //private const string _domainPath = "https://localhost:44342";
        private const string _basePath = "https://localhost:44342/api/";
        private static CookieContainer _cookieContainer { get; set; } 
        public static Uri GetCustomUri(string path)
        {
            return new Uri(_basePath + path + "/");
        }

        public static Uri GetDomainUri()
        {
            return new Uri(_basePath);
        }


        public static HttpClient GetClient(HttpClient client, string path)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.UseCookies = true;
            
            if (_cookieContainer != null && !_cookieContainer.GetCookies(GetDomainUri()).Equals("") )
            {
                var a = _cookieContainer.GetCookies(GetDomainUri());
                clientHandler.CookieContainer = _cookieContainer;
            }
            else
            {
                clientHandler.CookieContainer = new CookieContainer( );
            }
            
            client = new HttpClient(clientHandler);
            client.BaseAddress = GetCustomUri( path);
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            return client;
        }

        public static void SetCookie(Cookie cookie)//string value)
        {
            _cookieContainer = new CookieContainer();
            _cookieContainer.SetCookies(GetDomainUri(), "auth_cookie=" + cookie.Value );
            //_cookieContainer.Add(cookie);
        }

        //public static async Task<string> Login(LoginViewModel model)
        //{
        //    HttpClient client;

        //    HttpClientHandler clientHandler = new HttpClientHandler();
        //    clientHandler.UseCookies = true;

        //    if (_cookieContainer.GetCookies(GetDomainUri()).Equals("") || _cookieContainer != null)
        //    {
        //        clientHandler.CookieContainer = _cookieContainer;
        //    }
        //    else
        //    {
        //        clientHandler.CookieContainer = new CookieContainer();
        //    }

        //    client = new HttpClient(clientHandler);
        //    client.BaseAddress = GetCustomUri("account");
        //    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
        //    client.DefaultRequestHeaders.Accept.Add(contentType);



        //    StringContent content = HttpClientHelper.ConfigContext(model);
        //    var loginResponse = await client.PostAsync("Login", content);

        //    var authCookie = _cookieContainer.GetCookies(GetDomainUri()).Cast<Cookie>().Single(cookie => cookie.Name == "auth_cookie");


        //    string loginResult = loginResponse.Content.ReadAsStringAsync().Result;

        //    ResultViewModel result = JsonConvert.DeserializeObject<ResultViewModel>(loginResult);

        //    if (result.Status.Equals("Success"))

        //    {
        //        //HttpResponseMessage getResponse = client.GetAsync("/api/values").Result;

        //        ////ViewData["message"] = 
        //        //    return JsonConvert.DeserializeObject<string>(getResponse.Content.ReadAsStringAsync().Result);
        //        return "Success";
        //    }
        //    else
        //    {
        //        //ViewData["message"] =
        //        return "Error while calling Web API!";
        //    }
        //}
        
        public static StringContent ConfigContext(object obj)
        {
            string loginData = JsonConvert.SerializeObject( obj );

            return new StringContent(
                loginData, System.Text.Encoding.UTF8, "application/json");
        }
    }
}
