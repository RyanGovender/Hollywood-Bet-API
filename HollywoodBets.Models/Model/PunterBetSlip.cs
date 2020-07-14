using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HollywoodBets.Models.Model
{
    public class PunterBetSlip
    {
        [Key]
        public int PunterBetSlipID { get; set; }
        public float Payout { get; set; }
        public float Stake { get; set; }
        public int NumberOfLegs { get; set; }
        public DateTime DateTake { get; set; }

        [ForeignKey("AccountNumber")]
        public int AccountNumber { get; set; }

        public virtual AccountDetails AccountDetails { get; set; }
    }
}
