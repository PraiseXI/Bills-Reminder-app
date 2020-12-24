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
        static void startupQuestions()
        {
            Console.WriteLine("");
        }

        static void billInputQuestions()
        {
            Console.WriteLine("Enter the name of the bill");
            Console.WriteLine("H0ow much is each payment of the bill");
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

            Console.WriteLine(Netflix.ToString());

            Console.ReadLine();

            // billInputQuestions();
        }
    }
}
