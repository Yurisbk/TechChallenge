using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechChallenge_ControleContatos.Infra.Entity
{
    public class Regions
    {
        public int id { get; set; }
        public string ddd { get; set; }
        public string region { get; set; }
    }
}
