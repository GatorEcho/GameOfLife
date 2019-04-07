using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Timers;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<GameNode> gameNodes = new List<GameNode>();
        Timer tmr = new Timer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int number = 2501;
            int y = 1;
            int x = 1;
            int width = 10;
            int height = 10;
            int top = 10;
            int left = 10;

            for (int i = 1; i < number; i++)
            {
                // Create the rectangle
                Rectangle rec = new Rectangle()
                {
                    Width = width,
                    Height = height,
                    Fill = Brushes.Black,
                    Stroke = Brushes.AntiqueWhite,
                    StrokeThickness = 1,
                };

                rec.MouseLeftButtonDown += (send, eventargs) =>
                {
                    Flip_Rectangle(rec);
                };
                // Add to a canvas
                cnvTest.Children.Add(rec);
                Canvas.SetTop(rec, top);
                Canvas.SetLeft(rec, left);
                ;

                GameNode node = new GameNode(rec, x, y, false, 0);
                gameNodes.Add(node);

                left += 10;
                if (x % 50 == 0)
                {
                    top += 10;
                    left = 10;
                    y++;
                    x = 0;
                }
                x++;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            tmr.Interval = 1000;
            tmr.Start();
            tmr.Elapsed += (s, rea) =>
            {
                GameBoard gameBoard = new GameBoard(gameNodes);
                gameBoard.EvaluateBoard();
                gameBoard.UpdateBoard();
            };
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            tmr.Stop();
            foreach(GameNode node in gameNodes)
            {
                node.Kill();
            }
        }

        private void Flip_Rectangle(Rectangle rec)
        {
            var node = gameNodes.Select(n => n).Where(n => n.Rec == rec).FirstOrDefault();
            
            if (node.Alive)
            {
                node.Kill();
            }
            else
            {
                node.Birth();
            }
        }
    }
}
