namespace Classes
{
    public class Subscriber
    {

        public string recId;
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
