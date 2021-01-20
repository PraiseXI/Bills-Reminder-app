using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Bills_Reminder_app
{
    class Program
    {
        //TODO
        static void billInputQuestions()
        {
            Console.WriteLine("Enter the name of the bill");
            Console.WriteLine("H0ow much is each payment of the bill");
        }

        //TODO
        static void deserializer()
        {

        }

        static void Main(string[] rgs)
        {
            // to create a new object and insert values manually; will need to make this based on user input
            Bill Netflix = new Bill(1, "Netflix Premium", 12.99,"11/11/2000", 50, 28, "N/A", "Netflix");

            //serializes the object
            Stream stream = File.Open("BillsData.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, Netflix);

            stream.Close();
            Netflix = null;

            stream = File.Open("BillsData.dat", FileMode.Open);

            bf = new BinaryFormatter();

            Netflix = (Bill)bf.Deserialize(stream);
            stream.Close();

            Console.WriteLine(Netflix.ToString());

            Netflix.Cost = 15.99;

            XmlSerializer serializer = new XmlSerializer(typeof(Bill));

            using (TextWriter tw = new StreamWriter(@"C:\Users\prais\Documents\Programming\Personal Projects\Bills Reminder app\data\NetflixBill.xml"))
            {
                serializer.Serialize(tw, Netflix);
            }
            Netflix = null;

            XmlSerializer deserializer = new XmlSerializer(typeof(Bill));

            TextReader reader = new StreamReader(@"C:\Users\prais\Documents\Programming\Personal Projects\Bills Reminder app\data\NetflixBill.xml");
            object obj = deserializer.Deserialize(reader);
            Netflix = (Bill)obj;
            reader.Close();

            List<Bill> MyBills = new List<Bill>
            {
                new Bill(1, "Phone Bill", 10.00, "05/02/2021", 16, 31, "N/A", "VOXI"),
                new Bill(2, "Netflix Subscription", 2.00, "14/02/2021", 25, 31, "N/A", "Netflix"),
                new Bill(3, "Spotify Subscription", 3.00, "27/01/2021", 7, 31, "N/A", "Spotify")

            };

             using (Stream fs = new FileStream(@"C:\Users\prais\Documents\Programming\Personal Projects\Bills Reminder app\data\MyBills.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Bill>));
                serializer2.Serialize(fs, MyBills);
            }

            MyBills = null;

            //Read Data from XML
            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Bill>));
            using (FileStream fs2 = File.OpenRead(@"C:\Users\prais\Documents\Programming\Personal Projects\Bills Reminder app\data\MyBills.xml"))
            {
                MyBills = (List<Bill>)serializer3.Deserialize(fs2);
            }

            foreach(Bill x in MyBills)
            {
                Console.WriteLine(x.ToString());
            }





                Console.ReadLine();

            // billInputQuestions();
        }
    }
}