using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game_Party_WPF.Domain
{
    public class Presente : EntityBase
    {
        Rectangle rect;
        byte[][] imgs = { Assets.present_01, Assets.present_02, Assets.present_03, Assets.present_04, Assets.present_05, Assets.present_06 };
        public Presente(Canvas canvas, Random random) : base(canvas)
        {
            X = random.Next(0, 440);
            Y = -100;
            Height = 85;
            Width = 77;
            rect = Rect;
            rect.Fill = Helper.GetImage(imgs[random.Next(0,5)]);
            rect.Margin = Position;
        }

        public override void Draw()
        {
            if (!Canvas.Children.Contains(rect))
                Canvas.Children.Add(rect);
        }

        public override void Gravity()
        {
            base.Gravity();
            rect.Margin = Position;
        }
    }
}
