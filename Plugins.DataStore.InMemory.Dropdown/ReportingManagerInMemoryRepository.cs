using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class ReportingManagerInMemoryRepository : IReportingManagerRepository
    {
        private readonly List<ReportingManager> _account;

        public ReportingManagerInMemoryRepository()
        {
            _account = new List<ReportingManager>()
            {
                new ReportingManager {Id = 1, Name = "Select <Reporting Manager>:" },
                new ReportingManager {Id = 2, Name = "Shiela Teves" },
                new ReportingManager {Id = 3, Name = "Diasy Lumen" },
                new ReportingManager {Id = 4, Name = "Ruel Piñero" },
                new ReportingManager {Id = 5, Name = "Kim Campos" },
                new ReportingManager {Id = 6, Name = "Cherry Mae Almenzo" },
                new ReportingManager {Id = 7, Name = "Irish Mariño" },
                new ReportingManager {Id = 8, Name = "Barney Boy Cutamora" },
                new ReportingManager {Id = 9, Name = "Allan Aling" },
            };
        }

        public List<ReportingManager> GetReportingManager()
        {
            return _account;
        }
    }
}
