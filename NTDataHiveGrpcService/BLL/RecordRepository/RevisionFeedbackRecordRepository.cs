using NLog;
using NTDataHiveGrpcService.BLL.RecordInterfaces;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;
using System.Collections.Concurrent;

namespace NTDataHiveGrpcService.BLL.RecordRepository
{
    public class RevisionFeedbackRecordRepository : IRevisionFeedbackRecordRepository
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IRevisionFeedbackRecordPersistence _feedbackRecordPersistence;
        private ConcurrentDictionary<string, RecordContents.RevisionFeedbackFilter> _feedbackRecordCache = new ConcurrentDictionary<string, RecordContents.RevisionFeedbackFilter>();

        public RevisionFeedbackRecordRepository(IRevisionFeedbackRecordPersistence feedbackRecordPersistence)
        {
            _feedbackRecordPersistence = feedbackRecordPersistence;
        }

        #region SaveRevisioningFeedbackRecor
        public void SaveRevisionFeedbackRecord(RecordContents.RevisionFeedbackFilter revisionRecord)
        {
            if (_feedbackRecordCache.ContainsKey(revisionRecord.Webid))
            {
                _feedbackRecordCache.TryRemove(revisionRecord.Webid, out RecordContents.RevisionFeedbackFilter revisionFilter);

                if (!_feedbackRecordCache.TryAdd(revisionRecord.Webid, revisionFilter))
                    throw new Exception($"Pre-Editing Record couldn't add to the rules: {revisionRecord.Webid}");

                _nlog.Trace("Webid {0} Update is Cache", revisionRecord.Webid);
            }
            else
            {
                if (_feedbackRecordCache.TryAdd(revisionRecord.Webid, revisionRecord))
                    _nlog.Trace($"Webid {revisionRecord.Webid} Added in Cache");
                else
                    _nlog.Warn($"Webid {revisionRecord.Webid} 2nd try to add");
            }

            _feedbackRecordPersistence.Save(revisionRecord);
            _nlog.Trace($"Webid {revisionRecord.Webid} saved in gap");
        }
        #endregion

        #region GetAllRecord
        public List<RecordContents.FeedbackComparable> GeAllRecord()
        {
            List<RecordContents.FeedbackComparable> revisionedList = _feedbackRecordPersistence.GetAllRevision();

            _nlog.Trace("Pre-Edited is order by name");

            return revisionedList;
        }
        #endregion

        #region GetRecord
        public bool GetRecord(string WebId, out RecordContents.RevisionFeedbackFilter revisionFilter)
        {
            if (WebId == null)
            {
                _nlog.Fatal("Attempting to find a Rule Record with WebId == NULL in the repo.");
                revisionFilter = new RecordContents.RevisionFeedbackFilter(Guid.NewGuid().ToString());
                return false;
            }

            if (_feedbackRecordCache.TryGetValue(WebId, out RecordContents.RevisionFeedbackFilter revisionFromCache))
            {
                revisionFilter = revisionFromCache;
                return true;
            }

            if (_feedbackRecordPersistence.SelectById(WebId, out RecordContents.RevisionFeedbackFilter revisionFromDB))
            {
                _feedbackRecordCache.TryAdd(WebId, revisionFromDB);
                revisionFilter = revisionFromDB;
                return true;
            }

            revisionFilter = new RecordContents.RevisionFeedbackFilter(WebId);
            return false;
        }
        #endregion
    }
}
