using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace laba_133
{      
    class ADJLog
    {
        public FileInfo file;//поле

        public ADJLog()//конструктор
        {
            file = new FileInfo("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJlogfile.txt");
        }

        public void Add(string a)//метод//записи в текстовый файл
        {
            using (StreamWriter writer = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))//?
               
            {
                writer.WriteLine(DateTime.Now + " - " + a);//pishem v fayl wremya i stroku
            }
            
        }

        public void Read()//метод//чтения
        {
            StreamReader reader = new StreamReader(file.ToString());//?
            {
                int a = 0;
                while (true)
                {
                    if (reader.EndOfStream)//esli konec fayla to break
                    {
                        break;
                    }
                    Console.WriteLine(reader.ReadLine());
                    a++;
                }
                Console.WriteLine("Кол.-во записей в файле: " + a);
            }
            reader.Close();
        }

        public void Search()//метод//поиска нужной информации.
        {

            Console.WriteLine("Поиск: \n1. Указать дату.\n2. Указать ключевое слово.");
            string a, b;
            int r;
            r = int.Parse(Console.ReadLine());//?
            switch (r)
            {
                case 1:
                    using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                    {
                        Console.WriteLine("Укажите дату в формате <<01.01.2001>> : ");
                        a = Console.ReadLine();
                        while (true)
                        {
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                            if (reader.ReadLine().Contains(a))
                            {
                                Console.WriteLine(reader.ReadLine());
                            }
                        }
                    }
                    break;

                case 2:
                    using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                    {
                        Console.WriteLine("Введите ключевое слово: ");
                        a = Console.ReadLine();
                        while (true)
                        {
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                            if (reader.ReadLine().Contains(a))
                            {
                                Console.WriteLine(reader.ReadLine());
                            }
                        }
                    }
                    break;
            }
        }

    }

    class ADJDiskInfo : ADJLog
    {
        public void FreePlace()
        {
          Add("(ADJDiskInfo)Получаем информацию о дисках системы.");//ADJLog.Add
            var allinfo = DriveInfo.GetDrives();//DriveInfo- klass informacii o diske//GetDrivers-vozwr vseh diskov na kompe
            foreach (var d in allinfo)//перебираем 
            {
              if (!d.IsReady) continue;
                {
                    Console.WriteLine("Метка тома: {0}", d.RootDirectory);//метка тома.
                    Console.WriteLine("Имя диска: {0}", d.Name);//имя,
                    Console.WriteLine("Обьём: {0}", d.TotalSize);//объем,
                    Console.WriteLine("Доступный Обьём: {0}", d.AvailableFreeSpace);//доступный объем,
                    Console.WriteLine("Свободно места: {0}", d.TotalFreeSpace);//свободном месте на диске
                    Console.WriteLine("Файловая система: {0}", d.DriveFormat);//Файловой системе
                }
            }
        }
    }

    class ADJFileInfo : ADJLog
    {
        public FileInfo filee;//поле//klass informacii o fayle
        public ADJFileInfo()//конструктор
        {
            filee = new FileInfo("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJfileInfo.txt");
        }
        public void fileInfo()//метод
        {
            Add("(ADJFileInfo)Выполняем вывод информации о файле " + filee.ToString());
            Console.WriteLine($"Полный путь: {filee.DirectoryName}");
            Console.WriteLine($"Имя: {filee.Name}");
            Console.WriteLine($"Расширение: {filee.Extension}");
            Console.WriteLine($"Время создания: {filee.CreationTime}");
        }
    }

    class ADJDirInfo : ADJLog
    {
        public string dir = "D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\Games";//поле
        public void DirInfo()//метод
        {
            
          
                Add("(ADJDirInfo)Получаем информацию о файлах и директориях в " + dir);
                string[] files = Directory.GetFiles(dir);//получаем все файлы в директории
                string[] ddir = Directory.GetDirectories(dir);//получаем все директории в директории
                int a = 0;
                int b = 0;
                foreach (string s in files)
                {
                    a++;//считаем количество файлов
                }
                foreach (string s in ddir)
                {
                    b++;//считаем количество директориев
                }
            Console.WriteLine("Количество файлов в папке: " + a);//Количестве файлов
            Console.WriteLine("Время создания папки: " + Directory.GetCreationTime(dir));//Время создания
            Console.WriteLine("Количетсво поддиректориев в папке: " + b);//Количестве поддиректориев
            Console.WriteLine("Список родительских директориев: " + Directory.GetParent(dir));//Список родительских директориев
            
        }
    }

    class ADJFileManager : ADJLog
    {
        public string disk = "D:\\";//поле

        public DirectoryInfo[] directory;//массивный обьект класса DirestoryInfo
        public FileInfo fileee;//обьект класса FileInfo
        
        
        public string[] directoryes;
        public string[] files;

  
            public void Worker()//метод
        {
            Add("(ADJFileManager)Получаем файлы и директории в " + disk);
            directoryes = Directory.GetFiles(disk);//получаем все файлы в директории
            files = Directory.GetDirectories(disk);//получаем все директории в директории

            directory = new DirectoryInfo[2];
            directory[0] = new DirectoryInfo("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJInspect");//Создать директорий XXXInspect,
            directory[1] = new DirectoryInfo("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJFiles");
            directory[0].Create();
            directory[1].Create();
            fileee = new FileInfo("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJdirinfo.txt");
           

            Add("Создаем файл" + fileee.ToString());
            Add("Записываем информацию о файлах и папках в " + fileee.ToString());

            using (StreamWriter fs = new StreamWriter(fileee.ToString(), true, System.Text.Encoding.Default))
            {
                foreach (string s in files)
                {
                    fs.WriteLine(s);
                }
                foreach (string s in directoryes)
                {
                    fs.WriteLine(s);
                }
                Console.WriteLine("Текст записан в файл.");
            }
              

            File.Copy("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJdirinfo.txt", "D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJdirinfoCopy.txt");
            File.Delete("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJdirinfo.txt");


            DirectoryInfo dir = new DirectoryInfo("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\good");//создал еще одну директорию
            Add("Получаем информацию о jpg файлах в D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\good");
            FileInfo[] f = dir.GetFiles("*.jpg");//yokaryny oka
            Add("Копируем файлы jpg из good в MVSInspect");
            foreach (FileInfo s in f)
            {
                s.CopyTo("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJFiles\\" + s.Name, true);//??
            }
            Add("Перемещаем " + directory[1].ToString() + " в " + directory[0].ToString());
            directory[1].MoveTo("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ADJInspect\\ADJFiles");


            ZipFile.CreateFromDirectory(directory[1].ToString(), "D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ya.zip");//navedi
            Add("Разархивируем ya.zip в D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\zipucin");
            ZipFile.ExtractToDirectory("D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\ya.zip", "D:\\фит\\ООП\\1 семестр лабы\\13_2 laba\\zipucin");

            
        }
    }



class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2 Пункт");
            ADJDiskInfo second = new ADJDiskInfo();
            second.FreePlace();
            Console.WriteLine();
            Console.WriteLine("3 Пункт");
            ADJFileInfo third = new ADJFileInfo();
            third.fileInfo();
            Console.WriteLine();
            Console.WriteLine("4 Пункт");
            ADJDirInfo fourth = new ADJDirInfo();
            fourth.DirInfo();
            Console.WriteLine();
            Console.WriteLine("5 Пункт");
            ADJFileManager fileManager = new ADJFileManager();
            fileManager.Worker();
            Console.WriteLine();

            Console.WriteLine("6 Пункт");
            ADJLog log = new ADJLog();
            log.Read();
            log.Search();

        }
    }
}
