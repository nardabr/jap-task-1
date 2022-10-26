using Server.Core.Entities;

namespace Server.Core.Helpers
{
    public class DateCalculator
    {
        public static (int, int) ConvertHoursToDays(int workHours)
        {
            if (workHours < 1) throw new Exception("Work hours can`t be less than 1");

            int days = 0;
            do
            {
               if(workHours >= 8)
                {
                    workHours = workHours - 8;
                    days++;
                }
            } while (workHours >= 8);

            int hours = workHours;

            return (days, hours);
        }

        public static void CalculateDates(DateTime selectionStartDate, List<LectureEvent> lectureEvents)
        {
            if(lectureEvents.Count < 1) throw new Exception("Minimun 1 lecture or event for this function to run");

            var remainingHours = 0;
            for (int i = 0; i < lectureEvents.Count; i++)
            {
                var convertedHours = ConvertHoursToDays(lectureEvents[i].WorkHours + remainingHours);
                var days = convertedHours.Item1;
                var hours = convertedHours.Item2;

                if (i == 0)
                {
                    lectureEvents[i].StartDate = selectionStartDate;
                    lectureEvents[i].EndDate = lectureEvents[i].StartDate.AddDays(days);
                    
                } else
                {
                    lectureEvents[i].StartDate = lectureEvents[i - 1].EndDate;
                    lectureEvents[i].EndDate = lectureEvents[i].StartDate.AddDays(days);
                }
              remainingHours = hours;

            }
        }
    }
}
