using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentForce.Models;
using AgentForce.Controllers;
using AgentForce;

namespace sandbox
{
    public static class Program
    {
        private static ApplicationUser user;
        static void Main(string[] args)
        {
            var Users = new List<ApplicationUser>()
            {
                new ApplicationUser {RoleName = "Client", Email = "testclient@test.com", Id = Guid.NewGuid().ToString() },
                new ApplicationUser {RoleName = "Agent", Email = "testagent@test.com", Id = Guid.NewGuid().ToString() }
            };

            ClientViewModel clientVM = new ClientViewModel();
            user = new ApplicationUser();
            List<ApplicationUser> clients = new List<ApplicationUser>();
            List<ApplicationUser> agents = new List<ApplicationUser>();

            var allUsers = from r in Users
                           select r;

            var clientId = from x in Users
                           where x.RoleName.Equals("Client")
                           select x.Id;

            clientVM.ClientId = clientId.ToString();
            StringBuilder sb = new StringBuilder();

            foreach (var c in clientId)
            {
                sb.Append(c);
                Console.WriteLine(c);
            }

            Console.WriteLine(sb);

            foreach (var u in allUsers)
            {
                if (u.RoleName == "Client")
                {
                    clients.Add(u);
                    Console.WriteLine("client emails: " + u.Email);
                }
                else if (u.RoleName == "Agent")
                {
                    agents.Add(u);
                    Console.WriteLine("agent emails: " + u.Email);
                }
            }
        }

    }
}
