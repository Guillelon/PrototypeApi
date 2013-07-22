using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PrototypeApi.Controllers
{
    public class TeamsController : ApiController
    {
        ITeamRepository teamRepository;

        public TeamsController() 
        {
            this.teamRepository = new TeamRepository();
        }

        public List<Team> Get() 
        {
            var allTeams = teamRepository.GetAll();
            return allTeams.ToList();
        }

        public HttpResponseMessage Add(Team team) 
        {
            if (team.Country == "Colombia" || team.Country == "Venezuela")
            {
                teamRepository.Add(team);
                var response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Add("Location", "api/team/add/" + team.Id.ToString());
                return response;
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }
    }
}
