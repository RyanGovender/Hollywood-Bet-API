using Dapper;
using HollywoodBets.DAL;
using HollywoodBets.Models.Custom_Models;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HollywoodBets.Repository.Repository.Implementation
{
    public class TournamentRepository : ITournament
    {
        public bool Add(Tournament item)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.TournamentName
                };

                var result = connection.Execute("sp_AddTournament", parameters, commandType: CommandType.StoredProcedure);

                return result < 0;
            }
        }

        public bool AddSportTournamentCountry(SportTournament sportTournament)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    sportTournament.SportId,
                    sportTournament.TournamentId,
                    sportTournament.CountryId
                };

                var result = connection.Execute("sp_AddSportCountry", parameters, commandType: CommandType.StoredProcedure);
                return result < 0;
            }
        }

        public bool Delete(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { tournamentID = id };
                var affectedRows = connection.Execute("sp_DeleteTournament", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows < 0;
            }
        }

        public Tournament Find(int? id)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    Id = id
                };
                var result = connection.Query<Tournament>("sp_GetATournament", parameters, commandType: CommandType.StoredProcedure);
                return result.Any() ? result.FirstOrDefault() : null;
            }
        }

        public IQueryable<Tournament> GetAll()
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                return connection.Query<Tournament>("sp_GetAllTournaments", commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IQueryable<SportCountryTournamentVM> GetAllSportTournmentCountries()
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                return connection.Query<SportCountryTournamentVM>("sp_GetSportCountryTournaments", commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IQueryable<Tournament> GetAllTournamentsForSportBasedOnCountry(int? sportId, int? countryId)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { sportId,countryId };
                return connection.Query<Tournament>("GetTournamentBasedOnSportAndCountry",parameters,commandType:CommandType.StoredProcedure).AsQueryable();
            }
        }

        public Tournament GetTournament(int? tournamentId)
        {
            using(var connection = DatabaseService.SqlConnection())
            {
                var parameters = new { tournamentId };
                var result = connection.Query<Tournament>("GetTournament", parameters, commandType: CommandType.StoredProcedure).First();
                return result != null ? result : null;
            }
        }

        public bool Update(Tournament item)
        {
            using (var connection = DatabaseService.SqlConnection())
            {
                var parameters = new
                {
                    item.TournamentId,
                    item.TournamentName
                };
                var affectedRows = connection.Execute("sp_UpdateTournament", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows < 0;
            }
        }
    }
}
