using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_ControleContatos.Infra.Entity;
using TechChallenge_ControleContatos.Infra.Mapping;

namespace TechChallenge_ControleContatos.Infra.Repository
{
    public class RegionsRepository : IRegionsRepository
    {
        private readonly IDbConnection _dbContext;
        public RegionsRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Regions> GetRegionByDdd(string ddd)
        {
            var query = "SELECT * FROM region WHERE ddd = @ddd;";

            var parameters = new { ddd = ddd };

            var result = await _dbContext.QueryAsync<Regions>(query, parameters);

            return result?.FirstOrDefault();
        }
    }
}
