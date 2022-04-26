using Game_Party_WPF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Game_Party_WPF.UI
{
    public partial class MainWindow : Window
    {
        Random random;
        Canvas canvas;
        PanoDeFundo panoDeFundo;
        List<Presente> presentes;
        Rede rede;
        DispatcherTimer gameTimer;
        DispatcherTimer presentesTimer;
        int presentesIntervalo = 30;
        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            Mouse.OverrideCursor = Cursors.None;
            canvas = new Canvas();
            canvas.Height = this.Height;
            canvas.Width = this.Width;
            this.AddChild(canvas);
            panoDeFundo = new PanoDeFundo(canvas);
            rede = new Rede(canvas);
            presentes = new List<Presente>();
            panoDeFundo.Draw();
            rede.Draw();            

            gameTimer = new DispatcherTimer(DispatcherPriority.Render);
            gameTimer.Interval = TimeSpan.FromMilliseconds(16.666);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            presentesTimer = new DispatcherTimer(DispatcherPriority.Render);
            presentesTimer.Interval = TimeSpan.FromMilliseconds(30);
            presentesTimer.Tick += PresentesTimer_Tick;
            presentesTimer.Start();

        }

        private void PresentesTimer_Tick(object sender, EventArgs e)
        {
            if(presentesIntervalo <= 0)
            {
                presentes.Add(new Presente(canvas, random));
                presentes.ForEach(p => p.Draw());
                presentesIntervalo = random.Next(10, 60);

            }
            presentesIntervalo--;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            presentes.ForEach(p => p.Gravity());
            Point p = Mouse.GetPosition(this);
            rede.X = (int)p.X;

            if (p.X <= 5)
                rede.X = 5;
            else if (p.X >= 450)
                rede.X = 450;

            rede.Mover();
        }
    }
}
