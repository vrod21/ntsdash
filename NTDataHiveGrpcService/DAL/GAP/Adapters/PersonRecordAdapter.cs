﻿using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters
{
    public class PersonRecordAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;

        public PersonRecordAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        #region InsertPerson
        internal void InserPerson(PersonNotExistRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                if (recordRequest != null)
                {
                    var emp = new Model.Person()
                    {
                        WebId = recordRequest.WebId,
                        Username = recordRequest.Username,
                        EmailAddress = recordRequest.EmailAddress,
                    };

                    dbContext.Persons.Add(emp);
                }
                _ = dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }
        #endregion

        #region GetPersonByWebId
        internal int GetPersonByWebId(string webid)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var getPersonById = from person in dbContext.Persons
                                      where person.WebId == webid
                                      select person;

                if (getPersonById.Count() > 0)
                    return getPersonById.FirstOrDefault().Id;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return 0;
            }
        }
        #endregion

    }
}
