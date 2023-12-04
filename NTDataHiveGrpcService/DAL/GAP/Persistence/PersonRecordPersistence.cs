using NLog;
using NTDataHiveGrpcService.DAL.GAP.Adapters;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;

namespace NTDataHiveGrpcService.DAL.GAP.Persistence
{
    public class PersonRecordPersistence : IPersonRecordPersistence
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;

        public PersonRecordPersistence(IConfiguration config)
        {
            _config = config;
        }

        #region Save
        public bool Save(BLL.RecordContents.PersonFilter personRecord)
        {
            var createRecord = new PersonRecordAdapter(_config);
            int empId = createRecord.GetPersonByWebId(personRecord.personNotExistRequest.WebId);

            if (empId == 0)
            {
                createRecord.InserPerson(personRecord.personNotExistRequest);
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
