using NLog;
using NTDataHiveGrpcService;

namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class PreEditingFeedbackFilter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        public string Webid { get; set; }

        private PreEditingFeedbackRecordRequest _request;

        public PreEditingFeedbackRecordRequest feedbackRecordRequest
        {
            get { return _request; }
            set
            {
                Webid = _request.WebId;
                _request = value;
            }
        }

        public PreEditingFeedbackFilter(string webid)
        {
            if (string.IsNullOrEmpty(webid))
                _nlog.Error("Employee record created with an empty webId");

            Webid = webid;
            _request = new PreEditingFeedbackRecordRequest();
            _request.WebId = webid;
        }

        public PreEditingFeedbackFilter(PreEditingFeedbackRecordRequest request)
        {
            _request = request;
            Webid = request.WebId;
        }
    }
}
