using Scaner.Service;
using Scaner.Service.Pathfinders;
using Scaner.Service.Scaner;
using System;
using System.IO;
using System.Linq;

namespace Scaner
{
    class Program
    {

        static void Main(string[] args)
        {
            PathfinderFile pathfinderFile = new PathfinderFile();
            PathfinderDirectrory pathfinderDirectrory = new PathfinderDirectrory(pathfinderFile);
            ScanerAvgSize scanerAvgSize = new ScanerAvgSize(pathfinderFile);
            ScanerTypeCount scanerType = new ScanerTypeCount(pathfinderFile);
            ScanerManager scanerManager = new ScanerManager(pathfinderDirectrory, pathfinderFile, scanerAvgSize, scanerType);

            while (true)
            {
                Console.WriteLine("Выберите команду 1 если хоите Узнать полную информацию о директории. 2 Если хоте о определенном файле. 0 если ничего не хотите ");
                string comanda = Console.ReadLine();
                if (comanda == "1")
                {
                    Console.WriteLine("Введите путь");
                    string path = Console.ReadLine();

                    scanerManager.WriteAllData(new DirectoryInfo(path));
                }
                if (comanda == "2")
                {
                    Console.WriteLine("Введите путь");
                    string path = Console.ReadLine();

                    Console.WriteLine("Введите тип файла");
                    string type = Console.ReadLine();

                    scanerManager.WriteDataFiles(new DirectoryInfo(path), type);
                }
                if (comanda == "0")
                    break;          
            }

        }
    }

     
    

}