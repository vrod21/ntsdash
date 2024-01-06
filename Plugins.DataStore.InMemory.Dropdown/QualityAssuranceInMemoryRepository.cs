using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class QualityAssuranceInMemoryRepository : IQualityAssuranceRepository
    {
        private readonly List<QualityAssurance> _qualityAssurance;
        public QualityAssuranceInMemoryRepository()
        {
            _qualityAssurance = new List<QualityAssurance>()
            {
                new QualityAssurance { Id = 1, Name = "Anitha"},
                new QualityAssurance { Id = 2, Name = "Deovic Intong" },
                new QualityAssurance { Id = 3, Name = "Girlie Quio" },
                new QualityAssurance { Id = 4, Name = "Jelou Fon" },
                new QualityAssurance { Id = 5, Name = "Joy Pactol" },
                new QualityAssurance { Id = 6, Name = "Nirmala" },
                new QualityAssurance { Id = 7, Name = "Rajalakshmi" },
                new QualityAssurance { Id = 8, Name = "Ruel Amaro" },
                new QualityAssurance { Id = 9, Name = "Others" },
            };
        }

        public List<QualityAssurance> GetQualiyAssurance()
        {
            return _qualityAssurance;
        }
    }
}








