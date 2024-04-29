using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge_ControleContatos.Infra.Entity
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string passwordvalue { get; set; }
        public RolesTypes roletype { get; set; }
    }

    public enum RolesTypes
    {
        Admin,
        Employee
    }

    public static class Roles
    {
        public const string Admin = "Administrator";
        public const string NotAdmin = "Employee";
    }
}
