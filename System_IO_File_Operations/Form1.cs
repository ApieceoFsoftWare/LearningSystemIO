using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_IO_File_Operations
{
    public partial class Form1 : Form
    {
        DataOperations dataOperations;  // Bu şekilde yapılınca class seviyesine çekmiş oluyoruz
        List<Personel> personelList;    // GarbageCollector ile değerler kaybolmamış oluyor
        public Form1()
        {
            InitializeComponent();
            dataOperations = new DataOperations();
        }

        private void btnPersonelGetir_Click(object sender, EventArgs e)
        {
            personelList = dataOperations.GetPersonels(150);
            lstPersonel.DataSource = personelList;

        }
        private void lstPersonel_DoubleClick(object sender, EventArgs e)
        {
            Personel secilenPersonel = lstPersonel.SelectedItem as Personel;
            txtName.Text    = secilenPersonel.name;
            txtSurname.Text = secilenPersonel.surname;
            txtEmail.Text   = secilenPersonel.email;
            txtCompany.Text = secilenPersonel.companyName;
            txtCountry.Text = secilenPersonel.countryName;
        }

        private void btnPersonelKaydet_Click(object sender, EventArgs e)
        {
            dataOperations.saveToPersonel("C:\\Learning\\", personelList);  
        }
    }
}
