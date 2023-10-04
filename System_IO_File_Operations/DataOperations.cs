using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_IO_File_Operations
{
    public class DataOperations
    {
        public DataOperations()
        {
            
        }
        public List<Personel> GetPersonels(int count)
        {
            List<Personel> personels = new List<Personel>();
            int id = 0;

            for (int i = 0; i <= count; i++)
            {
                Personel personel = new Personel();
                personel.id = id++;
                personel.name = FakeData.NameData.GetFirstName();
                personel.surname = FakeData.NameData.GetSurname();
                personel.companyName = FakeData.NetworkData.GetDomain();
                personel.email = personel.name + "." +personel.surname + "@" + personel.companyName;
                personel.countryName = FakeData.PlaceData.GetCountry();
                personels.Add(personel);
            }
            return personels;
        }
        public void saveToPersonel(string path, List<Personel> personels)
        {
            DirectoryInfo infoCountry = null;
            for (int i = 0; i < personels.Count; i++)
            {
                if(!Directory.Exists(path + "\\" + personels[i].countryName)) 
                {
                    infoCountry = Directory.CreateDirectory(path + "\\" + personels[i].countryName);
                }
                else
                {
                    infoCountry = new DirectoryInfo(path + "\\" + personels[i].countryName);
                }
                FileStream fs = File.Create(infoCountry.FullName +"\\"+ personels[i].name + "." + personels[i].surname + ".txt");
                byte[] infoPersonel = new UTF8Encoding(true).GetBytes(personels[i].getPersonelInfo()); // Dosyaya yazarken bu şekilde byte[] dizisi değşikenine atıp
                fs.Write(infoPersonel, 0, infoPersonel.Length); // Bu şekilde yazıyoruz.
                fs.Close(); // Ve son olarak da dosyayı kapatıyoruz.                     
            }
        }
    }
}
