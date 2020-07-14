using HollywoodBets.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HollywoodBets.Models.Custom_Models
{
   public class BetSlipViewModel
    {
        public BetSlip [] betSlips { get; set; }
        public PunterBetSlip PunterBetSlip { get; set; }
    }
}
