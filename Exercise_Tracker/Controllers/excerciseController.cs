using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exercise_Tracker.Data;
using Exercise_Tracker.Models;
using Exercise_Tracker.Repository;

namespace Exercise_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class excerciseController : ControllerBase
    {
        private readonly IRepository<Exercise , int> ExerciseRepository;

        public excerciseController(IRepository<Exercise, int> ExerciseRepository)
        {
            this.ExerciseRepository = ExerciseRepository;
        }

        // GET: api/excercise
        [HttpGet]
        public async Task<IEnumerable<Exercise>> Getexercises()
        {
            Task<IEnumerable<Exercise>> task = ExerciseRepository.GetAll();
            return await task;
        }

        // GET: api/excercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {

            return await ExerciseRepository.GetById(id);
        }

        // PUT: api/excercise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task PutExercise(int id, Exercise exercise)
        {
            await ExerciseRepository.Update(exercise, id);
            await ExerciseRepository.Save();
        }

        // POST: api/excercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostExercise(Exercise exercise)
        {
            await ExerciseRepository.Insert(exercise);
            await ExerciseRepository.Save();
        }

        // DELETE: api/excercise/5
        [HttpDelete("{id}")]
        public async Task DeleteExercise(int id)
        {
            await ExerciseRepository.Delete(id);
            await ExerciseRepository.Save();
        }
    }
}
