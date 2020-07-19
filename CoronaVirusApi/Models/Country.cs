using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaVirusApi.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int InfectedNo { get; set; }

        public int RecoveredNo { get; set; }

        public int DeathNo { get; set; }

        public DateTime RefreshDate { get; set; }

        public int ContinentId { get; set; }

        public Continent Continent { get; set; }
    }
}
