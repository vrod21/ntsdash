using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using NLog;
using NLog.Fluent;
using NTDataHiveFrontend.Mapper;
using NTDataHiveFrontend.Utilities.Filter;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class PersonBackendService
    {
        GrpcChannel _channel;
        NTDataHiveGrpcService.PersonBackend.PersonBackendClient _client;
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;
        private readonly PersonGrpcFormatMapper _grpcFormatMapper;
        private readonly PersonFrontendFormatMapper _frontendFormatMapper;
        private readonly PersonGetFilter _getFilter;

        public PersonBackendService(ILogger<PersonBackendService> logger, IConfiguration config)
        {
            _url = config.GetValue<string>("ServiceData:BackendService:URL");
            _grpcFormatMapper = new PersonGrpcFormatMapper();
            _frontendFormatMapper = new PersonFrontendFormatMapper();
            _getFilter = new PersonGetFilter();
        }
        private void Connect()
        {
            try
            {
                HttpClientHandler httpHandler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(httpHandler);

                _channel = GrpcChannel.ForAddress(_url, new GrpcChannelOptions
                {
                    HttpClient = httpClient,
                });

                _client = new NTDataHiveGrpcService.PersonBackend.PersonBackendClient(_channel);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region SavePerson
        public async Task<Google.Rpc.Status> SavePerson(Model.Person personRecord)
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.PersonRequest grpcPersonRecord = _grpcFormatMapper.ToGrpcFormat(personRecord);

            Google.Rpc.Status result;
            try
            {
                result = await _client.SavePersonAsync(grpcPersonRecord);
                return result;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Save rule threw up: {ex.Message}, {ex}");
                return new Google.Rpc.Status { Code = 2, Message = ex.Message };
            }
        }
        #endregion

        #region GetAllPerson
        public async Task<List<Model.Person>> GetAllPerson()
        {
            if (_client == null)
                Connect();

            var getAllPerson = await _client.GetAllPersonAsync(new NTDataHiveGrpcService.PersonEmpty());

            List<Model.Person> people = new List<Model.Person>();

            foreach (var personRecord in getAllPerson.Items)
            {
                people.Add(_frontendFormatMapper.ToFrontendFormat(personRecord));
            }
            return people;
        }
        #endregion

        #region GetPersonByType
        public async Task<List<Model.Person>> GetPersonByType()
        {
            if (_client == null)
                Connect();

            var getPerson = await _client.GetPersonByTypeAsync(new NTDataHiveGrpcService.PersonEmpty());

            List<Model.Person> people = new List<Model.Person>();

            foreach (var personRecord in getPerson.Items)
            {
                people.Add(_frontendFormatMapper.ToFrontendFormat(personRecord));
            }

            return people;
        }

        #endregion

        #region GetRecordByReportingManager
        public async Task<List<Model.Person>> GetRecordByReportingManager(Model.Person person)
        {
            if (_client == null)
                Connect();

            try
            {
                var personList = await _client.GetPersonByReportingManagerAsync(_getFilter.GetFilterFor(person.FullName));

                List<Model.Person> people = new List<Model.Person>();

                foreach (var personRecord in personList.Items)
                {
                    people.Add(_frontendFormatMapper.ToFrontendFormat(personRecord));
                }
                return people;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Person name is null" + ex.Message);
                throw;
            }
        }
        #endregion

        #region GetPersonRecord
        public async Task<Model.Person> GetPersonRecord(string id)
        {
            if (_client == null)
                Connect();

            try
            {
                NTDataHiveGrpcService.PersonRequest result;
                try
                {
                    result = await _client.GetPersonRecordAsync(_getFilter.GetFilterFor(id));
                }
                catch (Exception ex)
                {
                    _nlog.Error("Get person record threw up: " + ex.Message);
                    return null;
                }

                if (result.Status.Code == 0)
                {
                    Model.Person person = _frontendFormatMapper.ToFrontendFormat(result);

                    if (result.WebId != "")
                        return person;

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
    }
}
