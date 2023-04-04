using Idata.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idata.Entities.Idhl.ViewModels
{

    public class Week
    {
        public DateTime? _startDate { get; }
        public DateTime? _endDate { get; }

        public Week(DateTime? startDate)
        {
            _startDate = startDate;
            _endDate = startDate.Value.AddDays(6);
        }

    }
    public class SCReportViewModel
    {

        public List<Week?>? weeks { get; set; } = new();
        public List<Staff?>? staffings { get; set; } = new();
        public List<ScoreCard?>? scoreCards { get; set; } = new();

        //start date of entire report.
        public DateTime? startDate { get; set; }

        //end date of entire report.
        public DateTime? endDate { get; set; }

        //WeekCount of dates
        public int? weekCount { get; set; }

        public int? daysCount { get; set; }


        //Una lista del repositorio Y se tiene los staffs, 


        //Entonces ir dato scoreCard


        //Ordenar por fecha desde la antigua a la mas actual
        public SCReportViewModel(List<Staff?>? staffings, List<ScoreCard?>? scoreCards)
        {
            //Get the first sunday of that week
            startDate = scoreCards.FirstOrDefault()?.date.AddDays(-(int)scoreCards.FirstOrDefault().staff.day_of_week);

            //Get the last saturday of list
            endDate = scoreCards.LastOrDefault()?.date.AddDays(6 - (int)scoreCards.LastOrDefault().staff.day_of_week);

            //Get week count substracting endDate with StartDate and always round up
            weekCount = Convert.ToInt32(Math.Ceiling((decimal)(endDate - startDate)?.Days / 7));

            daysCount = Convert.ToInt32((int)(endDate - startDate)?.Days);

            this.staffings = staffings;
            this.scoreCards = scoreCards;

            var weekDateStart = startDate;

            for (int i = 1; i <= weekCount; i++)
            {
                Week currentWeek = new(weekDateStart);
                weeks.Add(currentWeek);
                weekDateStart = weekDateStart?.AddDays(7);

            }


        }
    }
}
