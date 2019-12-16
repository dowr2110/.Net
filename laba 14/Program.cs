using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace Lab_14
{
    [Serializable]
   public class Test
    {
        public string typeoftest; // поле тип теста
        public string difficult;
        public int maxball;
        public Test() { }
        public Test(string type, string dif, int max)//konstruktor s 3 param
        {
            typeoftest = type;
            difficult = dif;
            maxball = max;
        }
        
        public string Tst
        {
            get
            { return typeoftest; }
            set
            { typeoftest = value; }
        }//svoysta 
        public string Diffic
        {
            get
            { return difficult; }
            set
            { difficult = value; }
        }//svoysta
        public int Maxb
        {
            get
            { return maxball; }
            set
            { maxball = value; }
        } 
        
        public void Info() // реализуем метод 
        {
            Console.WriteLine(typeoftest);
        }
    }

    public class XMLer
    {
        ///xPAth- язык запросов в xml. позволяет выберать элементы соотвествющее определенного селектора
        XmlDocument xmlDoc;
            public XMLer()
        {
            xmlDoc=new XmlDocument();//представляет xml документ
            xmlDoc.Load("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\four.xml");//загружаю документ
        }
        public void XPath()
        {
            
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("day[dayname='СРЕДА']");//выбераешь с xml по определнному тегу и с опр параметром
            XmlNodeList nodeList2 = xmlDoc.DocumentElement.SelectNodes("day[dayname='ВТОРНИК']");//выбераешь с xml по определнному тегу и с опр параметром

            foreach (XmlNode x in nodeList)
            {
                Console.WriteLine(x.InnerXml);
            }

            Console.WriteLine();
            foreach (XmlNode x in nodeList2)
            {
                Console.WriteLine(x.InnerXml);

            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test("KR","easy", 10);
            Console.WriteLine("1 ЗАДАНИЕ");
            Console.WriteLine("Объект создан");

            // создаем объект BinaryFormatter
            BinaryFormatter bnformatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\dowr.dat", FileMode.OpenOrCreate))
            {
                bnformatter.Serialize(fs, test);
                Console.WriteLine("Объект сериализован (бинарный)");
            }

            // десериализация из файла dowr.dat
            using (FileStream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\dowr.dat", FileMode.OpenOrCreate))
            {
                Test newTestBN = (Test)bnformatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован (бинарный)");
                Console.WriteLine($"ТипТеста: {newTestBN.Tst} --- МаксБал: {newTestBN.Maxb}");
            }

            Console.WriteLine();




            // создаем объект Json
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Test));
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\dowr.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, test);
                Console.WriteLine("Объект сериализован (JSON)");
            }
            // десериализация из файла dowr.dat
            using (FileStream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\dowr.json", FileMode.OpenOrCreate))
            {
                Test newTestJS = (Test)jsonFormatter.ReadObject(fs);
                Console.WriteLine("Объект десериализован (JSON)");
                Console.WriteLine($"ТипТеста: {newTestJS.Tst} --- МаксБал: {newTestJS.Maxb}");
            }
            Console.WriteLine();



            // создаем объект Soap
            SoapFormatter soapFormatter = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\dowr.soap", FileMode.OpenOrCreate))
           
            {
                soapFormatter.Serialize(fs, test);
                Console.WriteLine("Объект сериализован (SOAP)");
            }
            using (FileStream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\dowr.soap", FileMode.OpenOrCreate))
            {
                Test newTestSP = (Test)soapFormatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован (SOAP)");
                Console.WriteLine($"ТипТеста: {newTestSP.Tst} --- МаксБал: {newTestSP.Maxb}");
            }
            Console.WriteLine();



            // создаем объект XML
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Test));
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\dowr.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fs, test);
                Console.WriteLine("Объект сериализован (XML)");
            }
            using (FileStream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\dowr.xml", FileMode.OpenOrCreate))
            {
              
                Test newTestXML = xmlFormatter.Deserialize(fs) as Test;
                Console.WriteLine("Объект десериализован (XML)");
              Console.WriteLine($"ТипТеста: {newTestXML.Tst} --- МаксБал: {newTestXML.Maxb}");
            }
            Console.WriteLine();


            Console.WriteLine("2 ЗАДАНИЕ");
            Test test2 = new Test("TEST", "difficult", 6);
            Test test3 = new Test("Dictation", "normal", 5);
            List<Test> myList = new List<Test>();
            myList.Add(test);
            myList.Add(test2);
            myList.Add(test3);
            DataContractJsonSerializer jsonSerializerForList = new DataContractJsonSerializer(typeof(List<Test>));
            using (Stream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\list.json", FileMode.OpenOrCreate))
            {
                jsonSerializerForList.WriteObject(fs, myList);
                Console.WriteLine("лист сериализован (BN)");
            }
            using (Stream fs = new FileStream("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\list.json", FileMode.OpenOrCreate))
            {
                List<Test> newTestBN = (List<Test>)jsonSerializerForList.ReadObject(fs);
                foreach (Test ml in newTestBN)
                {
                    Console.WriteLine($"ТипТеста: {ml.Tst} --- МаксБал: {ml.Maxb}");
                }
            }

            ////////////////////////////////////////////////////////////////////////////////
            ///xPAth- язык запросов в xml. позволяет выберать элементы соотвествющее определенного селектора
            Console.WriteLine();
            Console.WriteLine("3 ЗАДАНИЕ");
            XMLer xpath=new XMLer();
            xpath.XPath();
            ////////////////////////////////////////////////////////////////////////////////////

            XDocument newXmlDoc = new XDocument(
                new XElement("books",
                new XElement("book",
                new XElement("Title", "123"),
                new XElement("Author", "456"),
                new XElement("Price", 200)),
                new XElement("book",
                new XElement("Title", "qwe"),
                new XElement("Author", "456"),
                new XElement("Price", 400)),
                new XElement("book",
                new XElement("title", "asd"),
                new XElement("Author", "asd"),
                new XElement("Price", 600)),
                new XElement("book",
                new XElement("Title", "zxc"),
                new XElement("Author", "456"),
                new XElement("Price", 800)
                )
                ));//заполняем наш xml
            Console.WriteLine("4 ЗАДАНИЕ_1");
            // Использование синтаксиса выражения запроса
            var list1 = from xe in newXmlDoc.Element("books").Elements("book")//dine booklaryn icinden gecyas
                        where xe.Element("Author").Value == "456"//booklan icinden author 456 lary aldyk
                        select xe;
            foreach (var x in list1)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("4 ЗАДАНИЕ_2");
            // Использование синтаксиса выражения запроса
            var list2 = from xe in newXmlDoc.Element("books").Elements("book")//dine booklaryn icinden gecyas
                        where Convert.ToInt32(xe.Element("Price").Value) >= 400//booklan icinden dine price 400 yada uly bolanlary alyas
                        select xe;
            foreach (var x in list2)
            {
                Console.WriteLine(x);
            }
            newXmlDoc.Save("D:\\фит\\ООП\\1 семестр лабы\\14 laba\\LinqXml.xml");

        }
   
    }
}


//Что такое сериализация, десериализация
//что такое XPath (XML Path Language)— язык запросов к элементам XML-документа.
//Какие существуют форматы сериализации?