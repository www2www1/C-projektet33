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
            string[] lista = new string[] { };


            string path = @"D:\text.txt";
            //if (File.Exists(path))
            //{
            //    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //    {
            //        using (StreamReader sre = new StreamReader(fs))
            //        {
            //            foreach (var länk in lista)
            //            {
            //                sre.ReadLine() += länk;
                         
                        
            //            }
            //        }
            //    }
            //    Close();
            //}
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {

                    var nyLänk = tbUrl.Text;
                    Array.Resize(ref lista, lista.Length + 1);
                
                    for (int i = 0; i < lista.Length; i++)
                    {
                        lista[lista.Length-1] = nyLänk;
                    }




                    Close();

                }
            }
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


    }
}

