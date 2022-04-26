using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schnupperspiel
{

    public partial class Game : Form
    {
        /*
         * Private Variablen und Komponente auf die man von der anderen Klasse NICHT zugreifen kann
         */
        private Form Münzenjägerform = new Form();
        private Panel pnlGame = new Panel();
        private Button btnStart = new Button();
        private Button btnStop = new Button();
        public Button btnSpeed = new Button();
        private List<PictureBox> coinList = new List<PictureBox>();
        private List<PictureBox> enemyList = new List<PictureBox>();
        private Label lblTime = new Label();
        private Label lblPoint = new Label();
        private Label lblHighscore = new Label();
        private Label lblName = new Label();
        private TextBox txtTime = new TextBox();
        private TextBox txtPoint = new TextBox();
        private TextBox txtHighscore = new TextBox();
        private PictureBox picPlayer = new PictureBox();
        private PictureBox picEnemy = new PictureBox();
        private PictureBox picEnemyBot = new PictureBox();
        private PictureBox picGameover = new PictureBox();
        private PictureBox picWall = new PictureBox();
        private PictureBox coin;
        private Boolean timeisup = false;
        private Boolean highscoreistrue = true;
        private int playerSpeed = 0;
        public static int enemySpeed = 1;     
        public static int enemyBotSpeed = 1; 
        private int xEnemy = 0;
        private int yEnemy = 0;
        private int xEnemyBot = 0;
        private int yEnemyBot = 0;
        private int xPlayer = 0;
        private int yPlayer = 0;  
        private int widthPlayer = 0;
        private int heightPlayer = 0;
        private int widthEnemy = 0;
        private int heightEnemy = 0;
        private int widthEnemyBot = 0;
        private int heightEnemyBot = 0;
        private int highscore = 0;
        private int points = 0;
        private int time = 0;
        private int resetTime = 0;
        private int switchTime = 0;
        private int addedSpeed = 0;
        private int timeSpeedDelay=0;
        private int timeSpeed = 0;

        /*
         * Öffentliche / Private Komponente auf die man von der anderen Klasse zugreifen kann
         */

        public Timer tmrCoin = new Timer();
        public Timer tmrGame = new Timer();
        public Timer tmrEnemy = new Timer();
        private Timer tmrSwitch = new Timer();
        public Timer tmrSpeed = new Timer();


        /*
         * Setters (ohne Rückgabewert / mit Paramenter)
         */

        //Form-Setter
        public void setFormColour(int r, int g, int b){
            Münzenjägerform.BackColor = Color.FromArgb(r,g,b);
        }

        //Panel-Setters
        public void setPanelColour(int r, int g, int b){
             pnlGame.BackColor = Color.FromArgb(r,g,b);
        }
        public void setPanelSize(int w, int h){
            pnlGame.Size = new System.Drawing.Size(w, h);
            pnlGame.Visible = true;      
        }

        //Startknopf-Setters
        public void setButtonStartSize(int w, int h){
           btnStart.Size = new System.Drawing.Size(w, h);
        }
        public void setButtonStartPosition(int x, int y){
           btnStart.Location = new System.Drawing.Point(x,y);
           btnStart.Visible = true;
        }
        public void setButtonStartColour(int r, int g, int b){
           btnStart.BackColor = Color.FromArgb(r,g,b);
        }
        public void setButtonStartText(String text){
           btnStart.Text = text;
        }

        //Stopknopf-Setters
        public void setButtonStopSize(int w, int h){
           btnStop.Size = new System.Drawing.Size(w, h);
        }
        public void setButtonStopPosition(int x, int y){
           btnStop.Location = new System.Drawing.Point(x,y);
           btnStop.Visible = true;
        }
        public void setButtonStopColour(int r, int g, int b){
           btnStop.BackColor = Color.FromArgb(r,g,b);
        }
        public void setButtonStopText(String text){
            btnStop.Text = text;
        }

        //Speedknopf-Setters
        public void setButtonSpeedSize(int w, int h){
            btnSpeed.Size = new System.Drawing.Size(w, h);
        }
        public void setButtonSpeedPosition(int x, int y){
            btnSpeed.Location = new System.Drawing.Point(x,y);
            btnSpeed.Visible = true;
        }
        public void setButtonSpeedColour(int r, int g, int b){
            btnSpeed.BackColor = Color.FromArgb(r,g,b);
        }
        public void setButtonSpeedText(String text){
            btnSpeed.Text = text;
        }
        public void setAddedPlayerSpeed(int speed){
            addedSpeed = speed;
        }
        public void setTimerSpeedInterval(int intervall){
            tmrSpeed.Interval = intervall;
        }
        public void setSpeedTime(int time){
            timeSpeed = time;
        }
        public void setSpeedDelay(int delay){
            timeSpeedDelay = delay;
        }

        //Zeitlabel-Setters
        public void setLabelTimePosition(int x, int y){
            lblTime.Location = new System.Drawing.Point(x,y);
            lblTime.Visible = true;
        }
        public void setLabelTimeSize(int w, int h){
            lblTime.Size = new System.Drawing.Size(w, h);
        }
        public void setLabelTimeText(String text){
            lblTime.Text = text;
        }

        public void setLabelTimeColor(int r, int g, int b)
        {
            lblTime.BackColor = Color.FromArgb(r,g,b);
        }

        //Punktelable-Setters
        public void setLabelScorePosition(int x, int y){
            lblPoint.Location = new System.Drawing.Point(x, y);
            lblPoint.Visible = true;
        }
        public void setLabelScoreSize(int w, int h){
            lblPoint.Size = new System.Drawing.Size(w, h);
        }
        public void setLabelScoreText(String text){
             lblPoint.Text = text;
        }

        //Namenslabel-Setters
        public void setLabelNamePosition(int x, int y){
            lblName.Location = new System.Drawing.Point(x,y);
            lblName.Visible = true;
        }
        public void setLabelNameSize(int w, int h){
            lblName.Size = new System.Drawing.Size(w, h);
        }
        public void setLabelNameText(String text){
            lblName.Text = text;
        }

        //Zeittext-Setters
        public void setTextTimePosition(int x, int y){
            txtTime.Location = new System.Drawing.Point(x, y);
            txtTime.Visible = true;
        }
        public void setTextTimeSize(int w, int h){
            txtTime.Size = new System.Drawing.Size(w, h);
        }
        public void setTime(int t){               
             time = t;
             resetTime = t;
        }

        //Punktetext-Setters
        public void setTextScorePosition(int x, int y){
            txtPoint.Location = new System.Drawing.Point(x, y);
            txtPoint.Visible = true;        
        }
        public void setTextScoreSize(int w, int h){
            txtPoint.Size = new System.Drawing.Size(w, h);
        }

        //Punkte-Setters
        public void setScore(int points){
             txtPoint.Text = points.ToString();
        }

        //Rekordpunktzahltext-Setters
        public void setTextHighscorePosition(int x, int y){
            txtHighscore.Location = new System.Drawing.Point(x, y);
            txtHighscore.Visible = true;
        }

        public void setTextHighscoreSize(int w, int h){
            txtHighscore.Size = new System.Drawing.Size(w, h);
        }
        public void setHighscore(int highscore){
            //highscore = points;
            txtHighscore.Text = "" + highscore;
            points = 0;
        }

        //Rekordpunktzahllabel-Setters
        public void setLabelHighscorePosition(int x, int y){
            lblHighscore.Location = new System.Drawing.Point(x,y);
            lblHighscore.Visible = true;
        }
        public void setLabelHighscoreSize(int w, int h){
            lblHighscore.Size = new System.Drawing.Size(w, h);
        }
        public void setLabelHighscoreText(String text){
            lblHighscore.Text = text;
        }

        //Timermünzen-Setters     
        public void setCoinSize(int w, int h){
            coin.Width = w;
            coin.Height = h;
        }
        public void setCoinPosition(int x, int y){
            coin = new PictureBox(); 
            coin.Visible = true;
            coin.Image = Image.FromFile("../Image/coin.PNG");
            pnlGame.Controls.Add(coin);
            coin.Left = x; 
            coin.Top = y; 
            coin.SendToBack();
        }       
        public void addCoinToList(){
            coinList.Add(coin);
        } 

        //Timer-Setters
        public void setTimerCoinInterval(int interval){
             tmrCoin.Interval = interval;
        }
        public void setTimerGameInterval(int interval){
             tmrGame.Interval = interval;
        }
        public void setTimerEnemyInterval(int interval){
             tmrEnemy.Interval = interval;
        }  

        //Gegner-Setters
        public void setEnemyPosition(int x, int y){
            xEnemy = x;
            yEnemy = y;
            picEnemy.Location = new Point(xEnemy, yEnemy);
            picEnemy.Image = Image.FromFile("../Image/enemy.PNG");
            checkCollision();
            picEnemy.BringToFront();
            pnlGame.Controls.Add(picEnemy);
            
            foreach(PictureBox coin in coinList){
                coin.SendToBack();
            }
        }
        public void setEnemySize(int w, int h){
             widthEnemy = w;
             heightEnemy = h;           
             picEnemy.Width = widthEnemy;
             picEnemy.Height = heightEnemy;
        }
        public void setEnemySpeed(int speed){
            enemySpeed = speed;
        }

        //GegnerBOT-Setters
        public void setEnemyBotPosition(int x, int y){
            xEnemyBot = x;
            yEnemyBot = y;
            picEnemyBot.Location = new Point(xEnemyBot, yEnemyBot);
            Color temp = Color.FromArgb(0XFF8000);
            picEnemyBot.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            checkCollision();
            picEnemyBot.BringToFront();
            pnlGame.Controls.Add(picEnemyBot);
            
            foreach(PictureBox coin in coinList){
                coin.SendToBack();
            }
        }
        public void setEnemyBotSize(int w, int h){
             widthEnemyBot = w;
             heightEnemyBot = h;           
             picEnemyBot.Width = widthEnemyBot;
             picEnemyBot.Height = heightEnemyBot;
        }
        public void setEnemyBotSpeed(int speed){
            enemyBotSpeed = speed;
        }

        //Spieler-Setters
        public void setPlayerSize(int w, int h){
              widthPlayer = w;
              heightPlayer = h;
              picPlayer.Width = widthPlayer;
              picPlayer.Height = heightPlayer;
              picPlayer.Image = Image.FromFile("../Image/player.PNG");  
              picPlayer.SendToBack();
        }

        public void setPlayerPosition(int x, int y){
             xPlayer = x;
             yPlayer = y;
            
             picPlayer.Location = new Point(xPlayer, yPlayer);

        }
        public void setPlayerSpeed(int speed){
            playerSpeed = speed;
        }

        //Wand-Setters
        public void setWallPosition(int x, int y){
            picWall.Location = new System.Drawing.Point(x, y);
            picWall.Visible = true;
        }
        public void setWallSize(int w, int h){
            picWall.Size = new System.Drawing.Size(w, h);
        }  
        public void setWallColour(int r, int g, int b){
            picWall.BackColor = Color.FromArgb(r,g,b);
        }


        /*
         * Getters (mit Rückgabewert / ohne Paramenter)
         */

        //Panel-Getters
        public int getPanelWidth(){
            return pnlGame.Width;
        }
        public int getPanelHeight(){
             return pnlGame.Height;
        }

        //Spieler-Getters
        public int getPlayerPositionX(){
            return xPlayer;
        }
        public int getPlayerPositionY(){
            return yPlayer;
        }
        public int getPlayerWidth(){
            return picPlayer.Width;
        }
        public int getPlayerHeight(){
            return picPlayer.Height;
        }
        public int getPlayerLeft(){
            return picPlayer.Left;
        }
         public int getPlayerTop(){
            return picPlayer.Top;
        }
        public int getPlayerSpeed(){
            return playerSpeed;
        }

        //Gegener-Getters
        public int getEnemyTop(){
            return picEnemy.Top;
        }
        public int getEnemyLeft(){
            return picEnemy.Left;
        }

        //Gegenerbot-Getters
        public int getEnemyBotTop(){
            return picEnemyBot.Top;
        }
        public int getEnemyBotLeft(){
            return picEnemyBot.Left;
        }

        public int getEnemyBotPositionX(){
            return xEnemyBot;
        }
        public int getEnemyBotPositionY(){
            return yEnemyBot;
        }

        public List<PictureBox> getEnemyList(){
              return enemyList;
        }
        public int getNumberOfEnemyList(){
              return enemyList.Count();
        }
    
        //Wand-Getters
        public int getWallWidth(){
            return picWall.Width;
        }
        public int getWallHeight(){
            return picWall.Height;
        }
        public int getWallLeft(){
            return picWall.Left;
        }
        public int getWallTop(){
            return picWall.Top;
        }

        //Zeit-Getter
        public int getTime(){
            return time;
        }

        //Münzen-Getter
        public int getNumberOfCoinList(){
            return coinList.Count();
        }

        //Punkte-Getter
        public int getPoints(){
            return points;
        }

        //Highscore-Getter
        public int getHighscore(){
            return highscore;
        }

        


       /*
        * Methoden
        */

        public void addEnemyToList(){
            enemyList.Add(picEnemy);
        }

        public void addEnemyBotToList(){
            enemyList.Add(picEnemyBot);
        }
        

        //Spiel-Methode
        public void makeGame(Form form){
             //Form            
            Münzenjägerform = form;
            form.WindowState = FormWindowState.Maximized;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1058, 497);
            form.Controls.Add(this.txtHighscore);
            form.Controls.Add(this.lblName);
            form.Controls.Add(this.lblHighscore);
            form.Controls.Add(this.txtPoint);
            form.Controls.Add(this.txtTime);
            form.Controls.Add(this.lblPoint);
            form.Controls.Add(this.lblTime);
            form.Controls.Add(this.btnStop);
            form.Controls.Add(this.btnStart);
            form.Controls.Add(this.btnSpeed);
            form.Controls.Add(this.pnlGame);
            pnlGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            //Panel
            pnlGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlGame.Location = new System.Drawing.Point(12, 12);
            pnlGame.Name = "pnlGame";         
            pnlGame.Controls.Add(this.picWall);
            pnlGame.Visible = false;

            //Spieler
            picPlayer.Visible = false;

            //Gegner
            picEnemy.Visible = false;

            //Wand
            picWall.Name = "picWall";
            picWall.TabStop = false;
            picWall.Visible = false;

            //Startknopf
            btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnStart.Name = "btnStart";          
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += new System.EventHandler(this.btnStart_Click);
            btnStart.Visible = false;
 
            //Stopknopf
            btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnStop.Name = "btnStop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += new System.EventHandler(this.btnStop_Click);
            btnStop.Visible = false;

            //Speedknopf
            btnSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnSpeed.Name = "btnSpeed";
            btnSpeed.UseVisualStyleBackColor = false;
           
            btnSpeed.Visible = false;

            //Zeitlabel
            lblTime.AutoSize = false;
            lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));        
            lblTime.Name = "lblTime";
            lblTime.Visible = false;

            //Punktelabel
            lblPoint.AutoSize = false;
            lblPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPoint.Name = "lblPoint";
            lblPoint.Visible = false;

            //Rekordpunktzahltext
            lblHighscore.AutoSize = false;
            lblHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblHighscore.Name = "lblHighscore";
            lblHighscore.Visible = false;

            //Namenslabel
            lblName.AutoSize = false;
            lblName.Font = new System.Drawing.Font("MV Boli", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblName.Name = "lblName";
            lblName.Visible = false;

            //Zeittext
            txtTime.Enabled = false;
            txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTime.Name = "txtTime";      
            txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtTime.Visible = false;

            //Punktetext
            txtPoint.Enabled = false;
            txtPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPoint.Name = "txtPoint";
            txtPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtPoint.Visible = false;
           
            //Rekordpunktzahltext
            txtHighscore.Enabled = false;
            txtHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHighscore.Name = "txtHighscore";
            txtHighscore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtHighscore.Visible = false;


            btnSpeed.Click += new System.EventHandler(this.btnSpeed_Click);
            
            //Münzentimer
            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);

            //Spieltimer
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);    
            
            tmrSpeed.Tick += new EventHandler(tmrSpeed_Tick);

            tmrSwitch.Tick += new EventHandler(tmrSwitch_Tick);
        }

        //Stop-Methode
        public void stopGame(){
            //Panel
            pnlGame.Controls.Clear();
            pnlGame.Controls.Add(picGameover);

            //GameOver
            picGameover.Visible = true;

            //Startknopf
            btnStop.Enabled = false;

            //Stopknopf
            btnStart.Enabled = true;

            //Spieltimer
            tmrGame.Enabled = false;

            //Münzentimer
            tmrCoin.Enabled = false;

            //Gegnertimer
            tmrEnemy.Enabled = false;

            //Gegnerliste
            enemyList.Clear();

            //Münzenliste
            coinList.Clear();

            //Spielerstartposition
            xPlayer = frmGame.xPlayer;
            yPlayer = frmGame.yPlayer;
        }

        //Panel-Methoden
        public Boolean checkPanelRight(){
            return!(getPlayerPositionX() + getPlayerWidth()>= getPanelWidth());
        }
        public Boolean checkPanelLeft(){
            return !(getPlayerPositionX() <= 0);
        }
        public Boolean checkPanelTop(){
            return !(getPlayerPositionY() <= 0);
        }
        public Boolean checkPanelBottom(){
            return !(getPlayerPositionY() + getPlayerHeight() >= getPanelHeight());
        }
        public Boolean checkWallLeft(){
            return !((getPlayerLeft()+ getPlayerWidth() + 1 >= getWallLeft())&&(getPlayerTop() + getPlayerHeight() >= getWallTop())&&(getPlayerTop() <= getWallTop() + getWallHeight() -1)&&!(getPlayerLeft()>=getWallLeft()));
        }

        //Wand-Methoden
        public Boolean checkWallRight(){
            return !((getPlayerLeft() <= getWallLeft() + getWallWidth() + 3)&&(getPlayerTop() + getPlayerHeight() >= getWallTop())&&(getPlayerTop()<=getWallTop()+ getWallHeight())&&!(getPlayerLeft()+ getPlayerWidth()<=getWallLeft()+getWallWidth()));
        }
        public Boolean checkWallBottom(){
            return !((getPlayerTop() <= getWallTop() + getWallHeight() + 4) && (getPlayerLeft()+ getPlayerWidth() >= getWallLeft())&&(getPlayerLeft() <= getWallLeft() + getWallWidth())&&!(getPlayerTop() + getPlayerHeight() <= getWallTop() + getWallHeight()));
        }
        public Boolean checkWallTop(){
            return  !((getPlayerTop() + getPlayerHeight() +3 >= getWallTop()) && (getPlayerLeft() + getPlayerWidth()>= getWallLeft())&&(getPlayerLeft() <= getWallLeft() + getWallWidth())&&!(getPlayerTop()>=getWallHeight()));
        }

        //Spielersteuerung-Methoden
        public int movePlayerLeft(){
            return xPlayer  -= getPlayerSpeed();
        }
        public int movePlayerRight(){
            return xPlayer += getPlayerSpeed();
        }
        public int movePlayerUp(){
            return yPlayer  -= getPlayerSpeed();
        }
        public int movePlayerDown(){
            return yPlayer  += getPlayerSpeed();
        } 

        //Gegnersteuerung-Methoden
        public void moveEnemyLeft(){
            picEnemy.Left -= enemySpeed;
        }
        public void moveEnemyRight(){
           picEnemy.Left += enemySpeed; 
        }
        public void moveEnemyUp(){
           picEnemy.Top += enemySpeed;
        }
        public void moveEnemyDown(){
            picEnemy.Top -= enemySpeed;
        }

        //GegnerBotsteuerung-Methoden
        public void moveEnemyBotLeft(){
            picEnemyBot.Left -= enemyBotSpeed;
        }
        public void moveEnemyBotRight(){
           picEnemyBot.Left += enemyBotSpeed; 
        }
        public void moveEnemyBotUp(){
           picEnemyBot.Top += enemyBotSpeed;
        }
        public void moveEnemyBotDown(){
            picEnemyBot.Top -= enemyBotSpeed;
        }


        //Zeit-Methode
        public void timeIsUp(){
            timeisup = true;
            txtTime.Text = (time + 1).ToString();
            picGameover.Image = Image.FromFile("../Image/timeisup.PNG");
        }

        //Gegner<-->Wand-Kollision
        public Boolean enemyWallRight() {
            int left = picEnemy.Left;
            int right =  picEnemy.Left + picEnemy.Width;
            int top =  picEnemy.Top;
            int bottom = picEnemy.Top + picEnemy.Height;

            bool test = true;
            if ((right + 1 >= picWall.Left) && (bottom >= picWall.Top) && (top <= picWall.Top + picWall.Height - 1) && !(left >= picWall.Left)){
                test = false;
            }
            return test;
        }
        public Boolean enemyWallLeft(){
            int left = picEnemy.Left;
            int right =  picEnemy.Left + picEnemy.Width;
            int top =  picEnemy.Top;
            int bottom = picEnemy.Top + picEnemy.Height;

            bool test = true;
            if ((left <= picWall.Left+picWall.Width+3)&&(bottom >= picWall.Top)&&(top<= picWall.Top + picWall.Height)&&!(right<=picWall.Left+picWall.Width)){
                test = false;
            }
            return test;
        }
        public Boolean enemyWallBottom(){
            int left = picEnemy.Left;
            int right =  picEnemy.Left + picEnemy.Width;
            int top =  picEnemy.Top;
            int bottom = picEnemy.Top + picEnemy.Height;

            bool test = true;
            if ((top <= picWall.Top + picWall.Height + 6) && (right>= picWall.Left) && (left <= picWall.Left + picWall.Width) && !(bottom <= picWall.Top + picWall.Height)){
                test = false;
            }
            return test;
        }
        public Boolean enemyWallTop(){
            int left = picEnemy.Left;
            int right =  picEnemy.Left + picEnemy.Width;
            int top =  picEnemy.Top;
            int bottom = picEnemy.Top + picEnemy.Height;

            bool test = true;
            if ((bottom + 6 >= picWall.Top) && (right >= picWall.Left) && (left <= picWall.Left + picWall.Width) && !(top>= picWall.Height)){
                test = false;
            }
            return test;
        }

         //Münze<-->Münze-Kollision
         public Boolean checkCoinPosition(int xPosition, int yPosition){
            int zaehler = 0;           
            Boolean test = true;
           
             foreach (PictureBox picCoins in coinList){
                int xCoinLeft =  picCoins.Location.X - coin.Width;
                int xCoinRight =  picCoins.Location.X + picCoins.Width;
                int yCoinLeft =  picCoins.Location.Y - coin.Width;  
                int yCoinRight=  picCoins.Location.Y + coin.Width; 

                int xWallLeft = picWall.Location.X -2*coin.Width;
                int xWallRight = picWall.Location.X + picWall.Width +coin.Width;
                int yWallLeft = picWall.Location.Y -2*coin.Height;
                int yWallRight = picWall.Location.Y+picWall.Height +coin.Height;


                if (((xPosition >= xCoinLeft && xCoinRight >=xPosition ) && (yPosition >= yCoinLeft && yCoinRight >=yPosition ))){
                   test = false;
                }
                if((xPosition >= xWallLeft && xWallRight >= xPosition) && (yPosition >= yWallLeft &&  yWallRight>= yPosition)){
                    test = false;
                }
             }         
            return test;
         }
         
        //Spieler<-->Münze-Kollision
         public void LookForCoin(int punkteProMuenze){
            for (int x = 0; x < coinList.Count(); x++){
                if (coinList[x].Bounds.IntersectsWith(picPlayer.Bounds)){
                    pnlGame.Controls.Remove(coinList[x]);
                    coinList.Remove(coinList[x]);
                    points += punkteProMuenze;
                    switchTime = 1;
                    tmrSwitch.Interval = 1000;             
                    tmrSwitch.Enabled = true;                                     
                    picPlayer.Image = Image.FromFile("../Image/coinPlayer.png");
                    
                }
            }
         }

         public void tmrSwitch_Tick(object sender, EventArgs e){           
            switchTime--;
            
            if(switchTime <= 0){              
                tmrSwitch.Enabled = false;
                picPlayer.Image = Image.FromFile("../Image/player.png");
            }
                   
         }


        //Spieler<-->Gegner-Kollision
        public void LookForEnemy(){
            for (int x = 0; x < enemyList.Count(); x++){    
                if (enemyList[x].Bounds.IntersectsWith(picPlayer.Bounds)){
                    picGameover.Image = Image.FromFile("../Image/gameover.PNG");
                    stopGame();

                   if (points > highscore){
                            setHighscore(points);
                   }       
                }
            }
        }

        //Spieler<-->Gegner-Kollision (beim Erscheinen)
        private void checkCollision(){
            for (int x = 0; x < enemyList.Count(); x++){
                if (enemyList[x].Bounds.IntersectsWith(picPlayer.Bounds)){
                    enemyList[x].Location = new Point(enemyList[x].Width, pnlGame.Height);
                }
            }
        }

        /*
         * Evente
         */

        //Startknopf-Klickevent
        private void btnStart_Click(object sender, EventArgs e){
            //Zeit setzen
            time = resetTime;
            txtTime.Text = time.ToString();

            //Highscore setzen
            if(highscoreistrue){
                txtHighscore.Text = highscore.ToString();
                highscoreistrue = false;
            }
            
            //Punkte
            points = 0;

            //Spieler
            pnlGame.Controls.Add(picPlayer);
            picPlayer.Location = new Point(xPlayer, yPlayer);
            picPlayer.Visible = true;

            //Gegner
            picEnemy.Visible = true;

            //Wand
            picWall.BringToFront();
            pnlGame.Controls.Add(picWall);  

            //GameOver
            picGameover.Image = Image.FromFile("../Image/gameover.PNG");
            picGameover.Width = 900;
            picGameover.Height = 600;
            picGameover.Left = 0;
            pnlGame.Controls.Add(picGameover);
            picGameover.Visible = false;

            //Startknopf
            btnStop.Enabled = true;

            //Stopknopf
            btnStart.Enabled = false;

            //Puktetext
            txtPoint.Text = points.ToString();

            //Münzentimer
            tmrCoin.Enabled = true;

            //Spieltimer
            tmrGame.Enabled = true;

            //Gegnertimer
            tmrEnemy.Enabled = true;
        }

        //Stopknopf-Klickevent
        private void btnStop_Click(object sender, EventArgs e){
            stopGame();
        }

     

       
        
         //Speedknopf-Klickevent
        private void btnSpeed_Click(object sender, EventArgs e){
           
            playerSpeed += addedSpeed;
            setPlayerSpeed(playerSpeed);
            btnSpeed.Enabled = false;
            tmrSpeed.Enabled = true;
        }
        

        public void tmrSpeed_Tick(object sender, EventArgs e){       
            
            timeSpeed--;
            
            
        }
        public int getSpeedTime() { 
            return timeSpeed;
        }
        public int getSpeedDelay() { 
            return timeSpeedDelay;
        }
        public int getAddedPlayerSpeed() { 
            return addedSpeed;
            
        }

        //Münzentimer-Tickevent     
        private void tmrCoin_Tick(object sender, EventArgs e){
            
        }

 
        //Spieltimer-Tickevent    
        private void tmrGame_Tick(object sender, EventArgs e){
            //Zeittext +1
            time = int.Parse(txtTime.Text);
            time -= 1;
            txtTime.Text = time.ToString();
        }           
    }
}
