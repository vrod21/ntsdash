using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using NLog;
using System;
using System.Reflection;

namespace NTDataHiveGrpcService.Services
{
    public class EmployeeService : EmployeeBackend.EmployeeBackendBase
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly BLL.RecordInterfaces.IEmployeeRecordRepository _employeeRecordRepository;

        public EmployeeService(BLL.RecordInterfaces.IEmployeeRecordRepository employeeRecordRepository)
        {
            _employeeRecordRepository = employeeRecordRepository;

            _nlog.Info("{0} started", Assembly.GetExecutingAssembly().GetName().Version);
        }

        #region GetAll
        public override Task<EmployeeArray> GetAll(EmployeeEmpty request, ServerCallContext context)
        {
            try
            {
                var record = new EmployeeArray();
                record.Status = new Google.Rpc.Status { Code = 0, Message = "Rule is queryable." };

                var allRecord = _employeeRecordRepository.GetAllRecord();

                record.Items.Add(allRecord);

                return Task.FromResult(record);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new EmployeeArray { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
            }
        }
        #endregion

        public override Task<Google.Rpc.Status> SaveEmployee(EmployeeRecordRequest request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WebId))
                    return Task.FromResult(new Google.Rpc.Status { Code = 3, Message = "WebID is missed" });

                var studentRecord = new BLL.RecordContents.EmployeeFilter(request);

                _employeeRecordRepository.SaveEmployeeRecord(studentRecord);

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
