﻿using NLog;
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
            int personId = createRecord.GetPersonByWebId(personRecord.personNotExistRequest.WebId);

            if (personId == 0)
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

        #region GetAllPerson
        public List<PersonNotExistRequest> GetAllPerson()
        {
            List<PersonNotExistRequest> selectPerson = new PersonRecordAdapter(_config).GetAllPersonRecord();

            if (selectPerson.Count() >= 1)
            {
                return selectPerson;
            }
            throw new Exception("There is no value");
        }
        #endregion

        #region SelectById
        public bool SelectById(string webid, out BLL.RecordContents.PersonFilter personRecord)
        {
            if (CreateRevisionRecordByWebId(webid, out BLL.RecordContents.PersonFilter personRecordLocal))
            {
                personRecord = personRecordLocal;
                return true;
            }
            else
            {
                personRecord = new BLL.RecordContents.PersonFilter(webid);
                return false;
            }
        }
        #endregion

        #region CreatePersonRecordByWebId
        private bool CreateRevisionRecordByWebId(string webid, out BLL.RecordContents.PersonFilter personRecord)
        {
            personRecord = new BLL.RecordContents.PersonFilter(webid);

            var personAdapter = new PersonRecordAdapter(_config);

            if (!personAdapter.SelectPersonPart(personRecord.personNotExistRequest))
                return false;

            return true;
        }
        #endregion
    }
}
