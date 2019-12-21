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
    public partial class ChampInfo : Form
    {
        public string champName;
        public static string url;
        public string api_key = "RGAPI-9d035eb3-2fbb-47e7-8cdc-06c145bd6f34";

        private void resimleriYukle()
        {
            WebClient wc = new WebClient();
            url = $"http://ddragon.leagueoflegends.com/cdn/9.24.2/data/tr_TR/champion/{champName}.json";
            wc.Encoding = Encoding.UTF8;
            var bilgi = wc.DownloadString(url); //riot api kullanarak bilgileri indirdim, url değişkenine atadım.
            var jss = new JavaScriptSerializer(); //bilgileri json'a dönüştürdüm
            var degerler = jss.Deserialize<dynamic>(bilgi);
            label2.Text = $"Klasik {champName}";
            label3.Text = degerler["data"][champName]["skins"][1]["name"];
            byte[] Data = wc.DownloadData($"http://ddragon.leagueoflegends.com/cdn/img/champion/loading/{champName}_0.jpg");
            MemoryStream stream = new MemoryStream(Data);
            Bitmap Bitmap = new Bitmap(stream);
            SampiyonFoto.Image = Image.FromStream(stream);
            Data = wc.DownloadData($"http://ddragon.leagueoflegends.com/cdn/img/champion/loading/{champName}_1.jpg");
            stream = new MemoryStream(Data);
            Bitmap = new Bitmap(stream);
            SampiyonKostum.Image = Image.FromStream(stream);
            if( !File.Exists($"resimler/{champName}_Rune.png") || !File.Exists($"resimler/{champName}_SkillSet.png") || !File.Exists($"resimler/{champName}_Build.png"))
            {
                MessageBox.Show("Kaynak resimler bulunamadı.", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SampiyonRune.Image = Image.FromFile($"resimler/{champName}_Rune.png");
            SkillSet.Image = Image.FromFile($"resimler/{champName}_SkillSet.png");
            Build.Image = Image.FromFile($"resimler/{champName}_Build.png");
        }
        private void ChampInfo_Load(object sender, EventArgs e)
        {
            resimleriYukle();
            label1.Text = champName;
            this.BackColor = Color.FromArgb(28, 33, 35);
        }
        public ChampInfo()
        {
            InitializeComponent();
        }
    }
}
