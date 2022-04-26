using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Party_WPF.Domain
{
    public class Rede : EntityBase
    {
        Rectangle rect;
        public Rede(Canvas canvas) : base(canvas)
        {
            X = 120;
            Y = (int) canvas.Height - 115;
            Height = 156;
            Width = 175;
            rect = Rect;
            rect.Fill = Helper.GetImage(Assets.netLeft);
            rect.Margin = Position;
        }

        public override void Draw()
        {
            Canvas.Children.Add(rect);
        }

        public void Mover()
        {
            rect.Margin = Position;
        }
    }
}
