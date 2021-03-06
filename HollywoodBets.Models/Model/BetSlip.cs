﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models.Model
{
    public class BetSlip
    {
        [Key]
        public int id { get; set; }
        public string typeOfEvent { get; set; }
        public Event @event { get; set; }
        public string punterBetSelection { get; set; }
        public float selctionOdds { get; set; }

        [ForeignKey("PunterBetSlipID")]
        public int PunterBetSlipID { get; set; }
        public virtual PunterBetSlip PunterBetSlip { get; set; }
      
    }
}
