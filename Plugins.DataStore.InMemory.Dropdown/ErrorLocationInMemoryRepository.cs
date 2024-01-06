using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class ErrorLocationInMemoryRepository : IErrorLocationRepository
    {
        private readonly List<ErrorLocation> _errorLocation;
        public ErrorLocationInMemoryRepository()
        {
            _errorLocation = new List<ErrorLocation>()
            {
                new ErrorLocation { Id = 1, Name = "Abbreviations"},
                new ErrorLocation { Id = 2, Name = "Abstract" },
                new ErrorLocation { Id = 3, Name = "Acknowledgement" },
                new ErrorLocation { Id = 4, Name = "Affiliations" },
                new ErrorLocation { Id = 5, Name = "Appendix Section" },
                new ErrorLocation { Id = 6, Name = "Article Note" },
                new ErrorLocation { Id = 7, Name = "Article Title" },
                new ErrorLocation { Id = 8, Name = "Author Contributions" },
                new ErrorLocation { Id = 9, Name = "Author Group" },
                new ErrorLocation { Id = 10, Name = "Author Note" },
                new ErrorLocation { Id = 11, Name = "Banner" },
                new ErrorLocation { Id = 12, Name = "BM Order" },
                new ErrorLocation { Id = 13, Name = "Body Text " },
                new ErrorLocation { Id = 14, Name = "Citations" },
                new ErrorLocation { Id = 15, Name = "COI" },
                new ErrorLocation { Id = 16, Name = "Collab Author" },
                new ErrorLocation { Id = 17, Name = "Collaboration Section" },
                new ErrorLocation { Id = 18, Name = "Commercial Affiliations" },
                new ErrorLocation { Id = 19, Name = "Copyright" },
                new ErrorLocation { Id = 20, Name = "Corr Field" },
                new ErrorLocation { Id = 21, Name = "DAS" },
                new ErrorLocation { Id = 22, Name = "Disclosure" },
                new ErrorLocation { Id = 23, Name = "Displayed Quote" },
                new ErrorLocation { Id = 24, Name = "Doc Type" },
                new ErrorLocation { Id = 25, Name = "Ed/Rev Details" },
                new ErrorLocation { Id = 26, Name = "Equal Contribution" },
                new ErrorLocation { Id = 27, Name = "Equations" },
                new ErrorLocation { Id = 28, Name = "Ethics Statement" },
                new ErrorLocation { Id = 29, Name = "Figures" },
                new ErrorLocation { Id = 30, Name = "Funding" },
                new ErrorLocation { Id = 31, Name = "Glossary" },
                new ErrorLocation { Id = 32, Name = "Graph Abstract" },
                new ErrorLocation { Id = 33, Name = "History Dates" },
                new ErrorLocation { Id = 34, Name = "Introduction" },
                new ErrorLocation { Id = 35, Name = "Keywords" },
                new ErrorLocation { Id = 35, Name = "List" },
                new ErrorLocation { Id = 35, Name = "LRH" },
                new ErrorLocation { Id = 35, Name = "Markups" },
                new ErrorLocation { Id = 35, Name = "ORCID" },
                new ErrorLocation { Id = 35, Name = "Pagination" },
                new ErrorLocation { Id = 35, Name = "Present Address" },
                new ErrorLocation { Id = 35, Name = "Query" },
                new ErrorLocation { Id = 35, Name = "References" },
                new ErrorLocation { Id = 35, Name = "Related Article Blurb" },
                new ErrorLocation { Id = 35, Name = "RRH" },
                new ErrorLocation { Id = 35, Name = "Section Heading" },
                new ErrorLocation { Id = 35, Name = "Specialty Section" },
                new ErrorLocation { Id = 35, Name = "Supplementary Material " },
                new ErrorLocation { Id = 35, Name = "Tables" },
                new ErrorLocation { Id = 35, Name = "Textbox" },
                new ErrorLocation { Id = 35, Name = "URL" },
                new ErrorLocation { Id = 35, Name = "Others" },
            };
        }

        public List<ErrorLocation> GetErrorLocation()
        {
            return _errorLocation;
        }
    }
}








