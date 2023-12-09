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
        private ConcurrentDictionary<string, RecordContents.FeedbackFilter> _feedbackRecordCache = new ConcurrentDictionary<string, RecordContents.FeedbackFilter>();

        public PreEditingFeedbackRecordRepository(IPreEditingFeedbackRecordPersistence feedbackRecordPersistence)
        {
            _feedbackRecordPersistence = feedbackRecordPersistence;
        }

        #region SavePreEditingFeedbackRecor
        public void SavePreEditingFeedbackRecord(RecordContents.FeedbackFilter feedbackRecord)
        {
            if (_feedbackRecordCache.ContainsKey(feedbackRecord.Webid))
            {
                _feedbackRecordCache.TryRemove(feedbackRecord.Webid, out RecordContents.FeedbackFilter preEditFilter);

                if (!_feedbackRecordCache.TryAdd(feedbackRecord.Webid, preEditFilter))
                    throw new Exception($"Pre-Editing Record couldn't add to the rules: {feedbackRecord.Webid}");

                _nlog.Trace("Webid {0} Update is Cache", feedbackRecord.Webid);
            }
            else
            {
                if (_feedbackRecordCache.TryAdd(feedbackRecord.Webid, feedbackRecord))
                    _nlog.Trace($"Webid {feedbackRecord.Webid} Added in Cache");
                else
                    _nlog.Warn($"Webid {feedbackRecord.Webid} 2nd try to add");
            }

            _feedbackRecordPersistence.Save(feedbackRecord);
            _nlog.Trace($"Webid {feedbackRecord.Webid} saved in gap");
        }
        #endregion

        #region GetAllRecord
        public List<PreEditingFeedbackRecordRequest> GeAllRecord()
        {
            List<PreEditingFeedbackRecordRequest> preEditedList = _feedbackRecordPersistence.GetAllPreEdited();

            _nlog.Trace("Pre-Edited is order by name");

            return preEditedList;
        }
        #endregion
    }
}
