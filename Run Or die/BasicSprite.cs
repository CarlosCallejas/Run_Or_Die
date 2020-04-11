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
    class BasicSprite
    {
        protected Rectangle pos, source;
        protected Texture2D textura;
        protected Color color;

        public BasicSprite(Rectangle pos,Rectangle source)
        {
            this.pos = pos;
            this.color = Color.White;
            this.source = source;
        }

        public virtual void load(ContentManager content,string textu,bool muchos)
        {
            try
            {
                textura = content.Load<Texture2D>(textu);
            }catch(Exception exception)
            {
                textura = content.Load<Texture2D>("GameOver");
            }
            if (muchos)
            {
                source.Height = textura.Height;
                source.Width = textura.Width;
            }

        }

        public  virtual void updt(Rectangle rect)
        {
            pos = rect;
        }

        public virtual void draw(SpriteBatch sprite)
        {

            sprite.Draw(textura, pos,source, color);

        }

        public Color GetColor
        {
            get { return color; }
            set { color = value; }
        }


        public Rectangle SOURCE
        {
            get { return source; }
            set { source = value; }
        }


    }  
}
