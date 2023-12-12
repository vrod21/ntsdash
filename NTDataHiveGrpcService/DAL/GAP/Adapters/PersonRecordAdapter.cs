using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.BLL.RecordContents;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Model;

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
                        FirstName = recordRequest.FirstName,
                        LastName = recordRequest.LastName,
                        Position = recordRequest.Position,
                        CompanyId = recordRequest.CompanyId,
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

        #region GetAllPersonRecord
        internal List<PersonNotExistRequest> GetAllPersonRecord()
        {
            List<PersonNotExistRequest> personRecord = new List<PersonNotExistRequest>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var record = from person in dbContext.Person
                          orderby person.FirstName
                          select CreateBNewBllPerson(person);

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

        #region SelectRevision
        internal bool SelectPersonPart(PersonNotExistRequest recordRequest)
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

                    recordRequest.Username = personList.Username?.Trim() ?? "";
                    recordRequest.EmailAddress = personList.EmailAddress.Trim() ?? "";
                    recordRequest.FirstName = personList.FirstName?.Trim() ?? "";
                    recordRequest.LastName = personList.LastName?.Trim() ?? "";
                    recordRequest.Birthday = personList.Birthday.ToUniversalTime().ToTimestamp();
                    recordRequest.Position = personList.Position?.Trim() ?? "";
                    recordRequest.CompanyId = personList.CompanyId?.Trim() ?? "";

                    //if (personList.FirstName != null)
                    //    recordRequest.FirstName = personList.FirstName?.Trim() ?? "";
                    //if (personList.LastName != null)
                    //    recordRequest.LastName = personList.LastName?.Trim() ?? "";
                    //if (personList?.Birthday != null)
                    //    recordRequest.Birthday = personList.Birthday.ToUniversalTime().ToTimestamp();
                    //if (personList.Position != null)
                    //    recordRequest.Position = personList.Position?.Trim() ?? "";
                    //if (personList.CompanyId != null)
                    //    recordRequest.CompanyId = personList.CompanyId?.Trim() ?? "";

                    return true;
                }
                else
                {
                    _nlog.Error($"Webid {recordRequest.WebId} duplicate rule");
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



        #region CreateNewBllPerson
        private static PersonNotExistRequest CreateBNewBllPerson(Person person)
        {
            return new PersonNotExistRequest()
            {
                WebId = person.WebId,
                Username = person.Username,
                EmailAddress = person.EmailAddress,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birthday = person.Birthday.ToUniversalTime().ToTimestamp(),
                Position = person.Position,
                CompanyId = person.CompanyId,
            };
        }
        #endregion
    }
}
