using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bills_Reminder_app
{
    [Serializable()]
    public class Bill : ISerializable
    {
        public int BillNo { get; set; }
        public string Title { get; set; }
        public Double Cost { get; set; }
        public string Next_Due { get; set; } //had troubling passing a DateTime as argument so will parse to string at very last stage after all the error checks etc.
        public int Days_until_next { get; set; } //will subtract the date due from todays date
        public int How_often { get; set; } //not to display, for me to set reminder frequency
        public string Amount_left { get; set; } //it will be a string as it can also be a string if it there is no total amount (e.g recurring subscription
        public string Company_name { get; set; }

        public Bill() { }

        public Bill(int billno = 0, string title = "No Title", double cost = 0, string nextDue = "31/01/2021", int days_until_next = 0, int how_often = 0, string amount_left = "N/A", string company_name = "no name")
        {
            BillNo = billno;
            Title = title;
            Cost = cost;
            Next_Due = nextDue;
            Days_until_next = days_until_next;
            How_often = how_often;
            Amount_left = amount_left;
            Company_name = company_name;
        }

        public override string ToString()
        {
            return string.Format("Your most recent upcoming bill is to {0} for {1} for £{2} which is due on {3}. You have £{4} left to pay off", Company_name, Title, Cost, Next_Due, Amount_left);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BillNo", BillNo);
            info.AddValue("Title", Title);
            info.AddValue("Cost", Cost);
            info.AddValue("NextDue", Next_Due);
            info.AddValue("DaysUntilNext", Days_until_next);
            info.AddValue("HowOften", How_often);
            info.AddValue("AmountLeft", Amount_left);
            info.AddValue("CompanyName", Company_name);
        }
        public Bill(SerializationInfo info, StreamingContext context)
        {
            BillNo = (int)info.GetValue("BillNo", typeof(int));
            Title = (string)info.GetValue("Title", typeof(string));
            Cost = (double)info.GetValue("Cost", typeof(double));
            Next_Due = (string)info.GetValue("NextDue", typeof(string));
            Days_until_next = (int)info.GetValue("DaysUntilNext", typeof(int));
            How_often = (int)info.GetValue("HowOften", typeof(int));
            Amount_left = (string)info.GetValue("AmountLeft", typeof(string));
            Company_name = (string)info.GetValue("CompanyName", typeof(string));
        }
    }
}
