using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api")]
    public class AttendenceController : ApiController
    {
        [Route("Attendence/{location}/Today")]
        public IEnumerable<string> Get(string location)
        {
            BsfEntities db = new BsfEntities();
            string today = DateTime.Now.ToShortDateString();
            var students = (from att in db.Attedences
                            where att.Location == location && att.CheckInDate == today
                            select att).Select(att => att.Student).ToList();
            return students;
        }

        [Route("Attendence/{student}/Year/{year}")]
        public IEnumerable<string> Get(string student, int year)
        {
            BsfEntities db = new BsfEntities();
            DateTime yearStart = DateTime.Parse(string.Format("{0}/9/1", year));
            DateTime yearEnd = DateTime.Parse(string.Format("{0}/9/1", year + 1));
            var students = (from att in db.Attedences
                            where att.Student == student
                                && att.CheckInTimeStamp > yearStart
                                && att.CheckInTimeStamp < yearEnd
                            select att).Select(att => att.CheckInDate).ToList();
            return students;
        }
    }
}
