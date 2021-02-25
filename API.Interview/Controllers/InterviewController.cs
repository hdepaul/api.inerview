using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Interview.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewController : ControllerBase
    {
       
        private readonly ILogger<InterviewController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public InterviewController(ILogger<InterviewController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Returns random five time slots
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DateTime> Get(DateTime selectedDate, int duration)
        {
            Random random = new Random();
            var result = new List<DateTime>();
            
            // TODO get timeframe avalilabilty from some storage (DB)
            TimeSpan start = TimeSpan.FromHours(8);
            TimeSpan end = TimeSpan.FromHours(18);

            int maxHours = (int)((end - start).TotalHours);
            var slotCount = maxHours * (60 / duration);

            result.Add(selectedDate + start);
            TimeSpan t = start.Add(TimeSpan.FromMinutes(duration));

            for (int i = 0; i < slotCount; ++i)
            {
                result.Add(selectedDate + t);
                t = t.Add(TimeSpan.FromMinutes(duration));
            }

            Random rnd = new Random();
            var randomList = result.OrderBy(item => rnd.Next());
            var onlyFiveItems = randomList.Take(5);

            return onlyFiveItems.OrderBy(x => x);
        }

    }
}
