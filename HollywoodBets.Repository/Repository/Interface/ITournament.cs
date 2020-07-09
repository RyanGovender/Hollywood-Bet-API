﻿
using HollywoodBets.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Interface
{
    public interface ITournament
    {
        Tournament GetTournament(int?tournamentId);
        IQueryable<Tournament> GetAllTournamentsForSportBasedOnCountry(int?sportId,int?countryId);
    }
}