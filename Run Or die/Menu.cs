using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Run_Or_die
{
    class Menu
    {
        Texture2D fondo;
        Texture2D play, instructions, aboutus, proteccionON, proteccionOFF;
        Texture2D play_off, instructions_off, aboutus_off;
        Color[] pixelData;
        Texture2D fondo_guia;
        int selectedItem;
        int clickedItem, h, w, timer;
        bool proteccion, bloquear;
        public Menu(int h, int w)
        {
            this.h = h;
            this.w = w;
        }
        public void LoadContent(ContentManager Content)
        {
            fondo = Content.Load<Texture2D>("Menu/fondo_menu");
            fondo_guia = Content.Load<Texture2D>("Menu/fondo_menu_3");
            play = Content.Load<Texture2D>("Menu/BotonPLAY");
            play_off = Content.Load<Texture2D>("Menu/BotonPLAYoff");
            instructions = Content.Load<Texture2D>("Menu/BotonINSTRUCCIONES");
            instructions_off = Content.Load<Texture2D>("Menu/BotonINSTRUCCIONESoff");
            aboutus = Content.Load<Texture2D>("Menu/BotonABOUTUS");
            aboutus_off = Content.Load<Texture2D>("Menu/BotonABOUTUSoff");
            proteccionOFF = Content.Load<Texture2D>("Menu/proteccion");//off
            proteccionON = Content.Load<Texture2D>("Menu/proteccion2");//on
            selectedItem = 0;
            clickedItem = 0;
            pixelData = new Color[fondo_guia.Width * fondo_guia.Height]; 
            fondo_guia.GetData<Color>(pixelData);
        }
        public int Update()
        {
            if (fondo_guia.Bounds.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                timer++;
                Color pixel = pixelData[Mouse.GetState().Y * fondo_guia.Width + Mouse.GetState().X];

                selectedItem = 0;
                if (pixel.R == 255 && pixel.G == 0 && pixel.B == 254)
                    selectedItem = 1;
                if (pixel.R == 0 && pixel.G == 0 && pixel.B == 254)
                    selectedItem = 2;
                if (pixel.R == 0 && pixel.G == 255 && pixel.B == 1)
                    selectedItem = 3;

                if (pixel.R == 234 && pixel.G == 255 && pixel.B == 0)
                {
                    selectedItem = 5;
                }
                if (selectedItem ==5 && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    
                    proteccion = true;

                }
                if (selectedItem == 5 && Mouse.GetState().LeftButton == ButtonState.Pressed && proteccion && timer > 15)
                {

                    proteccion = false;
                    if (timer >= 60)
                    {
                        timer = 0;
                    }

                }
                if (selectedItem > 0 && selectedItem !=5 && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    clickedItem = selectedItem;
                    return clickedItem;
                }
            }
            return 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fondo, new Rectangle(0, 0, w, h), Color.White);
            //spriteBatch.Draw(fondo_guia, new Rectangle(0, 0, w, h), Color.White);
            spriteBatch.Draw(play, new Rectangle(400, 240, 200, 200), Color.White);
            spriteBatch.Draw(instructions, new Rectangle(110, 450, 340, 130), Color.White);
            spriteBatch.Draw(aboutus, new Rectangle(545, 450, 340, 130), Color.White);
            

            if (selectedItem == 1)
            {
                spriteBatch.Draw(play_off, new Rectangle(401, 240, 200, 200), Color.White);
            }
            if (selectedItem == 2)
            {
                spriteBatch.Draw(instructions_off, new Rectangle(112, 450, 335, 125), Color.White);
            }
            if (selectedItem == 3)
            {
                spriteBatch.Draw(aboutus_off, new Rectangle(547, 450, 335, 125), Color.White);
            }
            if (proteccion)
            {
          

                spriteBatch.Draw(proteccionON, new Rectangle(755, 215, 140, 90), Color.White);
                
               
            }
            else
                spriteBatch.Draw(proteccionOFF, new Rectangle(755, 215, 140, 90), Color.White);

        }
        public bool GetProteccion()
        {
            return proteccion;
        }
    }
}
