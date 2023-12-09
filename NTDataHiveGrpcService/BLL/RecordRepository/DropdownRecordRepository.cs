using NLog;
using NTDataHiveGrpcService.BLL.RecordInterfaces;
using NTDataHiveGrpcService.DAL.GAP.Persistence;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;
using System.Collections.Concurrent;

namespace NTDataHiveGrpcService.BLL.RecordRepository
{
    public class DropdownRecordRepository : IDropdownRecordRepository
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IDropdownRecordPersistence _dropdownRecordPersistence;


        public DropdownRecordRepository(IDropdownRecordPersistence dropdownRecordPersistence)
        {
            _dropdownRecordPersistence = dropdownRecordPersistence;
        }

        #region GetAllRecord
        public List<BLL.RecordContents.FeedbackComparable> GetAllRecord()
        {
            var publisherRecordRequest = _dropdownRecordPersistence.GetAllPublisher();

            _nlog.Trace("Publisher are order by name");

            return publisherRecordRequest;
        }
        #endregion
    }
}
