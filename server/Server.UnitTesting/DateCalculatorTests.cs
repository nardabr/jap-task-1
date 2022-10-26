using NUnit.Framework;
using Server.Core.Entities;
using Server.Core.Helpers;
using Assert = NUnit.Framework.Assert;

namespace Server.UnitTesting
{
    [TestFixture]
    public class DateCalculatorTests
    {
        [Test]
        public void Convert6WorkingHours()
        {
            var test6 = DateCalculator.ConvertHoursToDays(6);

            Assert.AreEqual(test6, (0, 6));
        }

        [Test]
        public void ConvertWorkingHoursNegativeValue()
        {
            var ex = Assert.Throws<Exception>(() => DateCalculator.ConvertHoursToDays(-1));

            Assert.That(ex.Message, Is.EqualTo("Work hours can`t be less than 1"));
        }

        [Test]
        public void GenerateDatesForLectureEvents()
        {
            var selectionStartDate = new DateTime(2022, 10, 12);

            var lectureEvents = new List<LectureEvent>
                {
                   new LectureEvent { OrderNumber = 1, WorkHours = 12, StartDate = new DateTime(), EndDate = new DateTime()},
                   new LectureEvent { OrderNumber = 2, WorkHours = 16, StartDate = new DateTime(), EndDate = new DateTime()},
                   new LectureEvent { OrderNumber = 3, WorkHours = 8, StartDate = new DateTime(), EndDate = new DateTime()},
                };

            DateCalculator.CalculateDates(selectionStartDate, lectureEvents);

            Assert.AreEqual(lectureEvents[0].StartDate, selectionStartDate);
            Assert.AreEqual(lectureEvents[0].EndDate, new DateTime(2022, 10, 13));

            Assert.AreEqual(lectureEvents[1].StartDate, lectureEvents[0].EndDate);
            Assert.AreEqual(lectureEvents[1].EndDate, new DateTime(2022, 10, 15));

            Assert.AreEqual(lectureEvents[2].StartDate, lectureEvents[1].EndDate);
            Assert.AreEqual(lectureEvents[2].EndDate, new DateTime(2022, 10, 16));
        }

        [Test]
        public void GenerateDatesForLectureEventsEmptyList()
        {
            var selectionStartDate = new DateTime(2022, 10, 12);

            var lectureEvents = new List<LectureEvent>
            {
            };

            var ex = Assert.Throws<Exception>(() => DateCalculator.CalculateDates(selectionStartDate, lectureEvents));
            Assert.That(ex.Message, Is.EqualTo("Minimun 1 lecture or event for this function to run"));
        }
    }
}