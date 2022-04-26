using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Party_WPF.Domain
{
   public abstract class EntityBase
    {
        protected const int GRAVITY = 2;
        
        public EntityBase(Canvas canvas)
        {
            this.IsAlive = true;
            this.Canvas = canvas;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Canvas Canvas { get; set; }
        public bool IsAlive { get; set; }
        public Rectangle Rect { get { return GetRetangle(); } }
        public Thickness Position { get { return GetPosition(); }  }
        public Rect Area { get { return GetArea(); } }        
        public int FallVelocity { get; set; }

        public abstract void Draw();

        public virtual void Gravity()
        {
            FallVelocity += GRAVITY;
            Y += FallVelocity;
        }

        private Rectangle GetRetangle()
        {
            return new Rectangle
            {
                Height = this.Height,
                Width = this.Width
            };
        }

        public Thickness GetPosition()
        {
            return new Thickness(X, Y, X + Width, Y + Height);
        }

        private Rect GetArea()
        {
            return new Rect(new Point(X, Y), new Size(Width, Height));
        }
    }
}
