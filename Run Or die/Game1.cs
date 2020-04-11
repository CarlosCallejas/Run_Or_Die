using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Run_Or_die
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //all
        Hero hero;
        Enemy enemigo;
        Car Car;
        BackGround back;
        float score;
        SpriteFont Score;
        //menu
        Menu menu;
        Texture2D ready, letsgo;
        Instrucciones instruccion;
        About_us aboutus;
        int currentScene, timer;
        //Sonido 
        SoundEffect cancion1, cancionMenu;
        SoundEffectInstance c1_instancia, CanMenu_instancia;
        int h, w;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferHeight = 600;
            this.graphics.PreferredBackBufferWidth = 1000;
            this.IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            w = GraphicsDevice.Viewport.Width;
            h = GraphicsDevice.Viewport.Height;
            
            //Sonido
            cancion1 = Content.Load<SoundEffect>("Cancion1");
            c1_instancia = cancion1.CreateInstance();
            cancionMenu = Content.Load<SoundEffect>("CancionMenu");
            CanMenu_instancia = cancionMenu.CreateInstance();

            //texto
            Score = Content.Load<SpriteFont>("socre");
            //MENU
            menu = new Menu(h, w);
            currentScene = 0;
            menu.LoadContent(Content);
            instruccion = new Instrucciones(h, w);
            instruccion.LoadContent(Content);
            aboutus = new About_us(h, w);
            aboutus.LoadContent(Content);
            letsgo = Content.Load<Texture2D>("Menu/letsgo");
            ready = Content.Load<Texture2D>("Menu/Ready");


            hero = new Hero(new Rectangle(5, h -( (h / 4) +3), w/15, h/4),new Rectangle(5,70,40,50));
            back = new BackGround(h, w);
            enemigo = new Enemy(new Rectangle(w, h - ((h / 4) + 3), w / 13, h / 4));


            enemigo.load(Content);
            hero.load(Content);
            back.loadContent(Content);
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (currentScene == 0)
            {
                currentScene = menu.Update();
                Car = new Car(new Rectangle(5, h - ((h / 3) + 3), w / 7, h / 3), new Rectangle(5, 15, 40, 50), menu.GetProteccion());
                Car.load(Content, "CarSpriteSheet", false);
                score = 0;
            }
            if (currentScene == 1)
            {
                back.update(gameTime);
                score = score + (float)gameTime.ElapsedGameTime.Seconds;
                if (!Car.Vivo)
                {
                    hero.updt(gameTime, new Rectangle());
                }
                else
                {
                    Car.updt(new Rectangle());
                }
                enemigo.updt(gameTime, new Rectangle());
            }
            if (currentScene == 2)
            {
                instruccion.Update();
                if (instruccion.back)
                {
                    currentScene = 0;
                    instruccion.back = false;
                }
            }
            if (currentScene == 3)
            {
                aboutus.Update();

                if (aboutus.back)
                {
                    currentScene = 0;
                    aboutus.back = false;
                }
            }
           
            base.Update(gameTime);
        }

       
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            if (currentScene == 0)
            {
                menu.Draw(spriteBatch);
                CanMenu_instancia.IsLooped = true;
                CanMenu_instancia.Play();
            }
            if (currentScene == 1)
            {
                timer++;
                CanMenu_instancia.Stop();
                if (timer < 130)
                {
                    spriteBatch.Draw(ready, new Rectangle(0, 0, w, h), Color.White);
                }
                else if (timer < 260)
                {
                    spriteBatch.Draw(letsgo, new Rectangle(0, 0, w, h), Color.White);
                }
                else if (timer >= 260)
                {
                    c1_instancia.IsLooped = true;
                    c1_instancia.Play();
                    back.draw(spriteBatch);
                    if (!Car.Vivo)
                    {
                        hero.draw(spriteBatch);
                    }
                    else
                    {
                        Car.draw(spriteBatch);
                    }
                    hero.drawLife(spriteBatch);
                    enemigo.draw(spriteBatch);
            spriteBatch.DrawString(Score, score.ToString(), new Vector2(10, 10), Color.Black);
                }
            }
            if (currentScene == 2)
            {
                instruccion.Draw(spriteBatch);

            }
            if (currentScene == 3)
            {
                aboutus.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);

            //esto es para dibujar el escrito pero no se donde shingaos ponerlo asi que lo puse aqui xxdxdxdxddxdddd porfavor borren esto no se pasen de lanza
        }
    }
}
