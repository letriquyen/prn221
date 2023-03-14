using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;

namespace SafeBuilding.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public int contractYear = 2010;
        public string buildingId;
        public IList<Building> buildings { get; set; } = default!;
        public List<int> contractStatistic { get; set; }

        public Dictionary<string, int> flatStatistic { get; set; }
        public Dictionary<string, int> billStatistic { get; set; }
        public DateOnly billDate {get; set;}
        SafeBuildingContext _context ;

        public IndexModel(ILogger<IndexModel> logger, SafeBuildingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if(HttpContext.Session.GetString("Phone") == null)
            {
                return RedirectToPage("Login");
            }
            buildings = _context.Buildings.ToList();

            Dictionary<int, int> contracts = new Dictionary<int, int>();
            for (int i = 0; i <= 12; i++)
            {
                contracts.Add(i, 0);
            }
            // !!!IMPORTANT: update expiryDate -> startDate
            List<RentContract> rentContracts = _context.RentContracts
                .Where(rc => rc.StartDate.Value.Year == contractYear).ToList();
            foreach (RentContract rentContract in rentContracts)
            {
                contracts[rentContract.StartDate.Value.Month ] += 1;
            }
            contracts[0]=rentContracts.Count;
            if(buildingId == null || "".Equals(buildingId))
            {
                buildingId = buildings[0].Id;
            }
            int countAvailable = 0, countPending = 0, countUnavailable = 0;
            List<Flat> flats = _context.Flats.Where(f => f.BuildingId.Equals(buildingId)).ToList();
            foreach (Flat flat in flats)
            {
                string status = flat.Status;
                if (status.Equals("AVAILABLE"))
                {
                    countAvailable++;
                }
                else if (status.Equals("PENDING"))
                {
                    countPending++;
                }
                else if (status.Equals("UNAVAILABLE"))
                {
                    countUnavailable++;
                }
            }

            Dashboard dashboard = new Dashboard(_context);
            DashboardModel dashboardModel = new DashboardModel();
           
            //billStatistic = dashboard.getBillStatistics(DateTime.Now.Month, DateTime.Now.Year);
            flatStatistic = new Dictionary<string, int>
            {
                { "AVAILABLE", countAvailable },
                { "PENDING", countPending },
                { "UNAVAILABLE", countUnavailable }
            };
            contractStatistic = contracts.Values.ToList();

            return Page();
        }
    }
    public class DashboardModel
    {
        public List<Building> buildings { get; set; }
        public List<int> contractStatistic { get; set; }

        public Dictionary<string, int> flatStatistic { get; set; }
        public Dictionary<string, int> billStatistic { get; set; }
    }
    public class Dashboard
    {
        private readonly SafeBuildingContext _context;
        public Dashboard(SafeBuildingContext context)
        {
            _context = context;
        }

        public List<Building> getBuildings()
        {
            return _context.Buildings.ToList();
        }


        public List<int> getContractStatistics(int year)
        {
            Dictionary<int, int> contracts = new Dictionary<int, int>();
            for (int i = 0; i < 12; i++)
            {
                contracts.Add(i, 0);
            }
            // !!!IMPORTANT: update expiryDate -> startDate
            List<RentContract> rentContracts = _context.RentContracts
                .Where(rc => rc.ExpiryDate.Value.Year == year).ToList();
            foreach (RentContract rentContract in rentContracts)
            {
                contracts[rentContract.ExpiryDate.Value.Month - 1] += 1;
            }

            return contracts.Values.ToList();
        }
        public Dictionary<string, int> getFlatStatistics(String buildingId)
        {
            int countAvailable = 0, countPending = 0, countUnavailable = 0;
            List<Flat> flats = _context.Flats.Where(f => f.BuildingId.Equals(buildingId)).ToList();
            foreach (Flat flat in flats)
            {
                string status = flat.Status;
                if (status.Equals("AVAILABLE"))
                {
                    countAvailable++;
                }
                else if (status.Equals("PENDING"))
                {
                    countPending++;
                }
                else if (status.Equals("UNAVAILABLE"))
                {
                    countUnavailable++;
                }
            }
            return new Dictionary<string, int>
            {
                { "AVAILABLE", countAvailable },
                { "PENDING", countPending },
                { "UNAVAILABLE", countUnavailable }
            };

        }

        public Dictionary<string, int> getBillStatistics(int month, int year)
        {
            int countPaid = 0, countUnpaid = 0;
            /*List<Bill> bills = _context.Bills.Where(b => b.Date.Value.Month == month && b.Date.Value.Year == year).ToList();
            foreach (Bill bill in bills)
            {
                if (bill.Status.Equals("PAID"))
                {
                    countPaid++;
                } else
                {
                    countUnpaid++;
                }
            }*/
            return new Dictionary<string, int>
            {
                { "PAID", countPaid },
                { "UNPAID", countUnpaid }
            };
        }

    }
}