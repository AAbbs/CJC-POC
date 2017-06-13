using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Classes
{
    public class Company
    {
        public string RecId { get; set; }

        [Required(ErrorMessage = "Company Name is Required")]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Display(Name = "Company Address")]
        public string Address { get; set; }

        [Display(Name = "Hotline Client")]
        public bool Hotline { get; set; }

        public List<Subscriber> subscribers;
        public List<Service> services;

        public Company()
        {
            RecId = "";
            Name = "";
            Address = "";
            Hotline = false;
            subscribers = new List<Subscriber>();
            services = new List<Service>();
        }

        public Company(string id, string name)
        {
            RecId = id;
            Name = name;
            subscribers = new List<Subscriber>();
            services = new List<Service>();

        }

        public Company(string recId, string name, string address, bool hotline)
        {
            RecId = recId;
            Name = name;
            Address = address;
            Hotline = hotline;
            subscribers = new List<Subscriber>();
            services = new List<Service>();
        }

    }
}
