using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace Run_Or_die
{
    class Enemy:Character
    {
        int inicial;
        int vida;
        public Enemy(Rectangle pos) : base(pos, 5, new Rectangle(0, 0,310,353), 3, new Rectangle(0, 353, 217, 350), 8, new Rectangle(0,700, 417, 346), "zombie_v004")
        {
            this.pos = pos;
            speed = -5;
            jumpSpeed = 9;
            inicial = pos.X;
            vida = 20;
        }

        public override void updt(GameTime gameTime, Rectangle recti)
        {
            if (recti == null)
                throw new NullReferenceException("parameter can't be null : recti");

            pos.X += speed;                                                    // automatic movement across de screen from right to left 
            //estado = State.run;

            timer = timer + (float)gameTime.ElapsedGameTime.TotalSeconds;       // timer for the automatic jump 

            if (timer>1 && !saltar)   // jump 
            {
                //Resumen
                estado = State.jump;
                ymax = pos.Y - (pos.Height + 30);                                      // this will alow the character to jump one time 
                ymin = pos.Y;
                saltar = true;
            }
            if (saltar)
            {
                pos.Y -= jumpSpeed;

                if (pos.Y <= ymax)
                {
                    jumpSpeed *= -1;
                }
                if (pos.Y >= ymin)
                {
                    jumpSpeed *= -1;
                    saltar = false;
                    estado = State.run;
                }
                timer = 0;
            }

            if (pos.X < -pos.Width)                                             //every time the enemy exit the screen it reappers at the inicial position 
                pos.X = inicial;
            base.updt(gameTime, pos);
                                                                               //things to do 
                                                                               //the collisions haven't been implemented yet
                                                                               //when the enemy die change the animacion to agony and slow the speed 
        }

        public int LIFE
        {
            get { return vida; }
            set { vida = value; }
        }
    }
}
