using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;


namespace GmailNotifier
{

    class GmailClient
    {

        private DateTime _lastModified;

        public GmailClient(string username, string password)
        {
            Username = username;
            Password = password;

            Emails = new List<Email>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<Email> Emails { get; set; }

        public bool GotMail { get; set; }

        public bool Updated { get; set; }

        public CheckEmailResult LastResult { get; set; }

        public CheckEmailResult CheckEmail()
        {

            XmlUrlResolver resolver = new XmlUrlResolver();
            XmlReaderSettings settings = new XmlReaderSettings();
            resolver.Credentials = new NetworkCredential(Username, Password);
            settings.XmlResolver = resolver;

            XmlReader reader = null;

            try
            {
                reader = XmlReader.Create("https://mail.google.com/mail/feed/atom/", settings);
            }
            catch (WebException ex)
            {

                if ((ex.Response != null) &&
                    (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.Unauthorized))
                        return LastResult = CheckEmailResult.AccountError;

                return LastResult = CheckEmailResult.NetworkError;
                
            }

            XDocument doc = XDocument.Load(reader);

            XNamespace n = doc.Root.Attribute("xmlns").Value;

            GotMail = false;

            DateTime modified = DateTime.Parse(doc.Root.Element(n + "modified").Value);

            if (_lastModified == modified)
                return LastResult = CheckEmailResult.Success;

            _lastModified = modified;
             
            List<Email> emails = new List<Email>();

            foreach (XElement entry in doc.Root.Elements(n + "entry"))
            {

                emails.Add(new Email()
                {
                    ID = entry.Element(n + "id").Value,
                    Subject = entry.Element(n + "title").Value,
                    Sender = entry.Element(n + "author").Element(n + "name").Value,
                    SenderAddress = entry.Element(n + "author").Element(n + "email").Value,
                    Body = entry.Element(n + "summary").Value,
                    Date = DateTime.Parse(entry.Element(n + "issued").Value),
                    Link = entry.Element(n + "link").Attribute("href").Value,
                    Modified = DateTime.Parse(entry.Element(n + "modified").Value),
                });

            }

            //if there are any emails in the new list that arent in the old list
            if (emails.Where(e => Emails.Where(i => i.ID == e.ID).Count() == 0).Count() > 0)
            {
                Updated = true;
                GotMail = true;
            }

            //if there are any emails in the old list missing from the new list
            else if (Emails.Where(e => emails.Where(i => i.ID == e.ID).Count() == 0).Count() > 0)
                Updated = true;

            //if any of the emails we already have have new modified dates
            else if (emails.Where(e => Emails.Where(i => i.ID == e.ID).Single().Modified != e.Modified).Count() > 0)
                Updated = true;

            if (Updated)
                Emails = emails;

            return LastResult = CheckEmailResult.Success;

        }


    }

    public class Email
    {

        public string ID { set; get; }

        public string Sender { set; get; }

        public string SenderAddress { set; get; }

        public string Subject { set; get; }

        public string Body { set; get; }

        public DateTime Date { set; get; }

        public string Link { set; get; }

        public DateTime Modified { set; get; }

    }

    public enum CheckEmailResult
    {
        None,
        Success,
        NetworkError,
        AccountError,
    }

}
