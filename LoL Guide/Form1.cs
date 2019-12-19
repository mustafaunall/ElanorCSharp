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

namespace LoL_Guide
{
    public partial class Form1 : Form
    {
        public static string url;
        public string api_key = "RGAPI-9b7828f4-0b46-4b12-b01e-d1e5211338de";
        public string lol_nick = "Muti Sama";

        private string sihirdarLevel(string _nick)
        {
            url = @"https://tr1.api.riotgames.com/tft/summoner/v1/summoners/by-name/" + _nick + "?api_key=" + api_key;
            var bilgi = new WebClient().DownloadString(url); //riot api kullanarak bilgileri indirdim, url değişkenine atadım.
            var jss = new JavaScriptSerializer(); //bilgileri json'a dönüştürdüm
            var degerler = jss.Deserialize<dynamic>(bilgi);
            return Convert.ToString(degerler["summonerLevel"]);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{sihirdarLevel(textBox1.Text)} osuruklu balon :)");
        }
    }
}
