using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaVirusApi.Models
{
    public class Continent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int InfectedNo
        {
            get
            {
                var totalNo = 0;
                if (Countries == null)
                {
                    return totalNo;
                }

                foreach (var country in Countries)
                {
                    totalNo += country.InfectedNo;
                }

                return totalNo;
            }
        }

        public int RecoveredNo
        {
            get
            {
                var totalNo = 0;
                if (Countries == null)
                {
                    return totalNo;
                }

                foreach (var country in Countries)
                {
                    totalNo += country.RecoveredNo;
                }

                return totalNo;
            }
        }

        public int DeathNo
        {
            get
            {
                var totalNo = 0;
                if (Countries == null)
                {
                    return totalNo;
                }

                foreach (var country in Countries)
                {
                    totalNo += country.DeathNo;
                }

                return totalNo;
            }
        }

        public DateTime RefreshDate
        {
            get
            {
                DateTime latestRefreshDate;
                if (Countries == null)
                {
                    latestRefreshDate = DateTime.MinValue;
                    return latestRefreshDate;
                }

                var lastUpdatedCountry = Countries.OrderByDescending(a => a.RefreshDate).FirstOrDefault();
                if (lastUpdatedCountry == null)
                {
                    latestRefreshDate = DateTime.MinValue;
                }
                else
                {
                    latestRefreshDate = lastUpdatedCountry.RefreshDate;
                }

                return latestRefreshDate;
            }
        }


        public List<Country> Countries { get; set; }
    }
}
