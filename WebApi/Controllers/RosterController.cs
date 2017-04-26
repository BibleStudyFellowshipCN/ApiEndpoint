using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api")]
    public class RosterController : ApiController
    {
        [Route("Roster/{year}/Location/{location}")]
        public IEnumerable<string> Get(int year, string location)
        {
            BsfEntities db = new BsfEntities();
            DateTime yearStart = DateTime.Parse(string.Format("{0}/9/1", year));
            DateTime yearEnd = DateTime.Parse(string.Format("{0}/9/1", year + 1));
            var roster = (from att in db.Attedences
                          where att.Location == location
                            && att.CheckInTimeStamp > yearStart
                            && att.CheckInTimeStamp < yearEnd
                          select att).Select(att => att.Student).Distinct().ToList();
            return roster;
        }
    }
}
