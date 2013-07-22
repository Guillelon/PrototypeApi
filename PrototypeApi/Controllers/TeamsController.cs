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

        public HttpStatusCode Add(Team team) 
        {
            if (team.Country == "Colombia" || team.Country == "Venezuela")
            {
                teamRepository.Add(team);
                return HttpStatusCode.Accepted;
            }
            else
                return HttpStatusCode.BadRequest;
        }
    }
}
