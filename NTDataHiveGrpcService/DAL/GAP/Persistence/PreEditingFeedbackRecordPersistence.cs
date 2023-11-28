﻿using NLog;
using NTDataHiveGrpcService.DAL.GAP.Adapters;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;

namespace NTDataHiveGrpcService.DAL.GAP.Persistence
{
    public class PreEditingFeedbackRecordPersistence : IPreEditingFeedbackRecordPersistence
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;

        public PreEditingFeedbackRecordPersistence(IConfiguration config)
        {
            _config = config;
        }

        #region Save
        public bool Save(BLL.RecordContents.PreEditingFeedbackFilter feedbackRecord)
        {
            var createRecord = new PreEditingFeedbackRecordAdapter(_config);

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
    }
}