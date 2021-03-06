﻿using AllNotesFront.Helpers;
using AllNotesFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AllNotesFront.Services
{
    public class ScheduleServices
    {
        private HttpClient _schedule { get; }

        public ScheduleServices(HttpClient schedule)
        {
            schedule.BaseAddress = HttpClientHelper.GetCustomUri("schedule");
            this._schedule = schedule;

        }

        public async Task<IList<ScheduleViewModel>> GetAllAsync()
        {

            var response = await _schedule.GetAsync("GetAllSchedules");
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IList<ScheduleViewModel>>(stringContent);
            return result;
        }
    }
}
