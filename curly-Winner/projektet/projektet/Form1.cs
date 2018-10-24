using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace projektet
{
    public partial class Form1 : Form
    {
        private HttpClient Client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {


            CreateFileOfPobcastes();


        }
        








        //denna metoden finns för att uppdatera comboboxen med värden som passar in i kategori combobox////
        private void Form1_Load(object sender, EventArgs e)
        {
            CBKatigorier();


            ListViewItem lvi = new ListViewItem();
        }

        public void CBKatigorier()
        {
            foreach (Kategori kato in (Kategori[])Enum.GetValues(typeof(Kategori)))
            {
                CBK.Items.Add(kato);
                comboBox3.Items.Add(kato);
            }
        }

        public void CreateFileOfPobcastes()
        {
            string[] lista = new string[] { };
            try
            {
                string path = @"C:\Users\donbh\Documents\GitHub\C-projektet33\curly-Winner\projektet\projektet\NewFolder1";
                var Dir = Directory.CreateDirectory(path);
                if (File.Exists(path))
                {
                    lista = File.ReadAllLines(path);
                    var nyLänk = tbUrl.Text;
                    foreach (var länk in lista)
                    {
                        if (!länk.ToString().Equals(nyLänk))
                        {
                            lista[0] = nyLänk;
                            File.WriteAllLines(path, lista);

                        }
                        else
                        {
                            MessageBox.Show(" denna URL-länk existerar redan", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

            }


            catch (Exception ex)
            {

            }

        }
    }
}

