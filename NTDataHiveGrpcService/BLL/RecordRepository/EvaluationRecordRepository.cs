using NLog;
using NTDataHiveGrpcService.BLL.RecordInterfaces;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;
using System.Collections.Concurrent;

namespace NTDataHiveGrpcService.BLL.RecordRepository
{
    public class EvaluationRecordRepository : IEvaluationRecordRepository
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IEvaluationRecordPersistence _evaluationRecordPersistence;
        private ConcurrentDictionary<string, RecordContents.EvaluationFilter> _feedbackRecordCache = new ConcurrentDictionary<string, RecordContents.EvaluationFilter>();

        public EvaluationRecordRepository(IEvaluationRecordPersistence evaluationRecordPersistence)
        {
            _evaluationRecordPersistence = evaluationRecordPersistence;
        }

        #region SaveRevisioningFeedbackRecord
        public void SaveEvaluationFeedbackRecord(RecordContents.EvaluationFilter evaluationRecord)
        {
            if (_feedbackRecordCache.ContainsKey(evaluationRecord.Webid))
            {
                _feedbackRecordCache.TryRemove(evaluationRecord.Webid, out RecordContents.EvaluationFilter evaluationFilter);

                if (!_feedbackRecordCache.TryAdd(evaluationRecord.Webid, evaluationFilter))
                    throw new Exception($"Pre-Editing Record couldn't add to the rules: {evaluationRecord.Webid}");

                _nlog.Trace("Webid {0} Update is Cache", evaluationRecord.Webid);
            }
            else
            {
                if (_feedbackRecordCache.TryAdd(evaluationRecord.Webid, evaluationRecord))
                    _nlog.Trace($"Webid {evaluationRecord.Webid} Added in Cache");
                else
                    _nlog.Warn($"Webid {evaluationRecord.Webid} 2nd try to add");
            }

            _evaluationRecordPersistence.Save(evaluationRecord);
            _nlog.Trace($"Webid {evaluationRecord.Webid} saved in gap");
        }
        #endregion

        #region GetAllRecord
        public List<NTDataHiveGrpcService.FeedbackRecordRequest> GetAllRecord()
        {
            List<NTDataHiveGrpcService.FeedbackRecordRequest> feedbackList = _evaluationRecordPersistence.GetFeedbackRecords();

            _nlog.Trace("Feedback is order by name");

            return feedbackList;
        }
        #endregion

        #region GetFeedbackByEmployeeName
        public List<FeedbackRecordRequest> GetRecordByEmployeeName(RecordContents.EvaluationFilter evaluationFilter)
        {
            List<FeedbackRecordRequest> feedbackList = _evaluationRecordPersistence.GetFeedBackByEmployeeName(evaluationFilter);

            _nlog.Trace("Feedback is order by name");

            return feedbackList;
        }
        #endregion

        #region GetRecord
        public bool GetRecord(string webId, out RecordContents.EvaluationFilter evaluationFilter)
        {
            if (webId == null)
            {
                _nlog.Fatal("Attempting to find a feedback record with webId == NULL in the repo.");
                evaluationFilter = new RecordContents.EvaluationFilter(Guid.NewGuid().ToString());
                return false;
            }
            if (_feedbackRecordCache.TryGetValue(webId, out RecordContents.EvaluationFilter feedbackFromCache))
            {
                evaluationFilter = feedbackFromCache;
                return true;
            }

            if (_evaluationRecordPersistence.SelectById(webId, out RecordContents.EvaluationFilter feedbackFromDB))
            {
                _feedbackRecordCache.TryAdd(webId, feedbackFromDB);
                evaluationFilter = feedbackFromDB;
                return true;
            }

            evaluationFilter = new RecordContents.EvaluationFilter(webId);
            return false;
        }
        #endregion
    }
}
