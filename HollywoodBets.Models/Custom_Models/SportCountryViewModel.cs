using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HollywoodBets.Models.Custom_Models
{
    public class SportCountryViewModel
    {
        [Key]
        public int SportCountryId { get; set; }
        public string CountryName { get; set; }
        public string SportName { get; set; }
        public int SportId { get; set; }
        public int CountryId { get; set; }

    }
}
