using AllNotesFront.Helpers;
using AllNotesFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AllNotesFront.Services
{
    public class ExerciseServices
    {
        //private HttpClient _exercise { get; }

        //public ExerciseServices(HttpClient exercise)
        //{
        //    exercise.BaseAddress = HttpClientHelper.GetCustomUri("exercise");
        //    this._exercise = exercise;

        //}

        //public async Task<IList<ExerciseViewModel>> GetAllAsync()
        //{
        //    var response = await _exercise.GetAsync("GetAllExercises");
        //    var content = response.Content;
        //    var stringContent = await content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<IList<ExerciseViewModel>>(stringContent);
        //    return result;
        //}

        //public async Task<ExerciseViewModel> GetById(int id)
        //{
        //    var response = await _exercise.GetAsync("GetAllExercises/"+id);
        //    var content = response.Content;
        //    var stringContent = await content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<IList<ExerciseViewModel>>(stringContent);
        //    return result;
        //}
    }
}
