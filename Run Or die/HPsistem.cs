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
    class HPsistem
    {
        BasicSprite icon, life;
        Rectangle vid;
        int vida;

        public HPsistem(Rectangle pos,Rectangle posl, int vida)
        {
            icon = new BasicSprite(pos, new Rectangle(0,0,30,30));
            this.vida = vida*5;
            vid = new Rectangle(pos.X + pos.Width + 5, pos.Y, this.vida, pos.Height);
            life = new BasicSprite(vid, new Rectangle(0,0,30,30));
        }

        public void loadContent(ContentManager content,string filename)
        {
            if (content == null)
                throw new NullReferenceException("Parameter can't be null: content");
            try
            {
                icon.load(content, filename, true);
            }
            catch (System.NullReferenceException exception)
            {
                icon.load(content, "GameOver", true);
            }
            life.load(content, "shot", true);
        }

        public void updt()
        {
            vid.Width = vida;
            life.updt(vid);

        }

        public int LIFE
        {
            get { return vida; }
            set { vida = value; }
        }

        public void draw(SpriteBatch sprite)
        {
            icon.draw(sprite);
            life.draw(sprite);
        }

        public Color BarHPColor
        {
            get { return life.GetColor; }
            set { life.GetColor = value; }
        }
    }
}
