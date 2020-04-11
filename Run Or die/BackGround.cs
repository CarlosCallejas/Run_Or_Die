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
    class BackGround
    {
        Rectangle c1, c2;
        Texture2D  textura;
        int w, h;
        int speed;
        float timer;
        public BackGround(int h,int w)
        {
            c1 = new Rectangle(0, 0, w+20, h);
            c2 = new Rectangle(w, 0, w+20, h);
            this.w = w;
            this.h = h;
            timer = 1;
        }

        public void loadContent (ContentManager content)
        {
            textura=content.Load<Texture2D>("background");
        }

        public void update(GameTime game)
        {
            timer = timer + (float)game.ElapsedGameTime.TotalSeconds;
            if (timer >= 5)
            {
                speed++;
                timer = 0;
            }
            c1.X -= speed;
            c2.X -= speed;
            if (c1.X < (w * -1))
            {
                c1.X = w-10;
            }
            else if (c2.X < (w * -1))
            {
                c2.X = w-10;
            }
        }

        public void draw(SpriteBatch sprite)
        {
            sprite.Draw(textura, c1, Color.White);
            sprite.Draw(textura, c2, Color.White);
        }
    }
}
