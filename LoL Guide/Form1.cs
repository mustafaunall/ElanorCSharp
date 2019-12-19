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
        public static string url;
        public string api_key = "RGAPI-9b7828f4-0b46-4b12-b01e-d1e5211338de";
        public string lol_nick = "Muti Sama";
        PictureBox[] boxes = new PictureBox[100];
        int siradaki = 0, locationX = 0, locationY = 0;
        private string sihirdarLevel(string _nick)
        {
            url = @"https://tr1.api.riotgames.com/tft/summoner/v1/summoners/by-name/" + _nick + "?api_key=" + api_key;
            var bilgi = new WebClient().DownloadString(url); //riot api kullanarak bilgileri indirdim, url değişkenine atadım.
            var jss = new JavaScriptSerializer(); //bilgileri json'a dönüştürdüm
            var degerler = jss.Deserialize<dynamic>(bilgi);
            return Convert.ToString(degerler["summonerLevel"]);
        }
        private string sampiyonlar(string _hero)
        {
            url = $"http://ddragon.leagueoflegends.com/cdn/9.24.2/img/champion/{_hero}.png";
            var bilgi = new WebClient().DownloadString(url); //riot api kullanarak bilgileri indirdim, url değişkenine atadım.
            var jss = new JavaScriptSerializer(); //bilgileri json'a dönüştürdüm
            var degerler = jss.Deserialize<dynamic>(bilgi);
            return Convert.ToString(degerler["summonerLevel"]);
        }
        private void sampiyonFotoEkle(string _sampiyon)
        {
            boxes[siradaki] = new PictureBox();
            boxes[siradaki].Size = new Size(80, 80);
            boxes[siradaki].Location = new Point(0 + locationX, 0 + locationY);
            WebClient wc = new WebClient();
            byte[] originalData = wc.DownloadData($"http://ddragon.leagueoflegends.com/cdn/9.24.2/img/champion/{_sampiyon}.png");
            MemoryStream stream = new MemoryStream(originalData);
            Bitmap Bitmap = new Bitmap(stream);
            boxes[siradaki].Image = Image.FromStream(stream);
            boxes[siradaki].SizeMode = PictureBoxSizeMode.StretchImage;
            locationX += 105;
            panel1.Controls.AddRange(boxes);
        }
        private void altaGec()
        {
            locationX = 0;
            locationY += 100;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sampiyonFotoEkle("Akali");
            sampiyonFotoEkle("Aatrox");
            sampiyonFotoEkle("Gangplank");
            sampiyonFotoEkle("Riven");
            sampiyonFotoEkle("Renekton");
            altaGec();
            sampiyonFotoEkle("LeeSin");
            sampiyonFotoEkle("JarvanIV");
            sampiyonFotoEkle("Sejuani");
            sampiyonFotoEkle("Nocturne");
            sampiyonFotoEkle("Gragas");
            altaGec();
            sampiyonFotoEkle("Leblanc");
            sampiyonFotoEkle("Irelia");
            sampiyonFotoEkle("Vladimir");
            sampiyonFotoEkle("Ahri");
            sampiyonFotoEkle("Fizz");
            altaGec();
            sampiyonFotoEkle("Vayne");
            sampiyonFotoEkle("Kaisa");
            sampiyonFotoEkle("Caitlyn");
            sampiyonFotoEkle("Ezreal");
            sampiyonFotoEkle("Lucian");
            altaGec();
            sampiyonFotoEkle("Nautilus");
            sampiyonFotoEkle("Blitzcrank");
            sampiyonFotoEkle("Thresh");
            sampiyonFotoEkle("Braum");
            sampiyonFotoEkle("Pyke");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{sihirdarLevel(textBox1.Text)} levelsin :)");
        }
    }
}
