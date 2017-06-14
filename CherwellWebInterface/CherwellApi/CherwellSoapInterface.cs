using Classes;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace CherwellApi
{
    public class CherwellSoapInterface
    {
        private static CherwellOndemand.api _cherwellService;
        private static string updateCompanyXML = "<BusinessObject Name = \"Company\"> <FieldList> <Field Name = \"FullName\">{0}</Field> <Field Name = \"RawAddress\">{1}</Field> <Field Name = \"HotlineClient\">{2}</Field> </FieldList> </BusinessObject>";
        private static string updateSubscriberXML = "<BusinessObject Name = \"Subscriber\"> <FieldList> <Field Name = \"SubscriberID\">{0}</Field> <Field Name = \"RawAddress\">{1}</Field> <Field Name = \"Region\">{2}</Field> <Field Name = \"CustomerCompanyID\">{3}</Field> <Field Name = \"CustomerCompanyName\">{4}</Field> </FieldList> </BusinessObject>";

        public static List<Company> GetAllCompanies()
        {
            _cherwellService = new CherwellOndemand.api { CookieContainer = new CookieContainer() };
            List<Company> companyList;
            _cherwellService.Login("TestAPI", "TestAPI1");
            var comp = _cherwellService.QueryByStoredQuery("Company", "All Companies");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(comp);

            XmlNodeList nodes = doc.SelectNodes("CherwellQueryResult/Record");
            companyList = new List<Company>();

            foreach (XmlNode item in nodes)
            {
                companyList.Add(new Company(item.Attributes["RecId"].Value, item.SelectSingleNode("TitleText").InnerText));
            }
            _cherwellService.Logout();
            return companyList;
        }

        public static Company GetCompany(string recId)
        {

            _cherwellService = new CherwellOndemand.api { CookieContainer = new CookieContainer() };
            Company company;
            var res = _cherwellService.Login("TestAPI", "TestAPI1");
            var result = _cherwellService.GetBusinessObject("Company", recId, true);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNodeList nodes = doc.SelectNodes("BusinessObject/FieldList/Field");

            string address = "";
            string hotline = "";
            string name = "";
            bool bHotline = false;
            foreach (XmlNode item in nodes)
            {
                if (item.Attributes["Name"].Value == "FullName")
                {
                    name = item.InnerText;
                }
                if (item.Attributes["Name"].Value == "RawAddress")
                {
                    address = item.InnerText;
                }
                if (item.Attributes["Name"].Value == "HotlineClient")
                {
                    hotline = item.InnerText;
                    if (hotline.ToLower() == "true")
                    {
                        bHotline = true;
                    }
                    else
                    {
                        bHotline = false;
                    }
                }
            }

            company = new Company(recId, name, address, bHotline);

            XmlNodeList rels = doc.SelectNodes("BusinessObject/RelationshipList/Relationship");
            foreach (XmlNode item in rels)
            {
                if (item.Attributes["Name"].Value == "Company Links Subscriber")
                {
                    foreach (XmlNode sub in item.SelectNodes("BusinessObject"))
                    {
                        company.subscribers.Add(new Subscriber(sub.Attributes["RecID"].Value, sub.InnerText));
                    }
                }
                if (item.Attributes["Name"].Value == "Company Links Services")
                {
                    foreach (XmlNode sub in item.SelectNodes("BusinessObject"))
                    {
                        company.services.Add(new Service(sub.Attributes["RecID"].Value, sub.InnerText));
                    }
                }
            }
            _cherwellService.Logout();
            return company;
        }

        public static string UpdateCompany(Company company)
        {
            _cherwellService = new CherwellOndemand.api { CookieContainer = new CookieContainer() };
            string response;
            _cherwellService.Login("TestAPI", "TestAPI1");
            string xml = string.Format(updateCompanyXML, company.Name, company.Address, company.Hotline.ToString().ToUpper());
            if (company.RecId != "")
            {
                response = _cherwellService.UpdateBusinessObject("Company", company.RecId, xml).ToString();
            }
            else
            {
                response = _cherwellService.CreateBusinessObject("Company", xml);
            }
            _cherwellService.Logout();

            return response.ToString();
        }


        public static string DeleteCompany(string recId)
        {
            _cherwellService = new CherwellOndemand.api { CookieContainer = new CookieContainer() };
            _cherwellService.Login("TestAPI", "TestAPI1");
            var response = _cherwellService.RunOneStep("Company", recId, "Global", "CSDAdmin", "DeleteCompany", "");
            _cherwellService.Logout();

            return response.ToString();
        }

        public static List<Subscriber> GetAllSubscribers()
        {

            _cherwellService = new CherwellOndemand.api { CookieContainer = new CookieContainer() };
            List<Subscriber> subscriberList;
            _cherwellService.Login("TestAPI", "TestAPI1");
            var comp = _cherwellService.QueryByStoredQuery("Config - Subscriber", "All Subscribers");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(comp);

            XmlNodeList nodes = doc.SelectNodes("CherwellQueryResult/Record");
            subscriberList = new List<Subscriber>();


            foreach (XmlNode item in nodes)
            {
                subscriberList.Add(new Subscriber(item.Attributes["RecId"].Value, item.SelectSingleNode("TitleText").InnerText.Replace("Subscriber ID ", "")));
            }
            _cherwellService.Logout();
            return subscriberList;
        }

        public static Subscriber GetSubscriber(string recId)
        {


            Subscriber subscriber;
            _cherwellService.Login("TestAPI", "TestAPI1");
            var result = _cherwellService.GetBusinessObject("Config - Subscriber", recId, true);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNodeList nodes = doc.SelectNodes("BusinessObject/FieldList/Field");

            string name = "";
            string address = "";
            string region = "";
            string companyId = "";
            string companyName = "";
            foreach (XmlNode item in nodes)
            {
                if (item.Attributes["Name"].Value == "SubscriberID")
                {
                    name = item.InnerText;
                }
                if (item.Attributes["Name"].Value == "RawAddress")
                {
                    address = item.InnerText;
                }
                if (item.Attributes["Name"].Value == "Region")
                {
                    region = item.InnerText;
                }
                if (item.Attributes["Name"].Value == "CustomerCompanyID")
                {
                    companyId = item.InnerText;
                }
                if (item.Attributes["Name"].Value == "CustomerCompanyName")
                {
                    companyName = item.InnerText;
                }

            }
            subscriber = new Subscriber(recId, name, address, region, companyId, companyName);

            _cherwellService.Logout();
            return subscriber;
        }

        public static string UpdateSubscriber(Subscriber subscriber)
        {
            _cherwellService.Login("TestAPI", "TestAPI1");
            string xml = string.Format(updateSubscriberXML, subscriber.name, subscriber.address, subscriber.region, subscriber.companyId, subscriber.companyName);

            var response = _cherwellService.UpdateBusinessObject("Config - Subscriber", subscriber.recId, xml);
            _cherwellService.Logout();

            return response.ToString();
        }
    }
}
