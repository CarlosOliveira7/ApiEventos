using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public class Event
    {


        public Event()
        {
            Speakers = new List<EventSpeaker>();
            isDeleted = false;

        }

        public int id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool isDeleted { get; set; }

        
        public string StartDateString { get; set; }

    
        public string EndDateString { get; set; }

        List<EventSpeaker> Speakers { get; set; }

        public void Update(string? title, string? description, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            EndDate = endDate;
            StartDate = startDate;
        }



        public void Delete()
        {
            isDeleted = true;
        }
    }


}