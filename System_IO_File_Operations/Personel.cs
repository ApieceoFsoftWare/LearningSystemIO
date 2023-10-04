using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_IO_File_Operations
{
    public class Personel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string companyName { get; set; }
        public string countryName { get; set; }


        public override string ToString()
        {
            return name + " " + surname;
        }
        public string getPersonelInfo()
        {
            return string.Format("Name: {0} \nSurname: {1} \nEmail: {2} \nCompany Name: {3} \nCountry Name: {4}\n", name, surname, email, companyName, countryName);
        }
    }
}
