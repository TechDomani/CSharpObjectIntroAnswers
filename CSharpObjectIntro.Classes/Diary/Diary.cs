using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpObjectIntro.Classes.Diary
{
    public class Diary
    {
        //Fields
        private readonly List<DiaryEvent> _diaryEvents = new();

        //Constructor
        public Diary(string name)
        {
            Name = name;
        }

        // Properties
        public string Name { get; private set; }

        public void AddEvent(DateOnly date, int hours, string description, string location, int duration, int minutes=0)
        {
            var time = new TimeOnly(hours, minutes);
            var diaryEvent = new DiaryEvent(date, time, duration, description, location);
            _diaryEvents.Add(diaryEvent);
        }

        public int CheckDiary(DateOnly date)
        {
            return _diaryEvents.Count(diaryEvent => diaryEvent.Date == date);
        }

		// Add a new method called check morning events
		public int CheckMorningEvents(DateOnly date)
		{
			return _diaryEvents.Count(diaryEvent => diaryEvent.Date == date && diaryEvent.IsMorning);
		}



	}
}
