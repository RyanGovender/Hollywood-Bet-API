using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HollywoodBets.Models.Custom_Models
{
    public class MarektBetTypeViewModel
    {
        [Key]
        public int MarketBetTypeId { get; set; }
        public string BetTypeName { get; set; }
        public string MarketName { get; set; }
    }
}
