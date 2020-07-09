using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models.Model
{ 
    public class TestTable
    {
        [Key]
        public int TestID { get; set; }
        public string TestData { get; set; }
        public string TestStuff { get; set; }
    }
}
