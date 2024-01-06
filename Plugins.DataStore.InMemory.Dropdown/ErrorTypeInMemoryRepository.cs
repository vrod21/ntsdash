using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class ErrorTypeInMemoryRepository : IErrorTypeRepository
    {
        private readonly List<ErrorType> _errorType;
        public ErrorTypeInMemoryRepository()
        {
            _errorType = new List<ErrorType>()
            {
                new ErrorType { Name = "CONS", Type = "Consistency error"}, new ErrorType { Name = "CONS", Type = "Consistency not needed"}, new ErrorType { Name = "CONS", Type = "Others"},

                new ErrorType { Name = "DASH", Type = "Emdash"}, new ErrorType { Name = "DASH", Type = "Endash"}, new ErrorType { Name = "DASH", Type = "Hyphen"},
                new ErrorType { Name = "DASH", Type = "Minus sign"}, new ErrorType { Name = "DASH", Type = "Others"},

                new ErrorType { Name = "LANG", Type = "\"and\" in a series"}, new ErrorType { Name = "LANG", Type = "Article Usage"}, new ErrorType { Name = "LANG", Type = "Modifier"},
                new ErrorType { Name = "LANG", Type = "Noun number"}, new ErrorType { Name = "LANG", Type = "Prepositions"}, new ErrorType { Name = "LANG", Type = "Punctuations"},
                new ErrorType { Name = "LANG", Type = "Sentence Structure"}, new ErrorType { Name = "LANG", Type = "SVA"}, new ErrorType { Name = "LANG", Type = "Syntax"},
                new ErrorType { Name = "LANG", Type = "Tenses"}, new ErrorType { Name = "LANG", Type = "Word Usage"}, new ErrorType { Name = "LANG", Type = "Others"},

                new ErrorType { Name = "LAYOT", Type = "Alignment(PDF)"}, new ErrorType { Name = "LAYOT", Type = "Bad line break"}, new ErrorType { Name = "LAYOT", Type = "Indents"},
                new ErrorType { Name = "LAYOT", Type = "Orphan"}, new ErrorType { Name = "LAYOT", Type = "Pagination"}, new ErrorType { Name = "LAYOT", Type = "Stacked words"},
                new ErrorType { Name = "LAYOT", Type = "Table alignment"}, new ErrorType { Name = "LAYOT", Type = "Truncation"}, new ErrorType { Name = "LAYOT", Type = "Widow"},
                new ErrorType { Name = "LAYOT", Type = "Stacked AQF flags"}, new ErrorType { Name = "LAYOT", Type = "Others"},

                new ErrorType { Name = "MATH", Type = "Bold emphasis"}, new ErrorType { Name = "MATH", Type = "Delimiters"}, new ErrorType { Name = "MATH", Type = "Italic emphasis"},
                new ErrorType { Name = "MATH", Type = "Symbols"}, new ErrorType { Name = "MATH", Type = "Sub/Sup"}, new ErrorType { Name = "MATH", Type = "Unconverted equation"},
                new ErrorType { Name = "MATH", Type = "Others"},

                new ErrorType { Name = "NEG", Type = "Negligence" }, new ErrorType { Name = "NEG", Type = "Typo error" }, new ErrorType { Name = "NEG", Type = "Others" },

                new ErrorType { Name = "MCE", Type = "CNCO"}, new ErrorType { Name = "MCE", Type = "CICO"}, new ErrorType { Name = "MCE", Type = "Incorrect placement of markups"}, 
                new ErrorType { Name = "MCE", Type = "Interpretation"}, new ErrorType { Name = "MCE", Type = "Others"},

                new ErrorType { Name = "PUNC_DEL", Type = "Brackets" }, new ErrorType { Name = "PUNC_DEL", Type = "Colon" }, new ErrorType { Name = "PUNC_DEL", Type = "Comma" },
                new ErrorType { Name = "PUNC_DEL", Type = "Full stops" }, new ErrorType { Name = "PUNC_DEL", Type = "Semi-colon" }, new ErrorType { Name = "PUNC_DEL", Type = "Others" },

                new ErrorType { Name = "QUERY", Type = "Author Query" }, new ErrorType { Name = "QUERY", Type = "PPQ" }, new ErrorType { Name = "QUERY", Type = "Others" },

                new ErrorType { Name = "SPACE", Type = "Em - space" }, new ErrorType { Name = "SPACE", Type = "Operator space" }, new ErrorType { Name = "SPACE", Type = "Unit space" },
                new ErrorType { Name = "SPACE", Type = "Keyboard space" }, new ErrorType { Name = "SPACE", Type = "Others" },

                new ErrorType { Name = "SPECS", Type = "Element not allowed" }, new ErrorType { Name = "SPECS", Type = "Mandatory element" }, new ErrorType { Name = "SPECS", Type = "Optional element" },
                new ErrorType { Name = "SPECS", Type = "Order of elements" }, new ErrorType { Name = "SPECS", Type = "Standard text" }, new ErrorType { Name = "SPECS", Type = "Others" },

                new ErrorType { Name = "SPELL", Type = "Incorrect spelling" }, new ErrorType { Name = "SPELL", Type = "UK/US" }, new ErrorType { Name = "SPELL", Type = "Others" },

                new ErrorType { Name = "STR_TAG", Type = "ArtTitle" }, new ErrorType { Name = "STR_TAG", Type = "AuName" }, new ErrorType { Name = "STR_TAG", Type = "ChapTitle" },
                new ErrorType { Name = "STR_TAG", Type = "EdBook title" }, new ErrorType { Name = "STR_TAG", Type = "Hyperlinking" }, new ErrorType { Name = "STR_TAG", Type = "IssueNum" },
                new ErrorType { Name = "STR_TAG", Type = "JourAbbrev" }, new ErrorType { Name = "STR_TAG", Type = "JourName" }, new ErrorType { Name = "STR_TAG", Type = "OtherRefs" },
                new ErrorType { Name = "STR_TAG", Type = "PgRange" }, new ErrorType { Name = "STR_TAG", Type = "PubDate" }, new ErrorType { Name = "STR_TAG", Type = "PubName" },
                new ErrorType { Name = "STR_TAG", Type = "PubLoc" }, new ErrorType { Name = "STR_TAG", Type = "Delim/Brackets" }, new ErrorType { Name = "STR_TAG", Type = "Volnum" },
                new ErrorType { Name = "STR_TAG", Type = "Incorrect structure/tagging" }, new ErrorType { Name = "STR_TAG", Type = "Others" },

                new ErrorType { Name = "STYLE", Type = "Abbrev placement" }, new ErrorType { Name = "STYLE", Type = "Abbrevs/Acronyms" }, new ErrorType { Name = "STYLE", Type = "Bold emphasis" },
                new ErrorType { Name = "STYLE", Type = "Capitalization" }, new ErrorType { Name = "STYLE", Type = "Dates/Time" }, new ErrorType { Name = "STYLE", Type = "Direct citations" },
                new ErrorType { Name = "STYLE", Type = "Expanded" }, new ErrorType { Name = "STYLE", Type = "Italic emphasis" }, new ErrorType { Name = "STYLE", Type = "Sub/Sup" },
                new ErrorType { Name = "STYLE", Type = "Units (Abbrev or not)" }, new ErrorType { Name = "STYLE", Type = "Author Initials" }, new ErrorType { Name = "STYLE", Type = "Numbers (Digit/Words)" },
                new ErrorType { Name = "STYLE", Type = "Others" },

                new ErrorType { Name = "SYM", Type = "Double quotes"}, new ErrorType { Name = "SYM", Type = "Prime"}, new ErrorType { Name = "SYM", Type = "Single quotes"},
                new ErrorType { Name = "SYM", Type = "Trademark"}, new ErrorType { Name = "SYM", Type = "Unconverted"}, new ErrorType { Name = "SYM", Type = "Others"},

                new ErrorType { Name = "DATA", Type = "Added data" }, new ErrorType { Name = "DATA", Type = "Incorrect data" }, new ErrorType { Name = "DATA", Type = "Missing data" },

                new ErrorType { Name = "Others", Type = "Others" },
            };
        }

        public List<ErrorType> GetErrorTypeByErrorCodeName(string errorCode)
        {
            return _errorType.Where(x => x.Name == errorCode).ToList();
        }
    }
}
























































































