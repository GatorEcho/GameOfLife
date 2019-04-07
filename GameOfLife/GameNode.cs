using System.Windows.Shapes;
using System.Windows.Media;

namespace GameOfLife
{
    public class GameNode
    {
        public enum State {Idle, WillDie, WillBirth };

        public GameNode(Rectangle rec, int x, int y, bool alive, State state)
        {
            Rec = rec;
            X = x;
            Y = y;
            Alive = alive;
            _state = state;
        }

        public Rectangle Rec { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Alive { get; set; }
        public State _state { get; set; }
        

        public void Kill()
        {
            Rec.Dispatcher.Invoke(() =>
            {
                Rec.Fill = Brushes.Black;
            });
            Alive = false;
            _state = State.Idle;
        }
        public void Birth()
        {
            Rec.Dispatcher.Invoke(() =>
            {
                Rec.Fill = Brushes.LimeGreen;
            });
            Alive = true;
            _state = State.Idle;
        }


    }
}
