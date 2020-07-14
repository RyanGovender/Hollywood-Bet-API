using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HollywoodBets.Models.Model
{
   public class AccountDetails
    {
        [Key]
        public int AccountNumber { get; set; }
        public HashSet<string> Password { get; set; }
        public float Balance { get; set; }
    }
}
