using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api")]
    public class CheckInController : ApiController
    {
        [Route("CheckIn/{student}/Location/{location}")]
        public void Put(string student, string location)
        {
            BsfEntities db = new BsfEntities();

            var today = DateTime.Today.ToShortDateString();

            var checkin = (from a in db.Attedences
                           where a.Student == student && a.CheckInDate == today
                           select a).ToList();

            if (checkin.Count == 0)
            {
                Attedence att = new Attedence
                {
                    Student = student,
                    Location = location,
                    CheckInDate = DateTime.Now.ToShortDateString(),
                    CheckInTimeStamp = DateTime.Now
                };

                db.Attedences.Add(att);
                db.SaveChanges();
            }
        }
    }
}
