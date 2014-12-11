using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIKUEngine.GUIComponents
{
    public class GUIElement : IDrawable
    {
        private Texture2D _texture;

        private Rectangle _rectangle;

        private string assetName;

        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; }
        }

        public delegate void ElementClicked(string element);

        public event ElementClicked clickEvent;

        public GUIElement(string assetName)
        {
            this.assetName = assetName;
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>(assetName);

            _rectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);
        }

        public void Update()
        {
            if (_rectangle.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clickEvent(assetName);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }

        public void CenterElement(int height, int width)
        {
            _rectangle = new Rectangle((width / 2) - (this._texture.Width / 2), (height / 2) - (this._texture.Height / 2), this._texture.Width, this._texture.Height);
        }

        public void MoveElement(int x, int y)
        {
            _rectangle = new Rectangle(_rectangle.X += x, _rectangle.Y += y, this._texture.Width, this._texture.Height);
        }
    }
}
