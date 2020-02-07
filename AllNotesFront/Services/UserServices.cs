using AllNotesFront.Helpers;
using AllNotesFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AllNotesFront.Services
{
    public class UserServices
    {
        private HttpClient _client { get; }

        public UserServices(HttpClient client)
        {
            
            this._client = HttpClientHelper.GetClient(client,"account");
        }
        public async Task GetAllAsync()
        {
            var client = new HttpClient();
            var loginResponse = await client.PostAsync("http://yourdomain.com/api/account/login?username=theUsername&password=thePassword", null);
            if (!loginResponse.IsSuccessStatusCode)
            {
                //handle unsuccessful login
            }

            var response = await client.GetAsync("http://yourdomain.com/api/anEndpointThatRequiresASignedInUser/");
        }

        public async Task<String> Login(LoginViewModel model)
        {


            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            HttpClient client;
            client = new HttpClient(handler);
            client.BaseAddress = HttpClientHelper.GetCustomUri("Account");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);


            StringContent content = HttpClientHelper.ConfigContext(model);
            var loginResponse =await client.PostAsync("Login", content);


            //var authCookies = cookies.GetCookies(HttpClientHelper.GetDomainUri()).Cast<Cookie>();
            //var authCookie = cookies.GetCookies(HttpClientHelper.GetDomainUri()).Cast<Cookie>().Single(cookie => cookie.Name == "auth_cookie");
            var authCookie = cookies.GetCookies(HttpClientHelper.GetDomainUri()).Cast<Cookie>().Single();

            //HttpClientHelper.SetCookie(authCookies.ToString());
            HttpClientHelper.SetCookie(authCookie);


            string loginResult = loginResponse.Content.ReadAsStringAsync().Result;
            
            ResultViewModel result = JsonConvert.DeserializeObject<ResultViewModel>(loginResult);

            if (result.Status == Status.Success)
            {
                //HttpResponseMessage getResponse = client.GetAsync("/api/values").Result;

                ////ViewData["message"] = 
                //    return JsonConvert.DeserializeObject<string>(getResponse.Content.ReadAsStringAsync().Result);
                return "Success";
            }
            else
            {
                //ViewData["message"] =
                    return "Error while calling Web API!";
            }

            //return View();
        }
    

        public async Task Func()
        {
            CookieContainer cookieContainer = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer
            };
            handler.CookieContainer = cookieContainer;
            var client = new HttpClient(handler);

            var loginResponse = await client.PostAsync("http://yourdomain.com/api/account/login?username=theUsername&password=thePassword", null);
            if (!loginResponse.IsSuccessStatusCode)
            {
                //handle unsuccessful login
            }
            var authCookie = cookieContainer.GetCookies(HttpClientHelper.GetDomainUri()).Cast<Cookie>().Single(cookie => cookie.Name == "auth_cookie");
            //Save authCookie.ToString() somewhere
            //authCookie.ToString() -> auth_cookie=CfDJ8J0_eoL4pK5Hq8bJZ8e1XIXFsDk7xDzvER3g70....
            cookieContainer.SetCookies(new Uri("http://yourdomain.com"), "auth_cookie=CfDJ8J0_eoL4pK5Hq8bJZ8e1XIXFsDk7xDzvER3g70...");
        }

        //public async Task<ResultViewModel> Login(LoginViewModel login)
        //{
        //    return result;
        //    //var ser = new ByteArrayContent(JsonConvert.SerializeObject(LoginViewModel login));
        //    //var response = await _client.PostAsync("Login",login);
        //    //var content = response.Content;
        //    //var stringContent = await content.ReadAsStringAsync();
        //    //var result = JsonConvert.DeserializeObject<IList<ScheduleViewModel>>(stringContent);
        //    //return result;
        //}






        //public async Task<IList<ScheduleViewModel>> GetAllAsync()
        //{

        //    var response = await _schedule.GetAsync("GetAllSchedules");
        //    var content = response.Content;
        //    var stringContent = await content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<IList<ScheduleViewModel>>(stringContent);
        //    return result;
        //}
    }
}
