using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using NLog;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class RevisionBackendService
    {
        GrpcChannel _channel;

        NTDataHiveGrpcService.RevisionFeedbackBackend.RevisionFeedbackBackendClient _client;

        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;

        public RevisionBackendService(ILogger<RevisionBackendService> logger, IConfiguration config)
        {
            _url = config.GetValue<string>("ServiceData:BackendService:URL");
        }

        private void Connect()
        {
            try
            {
                HttpClientHandler httpHandler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(httpHandler);

                _channel = GrpcChannel.ForAddress(_url, new GrpcChannelOptions()
                {
                    HttpClient = httpClient,
                });
                _client = new NTDataHiveGrpcService.RevisionFeedbackBackend.RevisionFeedbackBackendClient(_channel);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region SaveRevisionFeedback
        public async Task<Google.Rpc.Status> SaveRevisionFeedback(Model.Revision revisionRecord)
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.RevisionFeedbackRecordRequest grpcRevisionRecord = ToGrpcFormat(revisionRecord);

            Google.Rpc.Status result;
            try
            {
                result = await _client.SaveRevisionFeedbackAsync(grpcRevisionRecord);
                return result;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Save revision threw up: {ex.Message}, {ex}");
                return new Google.Rpc.Status { Code = 2, Message = ex.Message };
            }
        }
        #endregion

        #region GetAll
        public async Task<List<Model.Revision>> GetAllRevision()
        {
            if (_client == null)
                Connect();

            var revisionList = await _client.GetAllAsync(new NTDataHiveGrpcService.RevisionFeedbackEmpty());

            List<Model.Revision> revisionFeedback = new List<Model.Revision>();

            foreach (var revisionRecord in revisionList.Items) 
            {
                revisionFeedback.Add(ToFrontendFormat(revisionRecord));
            }

            return revisionFeedback;
        }
        #endregion

        #region GetRevisionRecord
        public async Task<Model.Revision> GetRevisionRecord(Guid id)
        {
            if (_client == null)
                Connect();

            try
            {
                NTDataHiveGrpcService.RevisionFeedbackRecordRequest result;
                try
                {
                    result = await _client.GetRevisionRecordAsync(GetFilterFor(id));
                }
                catch (Exception ex)
                {
                    _nlog.Error("Get revision record threw up: " + ex.Message);
                    return null;
                }

                if (result.Status.Code == 0)
                {
                    Model.Revision revision = ToFrontendFormat(result);                    

                    if (result.WebId != "")
                        return revision;

                }
                _nlog.Error(result.Status.Message);
                return null;
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }
        #endregion

        #region GetFilterFor

        public NTDataHiveGrpcService.RevisionRecordFilter GetFilterFor(Guid id)
        {
            return new NTDataHiveGrpcService.RevisionRecordFilter()
            {
                WebId = id.ToString(),
            };
        }
        #endregion

        #region ToGrpcFormat
        public NTDataHiveGrpcService.RevisionFeedbackRecordRequest ToGrpcFormat(Model.Revision revisionRecord)
        {
            var grpcRevisionRecord = new NTDataHiveGrpcService.RevisionFeedbackRecordRequest()
            {
                WebId = revisionRecord.id.ToString(),
                SupplierName = revisionRecord.SupplierName,
                QualityAssurance = revisionRecord.QualityAssurance,
                PublisherName = revisionRecord.PublisherName,
                JournalId = revisionRecord.JournalId,
                ArticleId = revisionRecord.ArticleId,                
                PageCount = revisionRecord.PageCount,
                ErrorCount = revisionRecord.ErrorCount,
                DescriptionOfError = revisionRecord.DescriptionOfError,
                Matter = revisionRecord.Matter,
                ErrorLocation = revisionRecord.ErrorLocation,
                ErrorCode = revisionRecord.ErrorCode,
                ErrorType = revisionRecord.ErrorType,
                ErrorSubtype = revisionRecord.ErrorType,
                ErrorCategory = revisionRecord.ErrorType,
                IntroducedOrMissed = revisionRecord.IntroducedOrMissed,
                Department = revisionRecord.Department,
                EmployeeName = revisionRecord.EmployeeName,
                CopyEditingLevel = revisionRecord.CopyEditingLevel
            };

            if (revisionRecord?.CreatedAt != null)
                grpcRevisionRecord.CreatedAt = revisionRecord.CreatedAt.Value.ToUniversalTime().ToTimestamp();

            if (revisionRecord?.CreatedAt == null)
                grpcRevisionRecord = null;

            return grpcRevisionRecord;
        }
        #endregion

        #region ToFrontendFormat
        public Model.Revision ToFrontendFormat(NTDataHiveGrpcService.RevisionFeedbackRecordRequest revisionRequest)
        {
            Model.Revision frontendRevisionRecord = new Model.Revision()
            {
                WebId = revisionRequest.WebId,
                SupplierName = revisionRequest.SupplierName,
                QualityAssurance = revisionRequest.QualityAssurance,
                PublisherName = revisionRequest.PublisherName,
                JournalId = revisionRequest.JournalId,
                ArticleId = revisionRequest.ArticleId,
                PageCount = revisionRequest.PageCount,
                ErrorCount = revisionRequest.ErrorCount,
                DescriptionOfError = revisionRequest.DescriptionOfError,
                Matter = revisionRequest.Matter,
                ErrorLocation = revisionRequest.ErrorLocation,
                ErrorCode = revisionRequest.ErrorCode,
                ErrorType = revisionRequest.ErrorType,
                ErrorSubtype = revisionRequest.ErrorType,
                ErrorCategory = revisionRequest.ErrorType,
                IntroducedOrMissed = revisionRequest.IntroducedOrMissed,
                Department = revisionRequest.Department,
                EmployeeName = revisionRequest.EmployeeName,
                CopyEditingLevel = revisionRequest.CopyEditingLevel,
                CreatedAt = revisionRequest.CreatedAt.ToDateTime()
            };
            try
            {
                frontendRevisionRecord.id = Guid.Parse(revisionRequest.WebId);
            }
            catch (Exception ex)
            {
                _nlog.Error(ex, "Received revision record has an invalid ID");
                throw;
            }

            return frontendRevisionRecord;
        }
        #endregion


    }
}
