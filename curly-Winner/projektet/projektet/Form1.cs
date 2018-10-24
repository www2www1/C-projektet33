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

        String[,] rssData = null;

        private void button1_Click(object sender, EventArgs e)
        {


            listBox1.Items.Clear();
            rssData = getRssData(tbUrl.Text);
            for (int i = 0; i < rssData.GetLength(0); i++) {

                if (rssData[i, 0] != null) {
                    listBox1.Items.Add(rssData[i, 0]);


                }

                listBox1.SelectedIndex = 0;
            }


            //string[] lista = new string[] { };


            // string path = @"D:\text.txt";
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
            //    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //    {
            //        using (StreamWriter sr = new StreamWriter(fs))
            //        {

            //            var nyLänk = tbUrl.Text;
            //            Array.Resize(ref lista, lista.Length + 1);

            //            for (int i = 0; i < lista.Length; i++)
            //            {
            //                lista[lista.Length-1] = nyLänk;
            //            }




            //            Close();

            //        }
            //    }
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {



            if (rssData[listBox1.SelectedIndex, 1] != null)

                DescriptionTextBox.Text = rssData[listBox1.SelectedIndex, 1];
            if (rssData[listBox1.SelectedIndex, 2] != null)
                linkLabel.Text = "Follow the link: " + rssData[listBox1.SelectedIndex, 0];


        }

        private String[,] getRssData(String channel) {
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
            System.Net.WebResponse myResponse = myRequest.GetResponse();

            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();

            rssDoc.Load(rssStream);
            System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

            String[,] tempRssData = new String[100, 3];

            for (int i = 0; i < rssItems.Count; i++) {

                System.Xml.XmlNode rssNode;
                rssNode = rssItems.Item(i).SelectSingleNode("title");

                if (rssNode != null) {
                    tempRssData[i, 0] = rssNode.InnerText;

                } else {
                    tempRssData[i, 0] = "";

                }

                rssNode = rssItems.Item(i).SelectSingleNode("description");
                if (rssNode != null) {
                    tempRssData[i, 1] = rssNode.InnerText;
                } else {
                    tempRssData[i, 1] = "";
                }

                rssNode = rssItems.Item(i).SelectSingleNode("link");
                if (rssNode != null) {
                    tempRssData[i, 2] = rssNode.InnerText;

                } else {
                    tempRssData[i, 2] = "";
                }


            }
            return tempRssData;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void tbUrl_TextChanged(object sender, EventArgs e) {

        }
    }
    }


