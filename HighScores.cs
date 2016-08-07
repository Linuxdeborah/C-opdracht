using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Collections;

namespace RuneScapeAPI
{
    public partial class HighScores : Form
    {
        //Definitie van de gebruikte gegevens in het gehele document.
        public string Playernaam = "";

        //Definitie van de string die de labels verder knalt
        String[] skillNames = { "Overall", "Att", "Def", "Str", "Con", "Range", "Pray", "Mage", "Cook", "Wood", "Fletch",
            "Fish", "Fire", "Craft", "Smith", "Mine", "Herb", "Agil", "Thief", "Slay", "Farm", "Rune", "Hunt", "Constr",
            "Sum", "Dungeon", "Divin", "Invent"};


        public HighScores()
        {
            // Initialiser, en roep het splashscreen op voor de interface word aangemaakt.
            SplashScreen splash = new SplashScreen();
            splash.Show();

            // Maak een loop van 5 seconden
            DateTime Tthen = DateTime.Now;
            do
            {
                Application.DoEvents();
            } while (Tthen.AddSeconds(5) > DateTime.Now);

            // Sluit SplashScreen na 5 seconden
            splash.Close();

            // Initialiseer Form1 onderdelen
            InitializeComponent();
        }

        /// <summary>
        /// Het systeem zal het kruisje uitschakelen door te disabelen
        /// </summary>
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void HighScores_Load(object sender, EventArgs e)
        {
            //Is overbodig geworden

        }

        private void HighScores_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit applicatie als form gesloten is
            Application.Exit();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sluit de applicatie!
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Initialiseer een AboutBox en toon deze, de assambly informatie word getoond.
            About aboutbox = new About();
            aboutbox.Show();
        }

        //Ophalen van de gegevens op tabblad 1
        private async void GetStats_Click(object sender, EventArgs e)
        {
            try
            {
                //Dit is de URL API                         +                        Specificatie van de textbox waar de playernaam uit komt
                string weburl = "http://services.runescape.com/m=hiscore/index_lite.ws?player=" + Player.Text;

                var data = await new WebClient().DownloadStringTaskAsync(new Uri(weburl));
                // async aanvraag zodat de GUI geen hinder heeft van het proces.
                

                //Split het eerste deel van de data filter op enter
                string[] skilldata = data.Split('\n');
                int skillnameCount = 0;

                     foreach (string skill in skilldata)
                     {
                    //Nog een keertje splitten, nu op de komma's
                    string[] skilldata2 = skill.Split(',');


                    //Het programma zet de string, zoals hij deze ziet, nu om zodat het in de labels gezet kan worden
                    //Dit is label 1 --> de Rank
                    Label lbl_text = this.Controls.Find(skillNames[skillnameCount] + "Rank", true).FirstOrDefault() as Label;
                    lbl_text.Text = skilldata2[0];

                    //Dit is label 2 --> het Level
                    Label lbl_text2 = this.Controls.Find(skillNames[skillnameCount] + "Lvl", true).FirstOrDefault() as Label;
                    lbl_text2.Text = skilldata2[1];

                    //Dit is label 3 --> de XP
                    Label lbl_text3 = this.Controls.Find(skillNames[skillnameCount] + "XP", true).FirstOrDefault() as Label;
                    lbl_text3.Text = skilldata2[2];
  
                    skillnameCount++;

                    if(skillnameCount == 28)
                    {

                        //Zodra je 28 skills gehad hebt, stoppen en door naar de volgende set labels
                        break;
                    }
                }
                
                }
            catch
            {
                // Er is een error opgetreden en de gebruiker word op de hoogte gehouden
                MessageBox.Show("Aanvraag naar API is mislukt\nControleer uw internetverbinding en kijk of RuneScape HighScores geen onderhoud heeft.");
            }
        }


