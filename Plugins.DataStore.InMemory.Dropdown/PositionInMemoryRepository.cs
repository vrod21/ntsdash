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
                //new Position { Id = 6, Name = "Deputy Manager" },
                //new Position { Id = 7, Name = "Senior Team Lead" },
                //new Position { Id = 8, Name = "Manager" },
                //new Position { Id = 9, Name = "Assistant Vice President" },
                //new Position { Id = 10, Name = "Assistant Manager" },
                //new Position { Id = 11, Name = "Team Lead" },
                //new Position { Id = 12, Name = "Production Supervisor" },
                new Position { Id = 13, Name = "Others" },
            };
        }

        public List<Position> GetPosition()
        {
            return _positions;
        }
    }
}
