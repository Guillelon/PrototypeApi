using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PrototypeApi.Controllers
{
    public class TeamsController : Controller
    {
        TeamRepository teamRepository;

        public TeamsController() 
        {
            this.teamRepository = new TeamRepository();
        }

        public ActionResult Get() 
        {
            var allTeams = teamRepository.GetAll();
            var jsondata = new { teams = allTeams };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        public HttpStatusCode Add(Team team) 
        {
            teamRepository.Add(team);
            return HttpStatusCode.Accepted;
        }
    }
}
