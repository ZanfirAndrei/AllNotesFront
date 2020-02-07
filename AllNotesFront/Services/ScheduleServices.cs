using AllNotesFront.Helpers;
using AllNotesFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AllNotesFront.Services
{
    public class ScheduleServices
    {
        private HttpClient _schedule { get; }

        public ScheduleServices(HttpClient schedule)
        {
            //schedule.BaseAddress = HttpClientHelper.GetCustomUri("schedule");
            this._schedule = HttpClientHelper.GetClient(schedule, "schedule");

        }

        public async Task<IList<ScheduleViewModel>> GetAllAsync()
        {
            var response = await _schedule.GetAsync("GetAllSchedules");
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IList<ScheduleViewModel>>(stringContent);
            return result;
        }

        public async Task<string> CreateAsync(string schedule)
        {
            string data = JsonConvert.SerializeObject(schedule);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = string.Empty;
            var result = await _schedule.PostAsync("AddSchedule", content);
            if (result.IsSuccessStatusCode)
            {
                response = result.StatusCode.ToString();
            }
            return response;
        }
    }
}
