using NLog;
using NTDataHiveGrpcService.DAL.GAP.Adapters;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;

namespace NTDataHiveGrpcService.DAL.GAP.Persistence
{
    public class DropdownRecordPersistence : IDropdownRecordPersistence
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;

        public DropdownRecordPersistence(IConfiguration config)
        {
            _config = config;
        }

        #region GetAllPublisher
        public List<BLL.RecordContents.FeedbackComparable> GetAllPublisher()
        {
            var selectPublisher = new FeedbackRecordAdapter(_config).GetAllDropdownRecord();

            if (selectPublisher.Count() > 1)
            {
                return selectPublisher;
            }

            return selectPublisher;
        }
        #endregion

    }
}
