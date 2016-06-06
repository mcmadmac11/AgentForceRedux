using AgentForce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentForce.Models
{
    public class ClientViewModel
    {

        public string ClientId { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        public int PolicyId { get; set; }
        public string AgentId { get; set; }
        public Policy Policy { get; set; }
        public List<Policy> Policies { get; set; }
        public string RoleName { get; set; }
        public ApplicationUser User { get; set; }

        public ClientViewModel()
        {

        }
    }
}
