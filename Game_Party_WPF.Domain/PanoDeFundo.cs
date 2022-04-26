using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Party_WPF.Domain
{
    public class PanoDeFundo : EntityBase
    {
        Rectangle rect;
        public PanoDeFundo(Canvas canvas) : base(canvas)
        {
            X = 0;
            Y = 0;
            Height = (int)canvas.Height;
            Width = (int)canvas.Width;

            rect = Rect;
            rect.Fill = Helper.GetImage(Assets.background);
            rect.Margin = Position;

        }

        public override void Draw()
        {
            Canvas.Children.Add(rect);
        }
    }
}
