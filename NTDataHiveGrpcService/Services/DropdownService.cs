using Grpc.Core;
using NLog;
using NTDataHiveGrpcService.BLL.RecordInterfaces;
using System.Reflection;

namespace NTDataHiveGrpcService.Services
{
    public class DropdownService : DropdownbackBackend.DropdownbackBackendBase
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IDropdownRecordRepository _dropdownRecordRepository;

        public DropdownService(BLL.RecordInterfaces.IDropdownRecordRepository dropdownRecordRepository)
        {
            _dropdownRecordRepository = dropdownRecordRepository;

            _nlog.Info("{0} started", Assembly.GetExecutingAssembly().GetName().Version);            
        }

        #region GetAll
        //public override Task<PublisherNameArray> GetPublisherName(PublisherNameEmpty request, ServerCallContext context)
        //{
        //    try
        //    {
        //        var record = new PublisherNameArray();

        //        record.Status = new Google.Rpc.Status { Code = 0, Message = "Publisher is queryable." };

        //        var allRecord = _dropdownRecordRepository.GetAllRecord();


        //        foreach (var item in allRecord)
        //        {
        //            record.Items.Add(new PublisherRecordRequest);
        //        }                

        //        return Task.FromResult(record);
        //    }
        //    catch (Exception ex)
        //    {
        //        _nlog.Fatal(ex);
        //        return Task.FromResult(new PublisherNameArray { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
        //    }
        //}
        #endregion
    }
}
