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
    class Car:BasicSprite
    {
        int speed;
        HPsistem vida;
        BasicSprite proteccion;
        bool prote, vivo;

        public Car (Rectangle pos,Rectangle posL,bool prote):base(pos,new Rectangle(0, 0, 80, 47))
        {
            this.pos = pos;
            speed = 5;
            int amountVida = 80;
            this.prote = prote;
            vivo = true;
            if (prote)
            {
                proteccion = new BasicSprite(pos, new Rectangle());
                amountVida += 20;
            }
            vida = new HPsistem(posL, new Rectangle(5, 5, 10, 10), amountVida);
        }

        public override void load(ContentManager content, string textu, bool muchos)
        {
            try
            {
                vida.loadContent(content, "CarIcon");
            }catch(NullReferenceException exception)
            {
                vida.loadContent(content, "GameOver");
            }
            if (prote)
            {
                try
                {
                    proteccion.load(content, "escudo", true);
                }
                catch
                {
                    proteccion.load(content, "GameOver", true);
                }
            }
            base.load(content, textu, muchos);
        }

        public override void updt(Rectangle rect)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))      //movement to th right 
            {                                                   //Resumen 
                if (pos.X < (pos.Width*2) )                               // this will allow the character to move 725 (check) pixels to the right to make the aperance its accelerating  1
                {
                    pos.X += speed;
                }
            }
           else if (Keyboard.GetState().IsKeyDown(Keys.Left))   //movement to the left 
            {                                               //Resumen 
                if (pos.X > 5)                              // this will alow the character to move back to the inicial posicion faster to make the aperance of deceleration 
                {
                    pos.X -= speed;
                }
            }
            else if (pos.X > 5)                              // this will alow the character to move back to the inicial posicion faster to make the aperance of deceleration 
            {
                pos.X -= (speed / 2);
            }
            if (prote)
            {
                proteccion.updt(pos);
            }
            base.updt(pos);
            vida.updt();

            Rectangle posrec = SOURCE;
            if (vida.LIFE >= 100 && vida.LIFE < 60)
            {
                if (prote)
                    prote = true;
                vida.BarHPColor = Color.Blue;
            }
            if (vida.LIFE < 60 && vida.LIFE > 40)
            {
                prote = false;
                posrec.X = 80;
                vida.BarHPColor = Color.Green;
            }
            else if (vida.LIFE < 40 && vida.LIFE > 20)
            {
                prote = false;
                posrec.X = 160;
                vida.BarHPColor = Color.Yellow;
            }
            else if (vida.LIFE < 20 && vida.LIFE > 0)
            {
                prote = false;
                posrec.X = 240;
                vida.BarHPColor = Color.Red;
            }
            if (vida.LIFE == 0)
            {
                vivo = false;
            }
            SOURCE = posrec;
        }

        public bool Vivo
        {
            get { return vivo; }
            set { vivo = value; }
        }

        public override void draw(SpriteBatch sprite)
        {
            vida.draw(sprite);
            base.draw(sprite);
            if (prote)
            {
                proteccion.draw(sprite);
            }
        }
    }
}
