﻿using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPersonRecordPersistence
    {
        List<PersonNotExistRequest> GetAllPerson();
        bool Save(PersonFilter personRecord);
    }
}