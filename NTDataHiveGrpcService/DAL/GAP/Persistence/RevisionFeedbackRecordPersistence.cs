using NLog;
using NTDataHiveGrpcService.DAL.GAP.Adapters;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;

namespace NTDataHiveGrpcService.DAL.GAP.Persistence
{
    public class RevisionFeedbackRecordPersistence : IRevisionFeedbackRecordPersistence
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;

        public RevisionFeedbackRecordPersistence(IConfiguration config)
        {
            _config = config;
        }

        #region Save
        public bool Save(BLL.RecordContents.RevisionFeedbackFilter feedbackRecord)
        {
            var createRecord = new RevisionFeedbackRecordAdapter(_config);

            int feedbackId = createRecord.GetFeedbackByWebId(feedbackRecord.feedbackRecordRequest.WebId);

            if (feedbackId == 0)
            {
                createRecord.Insert(feedbackRecord.feedbackRecordRequest);
            }
            else
            {
                return false;
            }

            return true;
        }
        #endregion

        #region GetAll
        public List<BLL.RecordContents.FeedbackComparable> GetAllRevision()
        {
            var selectRevision = new RevisionFeedbackRecordAdapter(_config).GetAllRevisionFeedbackRecord();

            if (selectRevision.Count > 0)
            {
                return selectRevision;
            }

            _nlog.Error($"The Selected revision value {selectRevision} is null");

            return selectRevision;
        }
        #endregion

        #region SelectById
        public bool SelectById(string webid, out BLL.RecordContents.RevisionFeedbackFilter revisionRecord)
        {
            if (CreateRevisionRecordByWebId(webid, out BLL.RecordContents.RevisionFeedbackFilter revisionRecordLocal))
            {
                revisionRecord = revisionRecordLocal;
                return true;
            }
            else
            {
                revisionRecord = new BLL.RecordContents.RevisionFeedbackFilter(webid);
                return false;
            }
        }
        #endregion

        #region CreateRevisionRecordByWebId
        private bool CreateRevisionRecordByWebId(string webid, out BLL.RecordContents.RevisionFeedbackFilter revisionRecord) 
        {
            revisionRecord = new BLL.RecordContents.RevisionFeedbackFilter(webid);

            var revisionAdapter= new RevisionFeedbackRecordAdapter(_config);

            if (!revisionAdapter.SelectREvisionPart(revisionRecord.feedbackRecordRequest))
                return false;

            return true;
        }

        #endregion
    }
}
