/*
Create any user defined class of your choice like Student, Customer etc. Add 3 properties in it (of your choice). Serialize and deserialize the object of this class by Binary, XML, JSON format.
*/


using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Xml.Serialization;

namespace Assignment_10._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Mike", "Flores", "MFlores", 12345, true, 55675);

            // JSON Serialization
            string jsonString = JsonSerializer.Serialize(customer);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(jsonString);
            Console.WriteLine();

            Customer deserializedJsonCustomer = JsonSerializer.Deserialize<Customer>(jsonString);
            Console.WriteLine("Deserialized JSON Customer:");
            PrintCustomer(deserializedJsonCustomer);
            Console.WriteLine();

            // XML Serialization
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Customer));
            string xmlString;
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, customer);
                xmlString = textWriter.ToString();
            }
            Console.WriteLine("Serialized XML:");
            Console.WriteLine(xmlString);
            Console.WriteLine();

            Customer deserializedXmlCustomer;
            using (StringReader textReader = new StringReader(xmlString))
            {
                deserializedXmlCustomer = (Customer)xmlSerializer.Deserialize(textReader);
            }
            Console.WriteLine("Deserialized XML Customer:");
            PrintCustomer(deserializedXmlCustomer);
            Console.WriteLine();

        }    

        // Method to print customer details in deserialized form ie. C#
        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"FirstName: {customer.FirstName}");
            Console.WriteLine($"LastName: {customer.LastName}");
            Console.WriteLine($"UserName: {customer.UserName}");
            Console.WriteLine($"AccountNumber: {customer.AccountNumber}");
            Console.WriteLine($"IsLoyalty: {customer.IsLoyalty}");
            Console.WriteLine($"LoyaltyNumber: {customer.LoyaltyNumber}");
        }



    
    }

    public class Customer
    {
        private string _firstName;      
        
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _userName;
        public string UserName 
        {
            get{ return _userName; }
            set { _userName = value; } 
        }
        public int AccountNumber { get; set; }
        public bool IsLoyalty { get; set; }
        public int LoyaltyNumber { get; set;}

        public Customer()
        {
            // needed in order to pass do serialized SML
        }
       
        public Customer(string firstName, string lastName, string userName, int accountNumber, bool isLoyalty, int loyaltyNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            AccountNumber = accountNumber;
            IsLoyalty = isLoyalty;
            LoyaltyNumber = loyaltyNumber;
        } 
    }

}
