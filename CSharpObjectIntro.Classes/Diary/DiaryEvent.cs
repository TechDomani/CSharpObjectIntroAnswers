using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpObjectIntro.Classes.Diary
{
    public class DiaryEvent
    {
        // Fields 
        private TimeOnly _lunchTime = new(12, 0);

        // Properties
        public DateOnly Date { get; private set; }
        public TimeOnly Time { get; private set; }
        public int Duration { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }

        public bool IsMorning
        {
            get
            {
                return Time < _lunchTime;
            }
        }

        // Constructor
        public DiaryEvent(DateOnly date, TimeOnly time, int duration, string description, string location)
        {
            Date = date;
            Time = time;
            Duration = duration;
            Description = description;
            Location = location;
        }
    }
}
