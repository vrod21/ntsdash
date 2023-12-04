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

        public override Task<Google.Rpc.Status> SavePersonNotExist(PersonNotExistRequest request, ServerCallContext context)
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
    }
}
