using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrototypeApi
{
    public interface ITeamRepository
    {
        List<Team> GetAll();
        Team Add(Team team);
    }
}