using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using NLog;
using NTDataHiveFrontend.Mapper;
using NTDataHiveFrontend.Utilities;
using NTDataHiveFrontend.Utilities.Filter;
using System;
using System.Runtime.InteropServices;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class EvaluationBackendService
    {
        GrpcChannel _channel;
        NTDataHiveGrpcService.EvaluationBackend.EvaluationBackendClient _client;
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;
        private readonly FeedbackGrpcFormatMapper _frontendFormatMapper;
        private readonly FeedbackFrontendFormatMapper _grpcFormatMapper;
        private readonly FeedbackGetFilter _getFilter;
        private readonly IConfiguration _config;
        DateTime callDeadLine
        {
            get
            {
                return DateTime.UtcNow.AddSeconds(100);
            }
        }
        public EvaluationBackendService(IConfiguration config)
        {
            GetTimeZoneUtility timeZoneUtility = new GetTimeZoneUtility(config);
            _url = config.GetValue<string>("ServiceData:BackendService:URL");
            _frontendFormatMapper = new FeedbackGrpcFormatMapper();
            _grpcFormatMapper = new FeedbackFrontendFormatMapper();
            _getFilter = new FeedbackGetFilter();            
            timeZoneUtility.GetTimeZone();
            _config = config;
        }

        //private TimeZoneInfo GetTimeZone()
        //{

        //    TimeZoneInfo ret;
            
        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //    {
        //        ret = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
        //        //DateTime dateTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, ret);
        //        //ret.IsDaylightSavingTime(dateTime);                
        //    }
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //    {
        //        ret = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
        //        //DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, ret);
        //        //ret.IsDaylightSavingTime(tstTime);
        //    }
        //    else
        //        throw new NotImplementedException("GetTimeZone() for this OS is not implemented.");

        //    return ret;
        //}

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
                _client = new NTDataHiveGrpcService.EvaluationBackend.EvaluationBackendClient(_channel);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region SaveFeedback
        public async Task<Google.Rpc.Status> SaveFeedback(Model.Feedback feedbackRecord)
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.FeedbackRecordRequest grpcFeedbackRecord = _frontendFormatMapper.ToGrpcFormat(feedbackRecord);

            Google.Rpc.Status result;
            try
            {
                result = await _client.SaveFeedbackAsync(grpcFeedbackRecord);
                return result;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Save feedback threw up: {ex.Message}, {ex}");
                return new Google.Rpc.Status { Code = 2, Message = ex.Message };
            }
        }
        #endregion

        #region GetFeedbackRecord
        public async Task<Model.Feedback> GetFeedbackRecord(Guid id)
        {
            if (_client == null)
                Connect();

            try
            {
                NTDataHiveGrpcService.FeedbackRecordRequest result;
                try
                {
                    result = await _client.GetFeedbackRecordAsync(_getFilter.GetFilterFor(id));
                }
                catch (Exception ex)
                {
                    _nlog.Error("Get feedback record threw up: " + ex.Message);
                    return null;
                }

                if (result.Status.Code == 0)
                {
                    Model.Feedback revision = _grpcFormatMapper.ToFrontendFormat(result);

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

        #region GetRecordByEmployeeName
        public async Task<List<Model.Feedback>> GetRecordByEmployeeName(Model.Person feedback)
        {
            if (_client == null)
                Connect();

            try
            {
                var feedbackList = await _client.GetFeedbackByEmployeeNameAsync(_getFilter.GetFilterFor(feedback.FullName));

                List<Model.Feedback> feedbacks = new List<Model.Feedback>();

                foreach (var feedbackRecord in feedbackList.Items)
                {
                    feedbacks.Add(_grpcFormatMapper.ToFrontendFormat(feedbackRecord));
                }

                
                return feedbacks;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Employee name is null" + ex.Message);
                throw;
            }
        }
        #endregion

        #region GetRecorByReportingManager

        #endregion

        #region GetFeedbackRecordByPublisherName
        public async Task<List<Model.Feedback>> GetFeedbackRecordByPublisherName(Model.Feedback feedback)
        {
            if (_client == null)
                Connect();

            try
            {
                var feedbackList = await _client.GetFeedbackByPublisherNameAsync(_getFilter.GetFilterFor(feedback));

                List<Model.Feedback> feedbacks = new List<Model.Feedback>();

                foreach (var feedbackRecord in feedbackList.Items)
                {
                    feedbacks.Add(_grpcFormatMapper.ToFrontendFormat(feedbackRecord));
                }
                return feedbacks;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Publisher name is null" + ex.Message);
                throw;
            } 
        }
        #endregion

        #region GetAllFeedback
        public async Task<List<Model.Feedback>> GetAllFeedback()
        {
            if (_client == null)
                Connect();

            var feedback = await _client.GetAllFeedbackAsync(new NTDataHiveGrpcService.FeedbackEmpty());

            List<Model.Feedback> evaluationFeedback = new List<Model.Feedback>();

            foreach (var feedbackRecord in feedback.Items)
            {
                evaluationFeedback.Add(_grpcFormatMapper.ToFrontendFormat(feedbackRecord));
            }
            return evaluationFeedback;
        }
        #endregion
    }
}
