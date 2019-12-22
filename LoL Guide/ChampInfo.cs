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
        public string champName; //Form1'den gelen hangi şampiyona tıkladığımızı bize söyleyen değişken.
        public string api_key = "RGAPI-9d035eb3-2fbb-47e7-8cdc-06c145bd6f34";
        private void ChampInfo_Load(object sender, EventArgs e)
        {
            Api api = new Api((Form) this); //Api'mizden bir nesne oluşturuyoruz.
            /*
            api nesnesindeki resimleriYukle() fonksiyonuna formdaki çeşitli objeleri gönderip hangi şampiyonu seçtiysek
            ona göre tüm resimleri (rün, build, yetenek setleri, kostümlü/kostümsüz fotoğraflarını) koymamızı sağlıyoruz.
             */
            api.resimleriYukle(this.champName, label1, label2, label3, SampiyonFoto, SampiyonKostum, SkillSet, SampiyonRune, Build);
            label1.Text = champName; //Formun sol üstündeki label1'e Şampiyon ismini yazdırıyoruz.
        }
        public ChampInfo()
        {
            InitializeComponent();
        }
    }
}
