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
        enum State { run,jump, dead};
    class Character
    {
        // this clas is for the hero and enemy 
        protected BasicAnimatedSprite run,agony,jump;
        protected Rectangle pos;
        protected State estado;
        string nombreTextura;

        protected bool saltar;
        protected int ymax, ymin;
        protected int speed, jumpSpeed;
        protected float timer;

        
        public Character(Rectangle pos, int frameCountR, Rectangle sourceRectR, int frameCountJ, Rectangle sourceRectJ, int frameCountA, Rectangle sourceRectA,string textura) //modificar para pasar un solo SourceRect 
        {
            if (pos == null)
                throw new NullReferenceException("parameter can't be null: pos");
            run = new BasicAnimatedSprite(pos,sourceRectR, frameCountR, .05f);         // the 3 main states they will have
            jump = new BasicAnimatedSprite(pos, sourceRectJ, frameCountJ, .1f);
            agony = new BasicAnimatedSprite(pos, sourceRectA, frameCountA, .05f);
            nombreTextura = textura;
            estado = State.run;
        }

        public virtual void load(ContentManager content)
        {
            try
            {
                run.load(content, nombreTextura);
            }
            catch (NullReferenceException exception)
            {
                run.load(content, "GameOver");
            }
            try
            {
                jump.load(content, nombreTextura);
            }
            catch(NullReferenceException exception)
            {
                jump.load(content, "GameOver");
            }
            try
            {
                agony.load(content, nombreTextura);
            }catch(NullReferenceException exception)
            {
                agony.load(content, "GameOver");
            }
        }

        public virtual void updt(GameTime gameTime,Rectangle rect)
        {
            if (rect == null)
                throw new NullReferenceException("parameter can't be null: rect");
            if (estado == State.run)
                run.updt(gameTime, rect);
            if (estado == State.jump)
            {
                jump.RestartSource();
                jump.updt(gameTime, rect);
            }
            agony.updt(gameTime, rect);
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (estado == State.dead)
            {
                agony.draw(spriteBatch);
            }
            if (estado == State.run)
            {
                run.draw(spriteBatch);
            }
            if (estado == State.jump)
            {
                jump.draw(spriteBatch);
            }
        }
    }
}
