using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Company
    {
        public string comp_recId;
        public string comp_name;
        public string comp_address;
        public string comp_hotline;

        public List<Subscriber> subscribers;
        public List<Service> services;

        public Company()
        {
            comp_recId = "";
            comp_name = "";
            comp_address = "";
            comp_hotline = "";
            subscribers = new List<Subscriber>();
            services = new List<Service>();
        }

        public Company(string id, string name)
        {
            comp_recId = id;
            comp_name = name;
            subscribers = new List<Subscriber>();
            services = new List<Service>();

        }

        public Company(string recId, string name, string address, string hotline)
        {
            comp_recId = recId;
            comp_name = name;
            comp_address = address;
            comp_hotline = hotline;
            subscribers = new List<Subscriber>();
            services = new List<Service>();
        }
    }
}
