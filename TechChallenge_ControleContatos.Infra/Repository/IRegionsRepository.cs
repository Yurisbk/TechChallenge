using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;

namespace TechChallenge_ControleContatos.Infra.Repository
{
    public interface IRegionsRepository
    {
        Task<Regions> GetRegionByDdd(string ddd);
    }
}
