using System;
using Exercise_Tracker.Data;
using Exercise_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_Tracker.Repository
{
    public class ExerciseRepository : IRepository<Exercise, int>
    {
        private readonly ExerciseContext _context;
        public ExerciseRepository(ExerciseContext context)
        {
            _context = context;
        }
        public async Task Delete(int Id)
        {
            var Exercise = await _context.exercises.FindAsync(Id);
            _context.exercises.Remove(Exercise);
        }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _context.exercises.ToListAsync();
        }

        public async Task<Exercise> GetById(int Id)
        {
            return await _context.exercises.FindAsync(Id);
        }

        public async Task Insert(Exercise t1)
        {
            await _context.exercises.AddAsync(t1);
        }

        public async Task Update(Exercise t1, int Id)
        {
            if(t1.Id!=Id)
            {
                throw new InvalidOperationException("The modify id should by same as the searched Id");
            }
            _context.Entry(t1).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(Id))
                {
                    throw new InvalidOperationException("The Id does not exist");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        private bool ExerciseExists(int id)
        {
            return (_context.exercises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

