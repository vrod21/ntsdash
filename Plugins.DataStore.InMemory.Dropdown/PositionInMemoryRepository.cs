using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class PositionInMemoryRepository : IPositionRepository
    {
        private readonly List<Position> _positions;
        public PositionInMemoryRepository()
        {
            _positions = new List<Position>()
            {
                new Position { Id = 1, Name = "QMS Executive - Revision" },
                new Position { Id = 2, Name = "QMS Executive - Pre-Editing" },
                new Position { Id = 3, Name = "Copy Editing Manager" },
                new Position { Id = 4, Name = "Project Manager" },
                new Position { Id = 5, Name = "Operations Manager" },
                new Position { Id = 6, Name = "PRE - EDITOR" },
                new Position { Id = 7, Name = "QUALITY CONTROL" },
                new Position { Id = 8, Name = "COPY EDITOR" },
                new Position { Id = 9, Name = "IT - Personel (Admin)"},
                new Position { Id = 10, Name = "Others" },
                
            };
        }

        public List<Position> GetPosition()
        {
            return _positions;
        }
    }
}
