using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LearningSystemIO_FileIslemleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Bütün dosya işlemleri
            string path     = "C:\\Learning\\Udemy";
            string target   = "C:\\Learning\\Udemy2";
            
            string directoryPath1 = "C:\\Udemy";
            string directoryPath2 = "C:\\Udemy2";
            
            char input;

            /*
             * File işlemlerini yapmadan önce yukarıda kendinize path ve target seçip onları oluşturmanız gerekmektedir.
             * Elinizle oluşturabilirsiniz veya aşağıdaki kodları da kullanabilirsiniz!
             * 
             * Bunları yapmadan taktir edersiniz ki hata alırsınız :D
             */


            if (!Directory.Exists(directoryPath1) && !Directory.Exists(directoryPath2))
            {
                Console.WriteLine("Klasörler oluşturuluyor!");
                Directory.CreateDirectory(directoryPath1);
                Directory.CreateDirectory(directoryPath2);
                System.Threading.Thread.Sleep(1000);

                Console.WriteLine("Klasörler oluşturdu!");
            }
            else
            {
                Console.WriteLine("İstenilen klasörler mevcut!");
            }


            do
            {
                Console.WriteLine("Yapmak istediğiniz işlem nedir?");
                Console.WriteLine(  "0- Uygulamadan çıkış\n" +
                                    "1- Dosyaları görüntüle!\n" +
                                    "2- Dosya oluşturma işlemi\n" +
                                    "3- Dosya taşıma işlemi\n" +
                                    "4- Dosya kopyalama işlemi\n" +
                                    "5- Dosya silme işlemi\n");
                
                string line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Geçersiz giriş. Tekrar deneyin!");
                    break;
                }
                else 
                {
                    input = line[0]; 
                }
                if (char.IsDigit(input))
                {
                    switch(input)
                    {
                        #region Sistemden çıkış kodları
                        case '0':
                            return;
                        #endregion

                        #region Dosya görüntüleme
                        case '1':
                            string[] fileList1 = Directory.GetFiles(path);
                            string[] fileList2 = Directory.GetFiles(target);

                            Console.WriteLine("\n1.Klasördeki Dosyalar:");
                            Console.WriteLine("________________________");
                            if(fileList1.Length != 0)
                            {
                                foreach (string file in fileList1)
                                {
                                    Console.WriteLine(file);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Klasör Boş!");
                            }

                            Console.WriteLine("\n2.Klasördeki Dosyalar:");
                            Console.WriteLine("________________________");
                            if (fileList2.Length != 0)
                            {
                                foreach (string file in fileList2)
                                {
                                    Console.WriteLine(file);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Klasör boş!");
                            }
                            break;
                        #endregion

                        #region Dosya oluşturma
                        case '2':
                            Console.WriteLine("Dosya ismi ne olsun?");
                            string inputName = Console.ReadLine();
                            
                            
                            string lastPath = path + "\\"+ fileNameRegulation(inputName) + ".txt";

                            if (fileExists(lastPath))
                            {
                                Console.WriteLine("Bu dosya ismi zaten mevcut");
                            }
                            else
                            {
                                Console.WriteLine("Dosya oluşturuluyor!");
                                fileCreate(lastPath);
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("Dosya oluşturuldu!");
                            }

                            break;
                        #endregion

                        #region Dosya Taşıma
                        case '3':
                            Console.WriteLine("Taşımak istediğiniz dosyanın adını yazın:");
                            string fileName = Console.ReadLine();
                            string lastFourCharacter = fileName.Substring(fileName.Length - 4);
                            if (lastFourCharacter == ".txt")
                            {
                                string lastName = fileName.Replace(".txt", "");
                                Console.WriteLine("Düzeltme işlemlerinden sonra dosya taşınıyor!");
                                System.Threading.Thread.Sleep(1000);

                                string fileToBeMove = path      + "\\" +   fileNameRegulation(lastName) + ".txt";
                                string fileTarget   = target    + "\\" +   fileNameRegulation(lastName) + ".txt";

                                if (fileExists(fileTarget))
                                {
                                    Console.WriteLine("Dosya burada zaten mevcut!");
                                }
                                else
                                {
                                    fileMove(fileToBeMove, fileTarget);
                                    Console.WriteLine("Dosya taşındı!");
                                }
                            }
                            break;
                        #endregion

                        #region Dosya Kopyalama
                        case '4':
                            Console.WriteLine("Kopyalamak istediğniz dosyanın adını yazın:");
                            fileName = Console.ReadLine();
                            lastFourCharacter = fileName.Substring(fileName.Length - 4);
                            if(lastFourCharacter == ".txt")
                            {
                                string lastName = fileName.Replace(".txt", "");
                                Console.WriteLine("Düzeltme işlemlerinden sonra dosya taşınıyor!");
                                System.Threading.Thread.Sleep(1000);

                                string fileToBeCopy = path      + "\\" +   fileNameRegulation(lastName) + ".txt";
                                string fileTarget   = target    + "\\" +   fileNameRegulation(lastName) + ".txt";

                                if(fileExists(fileToBeCopy))
                                {
                                    Console.WriteLine("Dosya zaten mevcut!");
                                }
                                else
                                {
                                    fileCopy(fileToBeCopy, fileTarget);
                                    Console.WriteLine("Dosya Taşındı!");
                                }
                            }

                            break;
                        #endregion
                        
                        case '5':
                            Console.WriteLine("Silmek istediğiniz dosyanın adını yazın: ");
                            fileName = Console.ReadLine();
                            lastFourCharacter = fileName.Substring(fileName.Length - 4);
                            if( lastFourCharacter == ".txt")
                            {
                                string lastName = fileName.Replace(".txt", "");
                            }


                            break;


                        #region Geçersiz seçenek
                        default:
                            Console.WriteLine("Geçersiz seçenek!");
                            break;
                        #endregion
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen 1-5 arasında bir rakam giriniz!");
                }
                Console.WriteLine();

            } while (input != 0);
            #endregion


        }
        static void fileCreate(string path)
        {
            FileStream fileStream = File.Create(path);      // File.Create verilen path değerine dosyayı oluşturur.
            fileStream.Close();                             // Eğer dosyayı kapatmazsak üstünde değişiklik yapamayız!
        }

        static bool fileExists(string path)                 // Belirtilen path'de belirtilen dosyanın olup olmadığını kontrol eder!
        {
            return File.Exists(path);
        }
        
        static void fileDelete(string path)                 // Belirtilen path'deki dosyayı siler.
        {
            File.Delete(path);
        }
        static void fileMove(string path, string target)    // Belirtilen path'e belirtilen dosyayı taşır.
        {
            File.Move(path, target);
        }
        static void fileCopy(string path, string target)    // Belirtilen path'e dosyayı kopyalar!
        {
            File.Copy(path, target);
        }
        static string fileNameRegulation(string fileName)
        {
            string pattern = @"[!@#$%^&*()+{}\[\]:;<>,.?~\\|]"; // Regex pattern içerisinde sadece '_' yok !
            MatchCollection matches = Regex.Matches(fileName, pattern);

            return Regex.Replace(fileName, pattern, "");

        }
    }
}
