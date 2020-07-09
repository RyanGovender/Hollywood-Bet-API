
using HollywoodBets.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.DAL
{
    public interface IDb
    {
        HollywoodBetsDBContext dBContext();
    }
}
