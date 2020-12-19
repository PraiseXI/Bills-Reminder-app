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
        public DateTime Next_Due { get; set; }
        public int Days_until_next { get; set; } //will subtract the date due from todays date
        public int How_often { get; set; } //not to display, for me to set reminder frequency
        public double Amount_left { get; set; }
        public string Company_name { get; set; }

        public Bill() { }

        public Bill(int billno = 0, string title = "No Title", double cost = 0, DateTime? nextDue = null, int days_until_next = 0, int how_often = 0, double amount_left = 0, string company_name = "no name")
        {
            billno = BillNo;
            title = Title;
            cost = Cost;
            nextDue = Next_Due;
            days_until_next = Days_until_next;
            how_often = How_often;
            amount_left = Amount_left;
            company_name = Company_name;
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
            Next_Due = (DateTime)info.GetValue("NextDue", typeof(DateTime));
            Days_until_next = (int)info.GetValue("DaysUntilNext", typeof(int));
            How_often = (int)info.GetValue("HowOften", typeof(int));
            Amount_left = (double)info.GetValue("AmountLeft", typeof(double));
            Company_name = (string)info.GetValue("CompanyName", typeof(string));
        }
    }
}
