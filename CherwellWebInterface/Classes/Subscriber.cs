using System.ComponentModel.DataAnnotations;

namespace Classes
{
    public class Subscriber
    {

        public string recId;
        [Required(ErrorMessage = "Subscriber Name is Required")]
        [Display(Name = "Subscriber Name")]
        public string name;
        public string address;
        public string region;
        public string companyId;
        public string companyName;

        public Subscriber(string id, string name)
        {
            recId = id;
            this.name = name;
        }

        public Subscriber(string id, string name, string address, string region, string companyId, string companyName)
        {
            recId = id;
            this.name = name;
            this.address = address;
            this.region = region;
            this.companyId = companyId;
            this.companyName = companyName;
        }
    }
}
