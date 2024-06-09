using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.Service.Interface;

namespace TechChallenge_ControleContatos.Service.Service
{
    public class RegionsService : IRegionsService
    {
        private readonly IRegionsRepository _regions;
        public RegionsService(IRegionsRepository regions)
        {
            _regions = regions;
        }

        public async Task<Regions> GetRegionByDdd(string ddd)
        {
            return await _regions.GetRegionByDdd(ddd);
        }
    }
}
