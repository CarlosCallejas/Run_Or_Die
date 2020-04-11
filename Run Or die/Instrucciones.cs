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
    class Instrucciones
    {
        Texture2D instrucciones, instrucciones_guia, botonBACK, botonBACK_off;
        Color[] pixelData;
        int selectedItem, h,w;
        public bool back;

        public Instrucciones(int h, int w)
        {
            this.h = h;
            this.w = w;
        }

        public void LoadContent(ContentManager Content)
        {
            instrucciones = Content.Load<Texture2D>("Menu/INSTRCCIONES");
            instrucciones_guia = Content.Load<Texture2D>("Menu/guia_instrucc");
            botonBACK = Content.Load<Texture2D>("Menu/BotonBACK");
            botonBACK_off = Content.Load<Texture2D > ("Menu/BotonBACKOFF");
            selectedItem = 0;
            pixelData = new Color[instrucciones_guia.Width * instrucciones_guia.Height];
            instrucciones_guia.GetData<Color>(pixelData);
        }

        public void Update()
        {
            if (instrucciones_guia.Bounds.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {

                Color pixel = pixelData[Mouse.GetState().Y * instrucciones_guia.Width + Mouse.GetState().X];

                selectedItem = 0;
                if (pixel.R == 255 && pixel.G == 0 && pixel.B == 255)
                {
                    selectedItem = 1;
                }
               
                if (selectedItem >= 1 && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    back = true;
                }


            }
            
        }
        public bool Back()
        {
            return back;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(instrucciones, new Rectangle(0, 0, w, h), Color.White);
            //spriteBatch.Draw(instrucciones_guia, new Rectangle(0, 0, w, h), Color.White);
            spriteBatch.Draw(botonBACK, new Rectangle(770, 472, 200, 125), Color.White);
            if (selectedItem == 1)
            {
                spriteBatch.Draw(botonBACK_off, new Rectangle(770, 472, 200, 125), Color.White);
            }
        }
    }
}
