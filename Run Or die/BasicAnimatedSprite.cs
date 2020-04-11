using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections;

namespace Run_Or_die
{
    class BasicAnimatedSprite : BasicSprite
    {
        protected int frameCount, CurrFrame;
        protected float timePerFrame, timer;
        ///spriteSheet
        public BasicAnimatedSprite(Rectangle pos, Rectangle source, int frameCount, float timePerFrame) : base(pos, source)
        {
            /// resumen
            /// for single sprite 1 dimension
            ///
            this.timePerFrame = timePerFrame;
            this.frameCount = frameCount;
            
        }

        public void load(ContentManager content, string filename)
        {
            //
            // resumen:
            // carga las texturas para los objetos animados 
            //
            try
            {
                textura = content.Load<Texture2D>(filename);
            }
            catch
            {
                textura = content.Load<Texture2D>("GameOver");
            }
            
        }

        public void updt(GameTime game, Rectangle pos1)
        {
            //
            //Resumen:
            //it makes de animacion to go next frame and move posicion with pos1 
            timer = timer + (float)game.ElapsedGameTime.TotalSeconds;
            if (timer >= timePerFrame)
            {
                CurrFrame = (CurrFrame + 1) % frameCount;
                timer = timer - timePerFrame;
            }
            pos = pos1;
        }

        public override void draw(SpriteBatch spriteBatch)
        {

            source.X = CurrFrame * source.Width;
            base.draw(spriteBatch);
        }

        public void RestartSource()
        {
            source.X = 0;
        }
    }
}