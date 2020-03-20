using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Models
{
    public class SportTree
    {
        public int SportId { get; set; }
        public string SportName { get; set; }
        public string Logo { get; set; }

        public SportTree(int id,string sportName,string logoUrl)
        {
            SportId = id;
            SportName = sportName;
            Logo = logoUrl;
        }
    }
}
