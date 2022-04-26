using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// !! ALS STARTDATEI "Schnupperspiel.csproj - Debug|AnyCPU" auswählen !!

namespace Schnupperspiel{

    public partial class frmGame : Form{

        //Auf die andere Klasse zugreifen
        public Game game = new Game();

        //Zufällig
        private Random random = new Random();

        //Variablen deklarieren für Position von Spieler
        public static int xPlayer;
        public static int yPlayer;

        //Variablen deklarieren für Position von Münzen
        private int xCoin;  
        private int yCoin;

        //Konstruktor: Kompontenten hinzufügen
        public frmGame() {
            InitializeComponent();
        }


        //Ganzes Spielfeld wird hier aufgebaut
        private void loadGame(object sender, EventArgs e){ 
            Timer tmrGame = game.tmrGame;

            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);
            Timer tmrEnemy = game.tmrEnemy;
            tmrEnemy.Tick += new System.EventHandler(this.tmrEnemy_Tick);
            Timer tmrSpeed = game.tmrSpeed;
            tmrSpeed.Tick += new System.EventHandler(this.tmrSpeed_Tick);
            game.makeGame(this);

            //Form und Panel
            game.setFormColour(75, 75, 75);

            game.setPanelSize(800, 500);
            game.setPanelColour(0, 0, 0);

            //Startknopf

            game.setButtonStartPosition(12, 550);
            game.setButtonStartSize(181, 62);
            game.setButtonStartColour(255, 255, 255);
            game.setButtonStartText("Start");

            //Stopknopf

            game.setButtonStopPosition(212, 550);
            game.setButtonStopSize(181, 62);
            game.setButtonStopColour(255, 255, 255);
            game.setButtonStopText("Stop");

            //Speedknopf


            //Zeitlabel

            game.setLabelTimePosition(820, 10);
            game.setLabelTimeSize(170, 55);
            game.setLabelTimeText("Time:");

            //Punktelabel

            game.setLabelScorePosition(820, 70);
            game.setLabelScoreSize(170, 55);
            game.setLabelScoreText("Points");

            //Höchstpunktezahllabel

            game.setLabelHighscorePosition(820, 130);
            game.setLabelHighscoreSize(300, 55);
            game.setLabelHighscoreText("Highscore");

            //Namelabel

            game.setLabelNamePosition(820, 480);
            game.setLabelNameSize(300, 55);
            game.setLabelNameText("Münzenjäger");

            //Zeittext

            game.setTextTimePosition(1050, 10);
            game.setTextTimeSize(94, 44);

            //Punktetext

            game.setTextScorePosition(1050, 70);
            game.setTextScoreSize(94, 44);

            //Höchstpunktezahltext

            game.setTextHighscorePosition(1050, 130);
            game.setTextScoreSize(94, 44);

            //Interval Spieltimer

            game.setTime(60);
            game.setTimerGameInterval(1000);

            //Interval Münzentimer

            game.setTimerCoinInterval(100);

            //Spieler


            //Spielersteuerung


            //Interval Gegnertimer


            //Wand

        }     

        //Spieltimer
        private void tmrGame_Tick(object sender, EventArgs e){
            if (game.getTime() <= 0)
            {
                game.timeIsUp();
                game.stopGame();
            }
        }

        //Münzentimer
        private void tmrCoin_Tick(object sender, EventArgs e){
            if (game.getNumberOfCoinList() < 10)
            {
                xCoin = random.Next(20, game.getPanelWidth() - 40);
                yCoin = random.Next(20, game.getPanelHeight() - 40);
                createCoin();
            }
        }

        private void tmrEnemy_Tick(object sender, EventArgs e){

        }
        private void tmrSpeed_Tick(object sender, EventArgs e){             
        }
        private void createCoin(){
            game.setCoinPosition(xCoin, yCoin);
            game.setCoinSize(20, 20);
            game.addCoinToList();
        }

    }
}
