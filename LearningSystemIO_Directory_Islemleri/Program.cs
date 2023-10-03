using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystemIO_Directory_Islemleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // createNewDirectory("C:\\Udemy");
            // Console.WriteLine(isExistsDirectory("C:\\Udemy"));
            // deleteDirectory("C:\\Udemy");

            // odev1("C:\\Udemy");

            movingDirectory("C:\\Udemy", "C:\\TasimaIslemi\\Udemy");

        }
        static void createNewDirectory(string path)                 // Belirtilen path'de klasör oluşturur.
        {
            DirectoryInfo dInfo = Directory.CreateDirectory(path);
        }
        static bool isExistsDirectory(string path)                  // Belirtilen path'de klasör olup olmadığını kontrol eder.
        {
            return Directory.Exists(path);
        }
        static void deleteDirectory(string path)                    // Belirtilen path'deki klasörü siler!
        {
            Directory.Delete(path, true);                           // true değeri, belirtilen path içinde herhangi bir dosya veya klasör varsa 
                                                                    // silip silmemek konusunda bizden izin almak ama amacı ile konulmuş bir parametredir.
        }               
        static void odev1(string path)
        {
            /*
             * C sürücüsü içerisinde Udemy adında bir klasör oluşturun, oluşturmadan önce varlık kontrolü yapın. Eğer klasör varsa silin daha sonra oluşturun
             * Eğer klasör yok ise oluşturun fakat bu adım bilgisini ekrana yazdırın.
             */

            #region Benim Yaptığım
            /*

            if(isExistsDirectory((string)path))
            {
                Console.WriteLine("Bu dosya zaten mevcuttur. Alt klasörleri ile birlikte silmek ister misin? Yes or No [Y-N]");
                
                // Kullanıcının girdiği harfi kontrol etme...
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input.Length == 1 && char.IsLetter(input[0]))
                    {
                        char letter = char.ToUpper(input[0]); // Harfi büyük harfe çevirdik.
                        
                        if(letter == 'Y')
                        {
                            deleteDirectory(path);
                            Console.WriteLine("Dosya şimdi tekrardan oluşturuluyor!");
                            createNewDirectory(path);
                            Console.WriteLine("Dosya oluşturuldu!");
                            break;
                        }
                        else if(letter == 'N')
                        {
                            Console.WriteLine("Dosya silinmedi!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lütfen Y veya N yazın");
                    }
                }
            }
            else
            {
                Console.WriteLine("Dosya mevcut değil!");
                createNewDirectory((string)path);
                Console.WriteLine("Şimdi oluşturuldu!");
            }

            */
            #endregion

            #region Hocanın yaptığı
            string directoryPath = @"C:\Udemy";
            bool control = Directory.Exists(directoryPath);
            if (control)
            {
                Console.WriteLine("Eklemek istediğiniz klasör sistemde mevcut!");
                Console.WriteLine("Silmek ve yeni olarak oluşturmak ister misiniz? Y/N");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "Y")
                {
                    Directory.Delete(directoryPath, true);
                    Console.WriteLine("Dosya silme işlemi tamamlandı!");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine(directoryPath + " sisteminize oluşturuluyor!");
                    Directory.CreateDirectory(directoryPath);
                }
                else
                {
                    Console.WriteLine("İşlem bitti!");
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(directoryPath);
                if (directoryInfo.Exists)
                {
                    Console.WriteLine("Dosya sistemde oluşturuldu!");
                }
            }
            #endregion
        }
        static void movingDirectory(string source, string target)   // Target ve source değerlerine göre belirtilen dosyayı belirtilen hedefe taşır!
        {
            Directory.Move(source, target);
        }
    }
}
