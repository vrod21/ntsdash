﻿using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.BLL.RecordContents;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Mapper;
using NTDataHiveGrpcService.DAL.Model;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters
{
    public class PersonRecordAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;
        private readonly CreateNewPersonMapper _mapper;

        public PersonRecordAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
            _mapper = new CreateNewPersonMapper();
        }

        #region InsertPerson
        internal void Insert(PersonRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                if (recordRequest != null)
                {
                    var emp = new Model.Person()
                    {
                        WebId = recordRequest.WebId,
                        EmailAddress = recordRequest.EmailAddress,
                        FirstName = recordRequest.FirstName,
                        LastName = recordRequest.LastName,
                        FullName = $"{recordRequest.FirstName} {recordRequest.LastName}",
                        Position = recordRequest.Position,
                        CompanyId = recordRequest.CompanyId,
                        AccountName = recordRequest.AccountName,
                        ReportingManager = recordRequest.ReportingManager,
                        Department = recordRequest.Department,
                        Type = recordRequest.Type,
                    };

                    dbContext.Person.Add(emp);
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

        #region UpdatePerson
        internal void UpdatePerson(PersonRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);

                var persons = from per in dbContext.Person
                             where per.WebId == recordRequest.WebId
                             select per;

                var person = persons.Single();

                person.FirstName = recordRequest.FirstName.Trim();
                person.LastName = recordRequest.LastName.Trim();
                person.FullName = $"{recordRequest.FirstName.Trim()} {recordRequest.LastName.Trim()}".Trim();
                person.Birthday = recordRequest.Birthday.ToDateTime();
                person.Position = recordRequest.Position.Trim();
                person.CompanyId = recordRequest.CompanyId.Trim();
                person.AccountName = recordRequest.AccountName.Trim();
                person.ReportingManager = recordRequest.ReportingManager.Trim();
                person.Department = recordRequest.Department.Trim();

                dbContext.Person.Update(person);
                _ = dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }
        #endregion

        #region GetAllPersonRecord
        internal List<PersonRequest> GetAllPersonRecord()
        {
            List<PersonRequest> personRecord = new List<PersonRequest>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var record = from person in dbContext.Person
                          orderby person.FirstName
                          select _mapper.CreateNewPesonMapper(person);

                if (record != null)
                {
                    return record.ToList();
                }

            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }

            return personRecord;
        }
        #endregion

        #region GetPersonByType
        internal List<PersonRequest> GetPersonByTypeRecord()
        {
            List<PersonRequest> personRecord = new List<PersonRequest>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var personType = (from type in dbContext.Person
                                  where type.Type == "Operator"
                                  orderby type.FirstName
                                  select _mapper.CreateNewPesonMapper(type)).ToList();

                if (personType.Count > 0)
                {
                    return personType;
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");                
            }
            return personRecord;
        }
        #endregion

        #region SelectPersonPart
        internal bool SelectPersonPart(PersonRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);

                var personRecord = (from person in dbContext.Person
                                      where person.WebId == recordRequest.WebId
                                      select person).ToList();

                if (personRecord.Count == 0)
                {
                    throw new Exception("There is no value");
                }
                else if (personRecord.Count == 1)
                {
                    var personList = personRecord[0];

                    recordRequest.EmailAddress = personList.EmailAddress.Trim() ?? "";
                    recordRequest.FirstName = personList.FirstName?.Trim() ?? "";
                    recordRequest.LastName = personList.LastName?.Trim() ?? "";
                    recordRequest.FullName = $"{personList.FirstName.Trim()} {personList.LastName.Trim()}".Trim();
                    recordRequest.Birthday = personList.Birthday.ToUniversalTime().ToTimestamp();
                    recordRequest.Position = personList.Position?.Trim() ?? "";
                    recordRequest.CompanyId = personList.CompanyId?.Trim() ?? "";
                    recordRequest.AccountName = personList.AccountName?.Trim() ?? "";
                    recordRequest.ReportingManager = personList.ReportingManager?.Trim() ?? "";
                    recordRequest.Department = personList.Department?.Trim() ?? "";
                    recordRequest.Type = personList.Type?.Trim() ?? "";
                    return true;
                }
                else
                {
                    _nlog.Error($"Webid {recordRequest.WebId} duplicate person");
                    return false;
                }
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
                var getPersonById = from person in dbContext.Person
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

        #region GetPersonByReportingManager
        internal List<PersonRequest> GetPersonByReportingManagerRecord(string feedbackRecord)
        {
            List<PersonRequest> personRequests = new List<PersonRequest>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var personRecord = (from person in dbContext.Person
                                    where person.ReportingManager == feedbackRecord
                                    orderby person.FirstName
                                    select _mapper.CreateNewPesonMapper(person)).ToList();

                if (personRecord.Count > 0)
                {
                    return personRecord;
                }

            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }

            return personRequests;
        }
        #endregion
    }
}
