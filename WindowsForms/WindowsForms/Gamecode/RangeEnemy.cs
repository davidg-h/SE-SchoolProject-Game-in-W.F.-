﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms.Gamecode
{
    class RangeEnemy : Enemy
    {
        private RangeEnemy(PictureBox eBox, int hp = 10, int dmg = 1) : base(eBox, hp, dmg)
        {

        }
        public RangeEnemy(int hp = 10, int dmg = 1) : base(null, hp, dmg)
        {

            this.CreateNewRangeEnemy();
        }
        internal override int Hp { get => hp; set => hp = value; }
        internal override int Dmg { get => dmg; set => dmg = value; }
        public string Name { get; internal set; }
        static int CurrentPictureIndex = 0;
        public int shootingCounter = 0;
        public RangeEnemyShot Shot { get; set; }


        public static Tuple<Bitmap, Point, string>[] picturesAndLocationArray =
        {
            new Tuple<Bitmap, Point, string>(Properties.Resources.zoombie, new Point(272,310),"monster1"),
            new Tuple<Bitmap, Point,string>(Properties.Resources.monster, new Point(800,310),"monster2"),
            new Tuple<Bitmap, Point, string>(Properties.Resources.zoombie, new Point(1300,310),"monster3"),
            new Tuple<Bitmap, Point,string>(Properties.Resources.monster, new Point(1900,310),"monster4")
                //here you can add the next rangeenemies picture position and name must be adjusted
        };
        public void ShootShot(Form f, string direction)
        {
            if (shootingCounter % 5 == 0) //manipulates frequency of shooting
            {
                this.Shot = new RangeEnemyShot();
                Shot.direction = direction;
                Shot.shotLeft = this.box.Left + (this.box.Width / 2) ;
                Shot.shotTop = this.box.Top + (this.box.Height / 2);
                Shot.CreateShot(f);
               
            }
         
            shootingCounter++;
        }
        public override void move(Form f)
        {
            //TODO move pattern of enemy
        }
        public override void attack()
        {
            //TODO attack pattern enemy small
        }

        private void CreateNewRangeEnemy()
        {
            if (CurrentPictureIndex > picturesAndLocationArray.Length - 1)
            {
                CurrentPictureIndex = 0;
            }
            Tuple<Bitmap, Point, string> currentPicture = picturesAndLocationArray[CurrentPictureIndex];

            this.box = new PictureBox();

            this.box.Image = currentPicture.Item1;
            this.box.Name = currentPicture.Item3;
            this.box.Location = currentPicture.Item2;
            this.box.TabIndex = 21;
            this.box.TabStop = false;
            this.box.Size = new System.Drawing.Size(100, 110);
            this.box.Tag = "rangeEnemy";
            CurrentPictureIndex++;
        }

    }
}