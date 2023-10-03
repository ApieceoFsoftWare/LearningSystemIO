using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystemIO_FileIslemleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Udemy\\merhaba.txt";

            // fileCreate("C:\\Udemy\\merhaba.txt");
            bool control = fileExists((string)path);
            if (control)
            {
                Console.WriteLine("Bu dosya bu yol üzerinde var");
            }
            else
            {
                fileCreate(path);
                Console.WriteLine("Dosya oluşturuldu!");
            }
            #region Dosyayı bul ve sil!
            if (fileExists(path))
            {
                Console.WriteLine("Dosya mevcut. Dosyayı silmek ister misiniz?");
                while (true)
                {

                    string answer = Console.ReadLine().ToUpper();
                    if (answer.Length == 1 && char.IsLetter(answer[0]))
                    {
                        if (answer[0] == 'Y')
                        {
                            Console.WriteLine("Dosya siliniyor!");
                            fileDelete(path);
                            System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("Silindi!");
                            break;
                        }
                        else if (answer[0] == 'N')
                        {
                            Console.WriteLine("Dosya silinmedi");
                            break;
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
            }
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
    }
}
