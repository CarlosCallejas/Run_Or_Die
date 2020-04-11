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
    class About_us
    {
        Texture2D aboutus, aboutus_guia, botonBACK, botonBACK_off;
        Color[] pixelData;
        int selectedItem, h, w;
        public bool back;

        public About_us (int h, int w)
        {
            this.h = h;
            this.w = w;
        }

        public void LoadContent(ContentManager Content)
        {
            aboutus = Content.Load<Texture2D>("Menu/about us");
            aboutus_guia = Content.Load<Texture2D>("Menu/guia_about");
            selectedItem = 0;
            botonBACK = Content.Load<Texture2D>("Menu/BotonBACK");
            botonBACK_off = Content.Load<Texture2D>("Menu/BotonBACKOFF");
            pixelData = new Color[aboutus_guia.Width * aboutus_guia.Height];
            aboutus_guia.GetData<Color>(pixelData);
        }
        public void Update()
        {
            if (aboutus_guia.Bounds.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {

                Color pixel = pixelData[Mouse.GetState().Y * aboutus_guia.Width + Mouse.GetState().X];

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
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(aboutus, new Rectangle(0, 0, w, h), Color.White);
          //  spriteBatch.Draw(aboutus_guia, new Rectangle(0, 0, w, h), Color.White);
            spriteBatch.Draw(botonBACK, new Rectangle(770, 472, 200, 125), Color.White);
            if (selectedItem == 1)
            {
                spriteBatch.Draw(botonBACK_off, new Rectangle(770, 472, 200, 125), Color.White);
            }
        }
    }
}
