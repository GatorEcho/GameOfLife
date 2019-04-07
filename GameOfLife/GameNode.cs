using System.Windows.Shapes;
using System.Windows.Media;

namespace GameOfLife
{
    public class GameNode
    {
        public GameNode(Rectangle rec, int x, int y, bool alive)
        {
            Rec = rec;
            X = x;
            Y = y;
            Alive = alive;
        }

        public Rectangle Rec { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Alive { get; set; }

        public void Kill()
        {
            Rec.Dispatcher.Invoke(() =>
            {
                Rec.Fill = Brushes.DarkSlateGray;
            });
            
            Alive = false;
        }
        public void Birth()
        {
            Rec.Dispatcher.Invoke(() =>
            {
                Rec.Fill = Brushes.CornflowerBlue;
            });
            Alive = true;
        }


    }
}
