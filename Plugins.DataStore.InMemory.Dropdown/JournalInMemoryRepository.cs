using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dropdown.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class JournalInMemoryRepository : IJournalRepository
    {
        private readonly List<Journal> _journalName;
        public JournalInMemoryRepository()
        {
            _journalName = new List<Journal>()
            {
                new Journal {Id = 1, JournalName = "AMJHSP" },
                new Journal {Id = 1, JournalName = "ASJOFJ" },
                new Journal {Id = 1, JournalName = "ASJOUR" },
                new Journal {Id = 1, JournalName = "BJDERM" },
                new Journal {Id = 1, JournalName = "BJSOPE" },
                new Journal {Id = 1, JournalName = "BJSURG" },
                new Journal {Id = 1, JournalName = "BRAINJ" },
                new Journal {Id = 1, JournalName = "BRCOMS" },
                new Journal {Id = 1, JournalName = "CEDERM" },
                new Journal {Id = 1, JournalName = "CLCHEM" },
                new Journal {Id = 1, JournalName = "CLIND" },
                new Journal {Id = 1, JournalName = "CVRESE" },
                new Journal {Id = 1, JournalName = "EHEART" },
                new Journal {Id = 1, JournalName = "EHJACC" },
                new Journal {Id = 1, JournalName = "EHJCRE" },
                new Journal {Id = 1, JournalName = "EHJDHE" },
                new Journal {Id = 1, JournalName = "EHJIMP" },
                new Journal {Id = 1, JournalName = "EHJOPN" },
                new Journal {Id = 1, JournalName = "EJECHO" },
                new Journal {Id = 1, JournalName = "EJENDO" },
                new Journal {Id = 1, JournalName = "ENDOCR" },
                new Journal {Id = 1, JournalName = "ENDREV" },
                new Journal {Id = 1, JournalName = "EUPACE" },
                new Journal {Id = 1, JournalName = "EURJCN" },
                new Journal {Id = 1, JournalName = "EURJPC" },
                new Journal {Id = 1, JournalName = "GBEVOL" },
                new Journal {Id = 1, JournalName = "GENETS" },
                new Journal {Id = 1, JournalName = "GTHREE" },
                new Journal {Id = 1, JournalName = "HASCHL" },
                new Journal {Id = 1, JournalName = "INFDIS" },
                new Journal {Id = 1, JournalName = "JACAMR" },
                new Journal {Id = 1, JournalName = "JALMED" },
                new Journal {Id = 1, JournalName = "JCEMCR" },
                new Journal {Id = 1, JournalName = "JCEMET" },
                new Journal {Id = 1, JournalName = "JESOCI" },
                new Journal {Id = 1, JournalName = "JLEUKO" },
                new Journal {Id = 1, JournalName = "JOPEDU" },
                new Journal {Id = 1, JournalName = "JRSSIG" },
                new Journal {Id = 1, JournalName = "JRSSSA" },
                new Journal {Id = 1, JournalName = "JRSSSB" },
                new Journal {Id = 1, JournalName = "JRSSSC" },
                new Journal {Id = 1, JournalName = "MICMIC" },
                new Journal {Id = 1, JournalName = "MOLBEV" },
                new Journal {Id = 1, JournalName = "OFIDIS" },
                new Journal {Id = 1, JournalName = "PLCELL" },
                new Journal {Id = 1, JournalName = "PLPYHS" },
                new Journal {Id = 1, JournalName = "PNEXUS" },
                new Journal {Id = 1, JournalName = "PSQUAR" },
                new Journal {Id = 1, JournalName = "RESTUD" },
                new Journal {Id = 1, JournalName = "SEHEART" },
            };
        }

        public List<Journal> GetJournalId()
        {
            return _journalName;
        }
    }
}
