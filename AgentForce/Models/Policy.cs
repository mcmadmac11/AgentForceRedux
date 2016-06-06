using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgentForce.Models
{
    public class Policy
    {
        public int Id { get; set; }
        [DisplayName("Policy Name")]
        public string Name { get; set; }

        [DisplayName("Monthly Premium")]
        [DataType(DataType.Currency)]
        public decimal Premium { get; set; }

        [DisplayName("Annual Deductible")]
        [DataType(DataType.Currency)]
        public decimal Deductible { get; set; }

        [DisplayName("Co-Insurance Amount")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public decimal? CoInsurance { get; set; }
        [DisplayName("Max Out-Of-Pocket")]
        [DataType(DataType.Currency)]
        public decimal Out_Of_Pocket_Max { get; set; }

        [DisplayName("Co-Pay Amount")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [DataType(DataType.Currency)]
        public decimal? CoPay { get; set; }
        public int CompanyId { get; set; }
        public string ClientId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}