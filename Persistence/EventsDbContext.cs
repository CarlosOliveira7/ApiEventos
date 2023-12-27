using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models;

namespace MyApi.Persistence
{
    public class EventsDbContext
    {
          public  List<Event> EventsList {get; set;}

          public EventsDbContext()
            {
                EventsList = new List<Event>();
            }
    
    }
}