        //Op tabblad 2 de knop voor Speler 1:
        private async void GetStats1_Click(object sender, EventArgs e)
        {
            //We herhalen het nog een keer
            try
            {
                //Dit is de URL API                         +                        Specificatie van de textbox waar de playernaam uit komt
                string weburl = "http://services.runescape.com/m=hiscore/index_lite.ws?player=" + Player1.Text;

                var data = await new WebClient().DownloadStringTaskAsync(new Uri(weburl));
                // async aanvraag zodat de GUI geen hinder heeft van het proces.

                string[] skilldata = data.Split('\n');
                int skillnameCount = 0;

                foreach (string skill in skilldata)
                {
                    string[] skilldata2 = skill.Split(',');
                    //OverallRank.Text = skilldata2[0];

                    Label lbl_text = this.Controls.Find(skillNames[skillnameCount] + "Rank1", true).FirstOrDefault() as Label;
                    lbl_text.Text = skilldata2[0];

                    Label lbl_text2 = this.Controls.Find(skillNames[skillnameCount] + "Lvl1", true).FirstOrDefault() as Label;
                    lbl_text2.Text = skilldata2[1];

                    Label lbl_text3 = this.Controls.Find(skillNames[skillnameCount] + "XP1", true).FirstOrDefault() as Label;
                    lbl_text3.Text = skilldata2[2];



                    skillnameCount++;

                    if (skillnameCount == 28)
                    {
                        break;
                    }
                }

            }
            catch
            {
                // Er is een error opgetreden en de gebruiker word op de hoogte gehouden
                MessageBox.Show("Aanvraag naar API is mislukt\nControleer uw internetverbinding en kijk of RuneScape HighScores geen onderhoud heeft.");
            }
        }

        //Op tabblad 2 gegevens speler 2:
        private async void GetStats2_Click(object sender, EventArgs e)
        {
            try
            {
                //Voor de 2e speler nu ook weer herhalen
                string weburl = "http://services.runescape.com/m=hiscore/index_lite.ws?player=" + Player2.Text;

                var data = await new WebClient().DownloadStringTaskAsync(new Uri(weburl));
                // async aanvraag zodat de GUI geen hinder heeft van het proces.

                string[] skilldata = data.Split('\n');
                int skillnameCount = 0;

                foreach (string skill in skilldata)
                {
                    string[] skilldata2 = skill.Split(',');

                    Label lbl_text = this.Controls.Find(skillNames[skillnameCount] + "Rank2", true).FirstOrDefault() as Label;
                    lbl_text.Text = skilldata2[0];

                    Label lbl_text2 = this.Controls.Find(skillNames[skillnameCount] + "Lvl2", true).FirstOrDefault() as Label;
                    lbl_text2.Text = skilldata2[1];

                    Label lbl_text3 = this.Controls.Find(skillNames[skillnameCount] + "XP2", true).FirstOrDefault() as Label;
                    lbl_text3.Text = skilldata2[2];

                    skillnameCount++;

                    if (skillnameCount == 28)
                    {
                        break;
                    }
                }

            }
            catch
            {
                // Er is een error opgetreden en de gebruiker word op de hoogte gehouden
                MessageBox.Show("Aanvraag naar API is mislukt\nControleer uw internetverbinding en kijk of RuneScape HighScores geen onderhoud heeft.");
            }
        }

        private void Compare_Click(object sender, EventArgs e)
        {
            //Nu moet de skill per speler berekend gaan worden. XP is altijd hoger
            for (int i = 0; i < 28; i++) {
                Label xp1 = this.Controls.Find(skillNames[i] + "XP1", true).FirstOrDefault() as Label;
                Label xp2 = this.Controls.Find(skillNames[i] + "XP2", true).FirstOrDefault() as Label;

                Label Rank1 = this.Controls.Find(skillNames[i] + "Rank1", true).FirstOrDefault() as Label;
                Label Rank2 = this.Controls.Find(skillNames[i] + "Rank2", true).FirstOrDefault() as Label;

                Label Lvl1 = this.Controls.Find(skillNames[i] + "Lvl1", true).FirstOrDefault() as Label;
                Label Lvl2 = this.Controls.Find(skillNames[i] + "Lvl2", true).FirstOrDefault() as Label;


                if (Int64.Parse(xp1.Text) > Int64.Parse(xp2.Text))
                {
                    //Nu moet de skill per speler groen gemaakt worden
                    xp1.BackColor = Color.Green;
                    Rank1.BackColor = Color.Green;
                    Lvl1.BackColor = Color.Green;

                    //de andere moet zwart blijven, of bij nieuwe vergelijking zwart gemaakt worden
                    xp2.BackColor = Color.Black;
                    Rank2.BackColor = Color.Black;
                    Lvl2.BackColor = Color.Black;
                }

                else
                {
                    //Nu moet de skill per speler groen gemaakt worden
                    xp2.BackColor = Color.Green;
                    Rank2.BackColor = Color.Green;
                    Lvl2.BackColor = Color.Green;

                    //de andere moet zwart blijven, of bij nieuwe vergelijking zwart gemaakt worden
                    xp1.BackColor = Color.Black;
                    Rank1.BackColor = Color.Black;
                    Lvl1.BackColor = Color.Black;
                }
            }

        }
    }
}
