using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpObjectIntro.Classes.Diary;
using System;

namespace CSharpObjectIntro.Tests
{
    [TestClass]
    public class DiaryTests
    {
        [TestMethod]
        public void TestDiaryName()
        {
            var diary = new Diary("Bob Smith");
            Assert.AreEqual("Bob Smith", diary.Name);
        }

		[TestMethod]
		public void TestDiaryEventCount()
		{
			Diary diary = new ("Bob Smith");
            DateOnly christmasEve = new (2023, 12, 24);
            diary.AddEvent(christmasEve, 19, "Carol Concert", "All Saints Church", 60);
			diary.AddEvent(christmasEve, 10, "Collect Shopping", "Marks and Spencer, Kew", 30);
            int eventCount = diary.CheckDiary(christmasEve);
            Assert.AreEqual(2, eventCount);
		}

        // Add test method for checking the diary for morning events
	}
}