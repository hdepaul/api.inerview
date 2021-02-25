using System;
using System.Collections.Generic;

namespace API.Interview
{
    public class InterviewViewModel
    {
        public InterviewViewModel()
        {
            Dates = new List<DateTime>();
        }
        public List<DateTime> Dates { get; set; }

    }
}
