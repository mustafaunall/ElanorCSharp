using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace LoL_Guide
{
    class Api
    {
        private string apiKey; //Apikey'imizi burada tutuyoruz.
        private string url; //Url'mizi burada tutuyoruz.
        int locationX, locationY; //Bu değişkenler Form1' de eklenecek şampiyon kare resimlerinin pozisyonunu belirlemek için x ve y pozisyonlarına eklenecek.
        WebClient wc = new WebClient(); //Api ve çeşitli resimleri WEB'den indirmek için kullanacağız.
        PictureBox champBox = new PictureBox(); //Form1'de eklenecek her bir karakter kare resmini atayacağımız PictureBox değişkeni.
        Bitmap bitmap; //WebClient kullanarak indirdiğimiz resimler tabii ki de byte dizisi olarak ineceği için PictureBox'a eklemek için dönüştürüyoruz.
        MemoryStream stream; //WebClient'ten indirdiğimiz byte dizisi cinsinden veriyi Bellekte tutarak dönüştürmeye olanak sağlar.
        byte[] data; //WebClient kullanarak indirdiğimiz verileri burada tutacağız.
        List<string> sampiyonlar = new List<string>(); //sampiyonlariEkle() Fonksiyonunu kullanarak ekleyeceğimiz şampiyonların listesi.
        Form Form; //Hangi Form'da olduğumuzu anlamak için veya formda this.BackColor gibi özellikleri değiştirmek için gerek duyuyoruz ve yapıcı metodumuzda alıyoruz.
        public Api(Form form)
        {
            this.Form = form; //Hangi formda olduğumuzu ve formdaki özellikleri alıyoruz.
            this.locationX = 0; this.locationY = 0; //Location x ve y değerlerimizi resetliyoruz. (sıfıra eşitleyerek imlecimizi başa alıyoruz)
            this.sampiyonDizisi(); //sampiyonlar listesine istenilen sampiyonlar ekleniyor.
            Form.BackColor = Color.FromArgb(28, 33, 35); //Form özelliklerini çektiğimiz için BackColor'u rahatlıkla değiştirebiliyoruz.
        }
        public string ApiKey //ApiKey'imiz eğer olur da null veya "" (boş string) olarak gelirse get ve set metodlarıyla bunu engelliyoruz.
        {
            get { return this.apiKey; }
            set
            {
                if (value != "") this.apiKey = value;
                else this.apiKey = null;
            }
        }
        public string Url //ApiKey'imiz eğer olur da null veya "" (boş string) olarak gelirse get ve set metodlarıyla bunu engelliyoruz.
        {
            get { return this.url; }
            set
            {
                if (value != "") this.url = value;
                else this.url = null;
            }
        }
        public void resimleriYukle(string champName, Label label1, Label label2, Label label3, PictureBox SampiyonFoto, PictureBox SampiyonKostum, PictureBox SkillSet, PictureBox SampiyonRune, PictureBox Build)
        {
            //url=Riot Api kullanarak istediğimiz şampiyonun bilgilerine erişiyoruzç
            url = $"http://ddragon.leagueoflegends.com/cdn/9.24.2/data/tr_TR/champion/{champName}.json";
            //WebClient'imizin Kodlama Tipini türkçe karakter hatalarını önlemek için UTF8 yapıyoruz.
            wc.Encoding = Encoding.UTF8;
            var bilgi = wc.DownloadString(url); //riot api kullanarak bilgileri indirdim, url değişkenine atadım.
            var jss = new JavaScriptSerializer(); //bilgileri json'a dönüştürdüm
            var degerler = jss.Deserialize<dynamic>(bilgi); //indirdiğimiz verileri dizi halinde tuttuk.
            label2.Text = $"Klasik {champName}"; //label2 ye şampiyon ismi yazdırdık.
            label3.Text = degerler["data"][champName]["skins"][1]["name"]; //label3 ye ilk kostümünün ismiyle beraber şampiyon ismi yazdırdık.
            data = wc.DownloadData($"http://ddragon.leagueoflegends.com/cdn/img/champion/loading/{champName}_0.jpg"); //şampiyonun kostümsüz fotoğrafını indiriyoruz.
            stream = new MemoryStream(data); //Bitmap'e dönüştürmek üzere hafızada tutuyoruz.
            bitmap = new Bitmap(stream); //Fotoğrafı atamak için bitmap değişken türünde tutuyoruz.
            SampiyonFoto.Image = Image.FromStream(stream); //SampiyonFoto'nun fotoğrafına indirilen fotoğrafı koyuyoruz.
            data = wc.DownloadData($"http://ddragon.leagueoflegends.com/cdn/img/champion/loading/{champName}_1.jpg");
            stream = new MemoryStream(data); //Bitmap'e dönüştürmek üzere hafızada tutuyoruz.
            bitmap = new Bitmap(stream); //Fotoğrafı atamak için bitmap değişken türünde tutuyoruz.
            SampiyonKostum.Image = Image.FromStream(stream); //SampiyonKostum'ün fotoğrafına indirilen fotoğrafı koyuyoruz.
            if (!File.Exists($"resimler/{champName}_Rune.png") || !File.Exists($"resimler/{champName}_SkillSet.png") || !File.Exists($"resimler/{champName}_Build.png"))
            {
                //Eğer Form1'den tıklanılan şampiyona ait kaynak resimlerden herhangi biri bulunamazsa Hata Verip return ile fonksiyonu durduruyoruz.
                MessageBox.Show("Kaynak resimler bulunamadı.", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SampiyonRune.Image = Image.FromFile($"resimler/{champName}_Rune.png"); //Şampiyonun rün resmini atıyoruz.
            SkillSet.Image = Image.FromFile($"resimler/{champName}_SkillSet.png"); //Şampiyonun yetenek setinin resmini atıyoruz.
            Build.Image = Image.FromFile($"resimler/{champName}_Build.png"); //Şampiyonun build resmini atıyoruz.
        }
        private void sampiyonDizisi()
        {
            //sampiyonlar listesine istenilen şampiyonları ekliyoruz.
            sampiyonlar.Add("Akali");
            sampiyonlar.Add("Aatrox");
            sampiyonlar.Add("Gangplank");
            sampiyonlar.Add("Riven");
            sampiyonlar.Add("Renekton");
            sampiyonlar.Add("#bosluk#");
            sampiyonlar.Add("LeeSin");
            sampiyonlar.Add("JarvanIV");
            sampiyonlar.Add("Sejuani");
            sampiyonlar.Add("Nocturne");
            sampiyonlar.Add("Gragas");
            sampiyonlar.Add("#bosluk#");
            sampiyonlar.Add("Leblanc");
            sampiyonlar.Add("Irelia");
            sampiyonlar.Add("Vladimir");
            sampiyonlar.Add("Ahri");
            sampiyonlar.Add("Fizz");
            sampiyonlar.Add("#bosluk#");
            sampiyonlar.Add("Vayne");
            sampiyonlar.Add("Kaisa");
            sampiyonlar.Add("Caitlyn");
            sampiyonlar.Add("Ezreal");
            sampiyonlar.Add("Lucian");
            sampiyonlar.Add("#bosluk#");
            sampiyonlar.Add("Nautilus");
            sampiyonlar.Add("Blitzcrank");
            sampiyonlar.Add("Thresh");
            sampiyonlar.Add("Braum");
            sampiyonlar.Add("Pyke");
        }
        public void sampiyonlariEkle(Panel panel)
        {
            foreach(var sampiyon in sampiyonlar)
            {
                if(sampiyon == "#bosluk#") //değer eğer #bosluk# ise onu bir alt satıra geçmek için kullanıyoruz.
                {
                    locationX = 0;
                    locationY += 100;
                }
                else //değilse sampiyonFotoEkle() fonksiyonunu kullanarak resmini ekliyoruz.
                {
                    sampiyonFotoEkle(sampiyon, panel);
                }
            }
        }
        private void sampiyonFotoEkle(string _sampiyon, Panel panel)
        {
            champBox = new PictureBox(); //champBox'a yeni bir nesne atayarak sıfırlıyoruz.
            champBox.Name = _sampiyon; //champBox'un ismini ChampInfo Form'un da kullanmak üzere saklıyoruz.
            champBox.Size = new Size(80, 80); //champBox'un boyutunu 80 e 80 olarak değiştiriyoruz.
            champBox.Location = new Point(0 + locationX, 0 + locationY); //champBox'ın yerini belirliyoruz.
            data = wc.DownloadData($"http://ddragon.leagueoflegends.com/cdn/9.24.2/img/champion/{_sampiyon}.png"); //Fotoğrafı indiriyoruz.
            stream = new MemoryStream(data); //İndirdiğimiz fotoğrafı bellekte saklıyoruz.
            bitmap = new Bitmap(stream); //Bellekte sakladığımız veriyi PictureBox'a koymak için Bitmap türünden tutuyoruz.
            champBox.Image = Image.FromStream(stream); //champBox'ın içine indirdiğimiz fotoğrafı atıyoruz.
            champBox.SizeMode = PictureBoxSizeMode.StretchImage; //StrechImage kullanarak fotoğrafı pictureBox'a sığdırıyoruz.
            locationX += 105; //Sonraki champBox için yana 105 piksel kaydırıyoruz.
            champBox.Click += sampiyonClick; // Tıklanan pictureBox dizisindeki o elemanın Click olayında sampiyonClick function çalışsın.
            panel.Controls.Add(champBox); //ekranda kötü gözükmemesi için fotoğrafı panele ekliyoruz.
        }
        private void sampiyonClick(object sender, EventArgs e)
        {
            //PictureBox gelenResim = sender as PictureBox; //capsulation yolu ile gelen nesneyi picturebox nesne tipine dönüştürdüm.
            PictureBox gelenResim = (PictureBox)sender; //capsulation yolu ile gelen nesneyi picturebox nesne tipine dönüştürdüm.
            ChampInfo champForm = new ChampInfo(); //ChampInfo nesnesi oluşturuyoruz.
            champForm.champName = gelenResim.Name; //Oluşturduğumuz ChampInfo nesnesinin içindeki şampiyon ismini burada kullanmak üzere alıyoruz.
            champForm.Show(); //ChampInfo nesnesini gösteriyoruz.
        }
    }
}
