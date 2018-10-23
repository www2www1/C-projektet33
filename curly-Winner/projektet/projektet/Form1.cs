using System;
using System.Collections.Generic;
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
            var urlTest = tbUrl.Text;
            if (urlTest != "")
            {
                

                var enpodcast = new Podcast();
                enpodcast.Namn = "";
                enpodcast.updateringFrekvens = 12;
                enpodcast.AllaAvsnitt = new List<Avsnitt>();
                



               


            }
            else if (urlTest == null)
            {

            }

            else
            {
                MessageBox.Show("Skriv in din URL-länk", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {   CBKatigorier();
            ListViewItem lvi = new ListViewItem();
            //lvi.SubItems.Add(pet.Name);
            //lvi.SubItems.Add(pet.Type);
            //lvi.SubItems.Add(pet.Age);

            //listView.Items.Add(lvi);
         

        }



        //denna metoden finns för att uppdatera comboboxen med värden som passar in i kategori combobox////
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

