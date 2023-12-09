using NLog;
using NTDataHiveGrpcService.BLL.RecordInterfaces;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;
using System.Collections.Concurrent;

namespace NTDataHiveGrpcService.BLL.RecordRepository
{
    public class PreEditingFeedbackRecordRepository : IPreEditingFeedbackRecordRepository
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IPreEditingFeedbackRecordPersistence _feedbackRecordPersistence;
        private ConcurrentDictionary<string, RecordContents.PreEditingFeedbackFilter> _feedbackRecordCache = new ConcurrentDictionary<string, RecordContents.PreEditingFeedbackFilter>();

        public PreEditingFeedbackRecordRepository(IPreEditingFeedbackRecordPersistence feedbackRecordPersistence)
        {
            _feedbackRecordPersistence = feedbackRecordPersistence;
        }

        #region SavePreEditingFeedbackRecor
        public void SavePreEditingFeedbackRecord(RecordContents.PreEditingFeedbackFilter preEditRecord)
        {
            if (_feedbackRecordCache.ContainsKey(preEditRecord.Webid))
            {
                _feedbackRecordCache.TryRemove(preEditRecord.Webid, out RecordContents.PreEditingFeedbackFilter preEditFilter);

                if (!_feedbackRecordCache.TryAdd(preEditRecord.Webid, preEditFilter))
                    throw new Exception($"Pre-Editing Record couldn't add to the rules: {preEditRecord.Webid}");

                _nlog.Trace("Webid {0} Update is Cache", preEditRecord.Webid);
            }
            else
            {
                if (_feedbackRecordCache.TryAdd(preEditRecord.Webid, preEditRecord))
                    _nlog.Trace($"Webid {preEditRecord.Webid} Added in Cache");
                else
                    _nlog.Warn($"Webid {preEditRecord.Webid} 2nd try to add");
            }

            _feedbackRecordPersistence.Save(preEditRecord);
            _nlog.Trace($"Webid {preEditRecord.Webid} saved in gap");
        }
        #endregion

        #region GetAllRecord
        public List<RecordContents.FeedbackComparable> GeAllRecord()
        {
            List<RecordContents.FeedbackComparable> preEditedList = _feedbackRecordPersistence.GetAllPreEdited();

            _nlog.Trace("Pre-Edited is order by name");

            return preEditedList;
        }
        #endregion
    }
}
