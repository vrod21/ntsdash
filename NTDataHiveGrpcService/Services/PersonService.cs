using Grpc.Core;
using NLog;
using NTDataHiveGrpcService.BLL.RecordInterfaces;
using NTDataHiveGrpcService.BLL.RecordRepository;
using System.Reflection;

namespace NTDataHiveGrpcService.Services
{
    public class PersonService : PersonBackend.PersonBackendBase
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IPersonRecordRepository _personRecordRepository;

        public PersonService(IPersonRecordRepository personRecordRepository)
        {
            _personRecordRepository = personRecordRepository;

            _nlog.Info("{0} started", Assembly.GetExecutingAssembly().GetName().Version);            
        }

        #region SavePerson
        public override Task<Google.Rpc.Status> SavePerson(PersonRequest request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WebId))
                    return Task.FromResult(new Google.Rpc.Status { Code = 3, Message = "WebID is missed" });

                var personRecord = new BLL.RecordContents.PersonFilter(request);

                _personRecordRepository.SavePersonRecord(personRecord);

                return Task.FromResult(new Google.Rpc.Status { Code = 0 });
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new Google.Rpc.Status { Code = 2, Message = ex.Message });
            }
        }
        #endregion

        #region GetAll
        public override Task<PersonArray> GetAllPerson(PersonEmpty request, ServerCallContext context)
        {
            try
            {
                var record = new PersonArray();
                record.Status = new Google.Rpc.Status { Code = 0, Message = "Person is queryable." };

                var list = _personRecordRepository.GetAllRecord();

                record.Items.Add(list);

                return Task.FromResult(record);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new PersonArray { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
            }
        }
        #endregion

        #region GetPerson
        
        #endregion

        #region GetPersonRecord
        public override Task<PersonRequest> GetPersonRecord(PersonRecordFilter request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WebId))
                    return Task.FromResult(new PersonRequest { Status = new Google.Rpc.Status { Code = 3, Message = "WebId missed" } });

                if (_personRecordRepository.GetRecord(request.WebId, out BLL.RecordContents.PersonFilter personFilter))
                {
                    var personList = personFilter.personRequest;
                    personList.Status = new Google.Rpc.Status() { Code = 0, Message = "Person Record found" };
                    return Task.FromResult(personList);
                }
                else
                {
                    var personList = new PersonRequest();
                    personList.Status = new Google.Rpc.Status { Code = 5, Message = "Person Record not found" };
                    return Task.FromResult(personList);
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex.Message);
                return Task.FromResult(new PersonRequest { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
            }
        }
        #endregion
    }
}
