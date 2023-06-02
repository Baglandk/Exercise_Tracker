using System;
using Exercise_Tracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace Exercise_Tracker.Models
{
	public class Exercise
	{
        public int Id { get; set; }
		public string comment { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }


        public TimeSpan Duration {
			get { return DateEnd - DateStart; }
		}
    }
}

