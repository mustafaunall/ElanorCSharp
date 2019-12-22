using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace LoL_Guide
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            Api api = new Api((Form)this); //Api'mizden bir nesne oluşturuyoruz.
            api.sampiyonlariEkle(panel1); //api nesnemizdeki sampiyonlariEkle() fonksiyonunu kullanarak panel1'imize tüm resimleri ekliyoruz.
            api.ApiKey = "RGAPI-9d035eb3-2fbb-47e7-8cdc-06c145bd6f34"; //api nesnemizdeki ApiKey string'imize atama yapıyoruz.
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}
