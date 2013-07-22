using PrototypeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrototypeApi
{
    public class TeamRepository : ITeamRepository
    {
        TeamDB context;

        public TeamRepository() 
        {
            this.context = new TeamDB();
        }

        public List<Team> GetAll() 
        {
            var allTeams = context.Teams;
            return allTeams.ToList();
        }

        public Team Add(Team team) 
        {
            context.Teams.Add(team);
            context.SaveChanges();
            return team;
        }
    }
}