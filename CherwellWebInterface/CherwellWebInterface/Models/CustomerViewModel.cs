using CherwellApi;
using System.Collections.Generic;
using Classes;

namespace CherwellWebInterface.Models
{
    public class CustomerViewModel
    {
        public List<Company> Companies { get; set; }

        public Company Company { get; set; }

        public CustomerViewModel()
        {
            Companies = CherwellSoapInterface.GetAllCompanies();
        }
    }
}
