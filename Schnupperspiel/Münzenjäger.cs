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
        public static int xPlayer = 750;
        public static int yPlayer = 450;

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

            createPlayer();

            //Spielersteuerung

            KeyDown += new KeyEventHandler(movePlayer);
            KeyPreview = true;

            //Interval Gegnertimer

            game.setTimerEnemyInterval(10);

            //Wand

        }     

        //Spieltimer
        private void tmrGame_Tick(object sender, EventArgs e){
            if (game.getTime() <= 0)
            {
                game.timeIsUp();
                game.stopGame();
                showHighscore();
            }
            if(game.getNumberOfEnemyList() == 0)
            {
                createEnemy();
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
            game.LookForCoin(10);
            game.setScore(game.getPoints());
            game.LookForEnemy();
        }

        private void tmrEnemy_Tick(object sender, EventArgs e){
            moveEnemy();

        }
        private void tmrSpeed_Tick(object sender, EventArgs e){             
        }
        private void createCoin(){
            while (game.checkCoinPosition(xCoin, yCoin))
            {
                game.setCoinPosition(xCoin, yCoin);
                game.setCoinSize(20, 20);
                game.addCoinToList();
            }
        }

        private void createPlayer()
        {
            game.setPlayerSpeed(4);
            game.setPlayerSize(50, 50);
            game.setPlayerPosition(xPlayer, yPlayer);
        }

        private void movePlayer(object sender, KeyEventArgs key)
        {
            if(key.KeyCode == Keys.D && game.checkPanelRight())
            {
                game.movePlayerRight();
            }
            if(key.KeyCode == Keys.A && game.checkPanelLeft())
            {
                game.movePlayerLeft();
            }
            if(key.KeyCode==Keys.S && game.checkPanelBottom())
            {
                game.movePlayerDown();
            }
            if(key.KeyCode==Keys.W && game.checkPanelTop())
            {
                game.movePlayerUp();
            }

            game.setPlayerPosition(game.getPlayerPositionX(), game.getPlayerPositionY());
        }

        private void showHighscore()
        {
            if(game.getPoints() > game.getHighscore())
            {
                game.setHighscore(game.getPoints());
            }
        }

        private void createEnemy()
        {
            game.setEnemyPosition(5, 5);
            game.setEnemySize(50, 50);
            game.setEnemySpeed(1);
            game.addEnemyToList();
        }

        private void moveEnemy()
        {
            if(game.getEnemyTop() < game.getPlayerTop())
            {
                game.moveEnemyUp();
            }
            if(game.getEnemyTop() > game.getPlayerTop())
            {
                game.moveEnemyDown();
            }
            if(game.getEnemyLeft() < game.getPlayerLeft())
            {
                game.moveEnemyRight();
            }
            if(game.getEnemyLeft() > game.getPlayerLeft())
            {
                game.moveEnemyLeft();
            }
        }

    }
}
