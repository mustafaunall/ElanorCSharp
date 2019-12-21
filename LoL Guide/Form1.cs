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
        public string api_key = "RGAPI-9d035eb3-2fbb-47e7-8cdc-06c145bd6f34";
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
            boxes[siradaki].Name = _sampiyon;
            boxes[siradaki].Size = new Size(80, 80);
            boxes[siradaki].Location = new Point(0 + locationX, 0 + locationY);
            WebClient wc = new WebClient();
            byte[] originalData = wc.DownloadData($"http://ddragon.leagueoflegends.com/cdn/9.24.2/img/champion/{_sampiyon}.png");
            MemoryStream stream = new MemoryStream(originalData);
            Bitmap Bitmap = new Bitmap(stream);
            boxes[siradaki].Image = Image.FromStream(stream);
            boxes[siradaki].SizeMode = PictureBoxSizeMode.StretchImage;
            locationX += 105;
            boxes[siradaki].Click += sampiyonClick; // Tıklanan pictureBox dizisindeki o elemanın Click olayında sampiyonClick function çalışsın.
            panel1.Controls.AddRange(boxes);
        }
        private void sampiyonClick(object sender, EventArgs e)
        {
            PictureBox gelenResim = sender as PictureBox; //capsulation yolu ile gelen nesneyi picturebox nesne tipine dönüştürdüm.
            ChampInfo champForm = new ChampInfo();
            champForm.champName = gelenResim.Name;
            champForm.Show();
        }
        private void altaGec()
        {
            locationX = 0;
            locationY += 100;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{sihirdarLevel(textBox1.Text)} levelsin :)");
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
        public Form1()
        {
            InitializeComponent();
        }
    }
}
