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
    class Hero:Character
    {
         HPsistem vida;
        bool vivo;

        public Hero(Rectangle pos,Rectangle posL) : base(pos,6, new Rectangle(0, 0, 195, 349), 8, new Rectangle(0,349,205, 357), 9, new Rectangle(0,704,332, 347), "char_v")
        {
            if (pos == null || posL == null)
                throw new NullReferenceException("parameter can't be null: pos or posL");
            this.pos = pos;
            speed = 5;
            jumpSpeed = 9;
            vida = new HPsistem(posL, new Rectangle(5,5,10,10), 30);

        }


        public override void load(ContentManager content)
        {
            try
            {
                vida.loadContent(content, "charIcon");
            }catch(NullReferenceException exception)
            {
                vida.loadContent(content, "GameOver");
            }
            base.load(content);
        }



        public override void updt(GameTime gameTime,Rectangle recti) // keyboard movement and collisions 
        {
            if (recti == null)
                throw new NullReferenceException("parameter can't be null : recti");
            if (Keyboard.GetState().IsKeyDown(Keys.Right))      //movement to th right 
            {                                                   //Resumen 
                if (pos.X < (pos.Width*5))                                // this will allow the character to move 725 (check) pixels to the right to make the aperance its accelerating  1
                {
                    pos.X += speed;
                    if(estado!=State.jump)
                    estado = State.run;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))   //movement to the left 
            {                                               //Resumen 
                if (pos.X > 5)                              // this will alow the character to move back to the inicial posicion faster to make the aperance of deceleration 
                {
                    pos.X -= speed;
                    if (estado != State.jump)
                        estado = State.run;
                }
            }
            else if (pos.X > 5)                              // this will alow the character to move back to the inicial posicion faster to make the aperance of deceleration 
            {
                pos.X -= (speed/2);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !saltar)   // jump 
            {      
                //Resumen
                estado = State.jump;
                ymax = pos.Y - (pos.Height+80);                                      // this will alow the character to jump one time 
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
                if (vida.LIFE == 0)
                {
                    vivo = false;
                }
            }
            vida.updt();
            base.updt(gameTime, pos);
                                                                           //things to do 
                                                                           //the collisions haven't been implemented yet
                                                                           //when the hero dies changes the animation to agony
        }


        public bool Vivo
        {
            get { return vivo; }
            set { vivo = value; }
        }
        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
        }
        public void drawLife(SpriteBatch spriteBatch)
        {
            vida.draw(spriteBatch);
        }

    }
}
