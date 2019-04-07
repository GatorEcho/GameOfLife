using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameOfLife
{
    class GameBoard
    {
        public GameBoard(List<GameNode> gameNodes)
        {
            GameNodes = gameNodes;
        }

        public List<GameNode> GameNodes { get; set; }

        public void EvaluateBoard()
        {
            foreach (var node in GameNodes)
            {
                int count = 0;

                if (LivingNeighbor(node.X - 1, node.Y))
                {
                    count++;
                }
                if (LivingNeighbor(node.X + 1, node.Y))
                {
                    count++;
                }
                if (LivingNeighbor(node.X, node.Y - 1))
                {
                    count++;
                }
                if (LivingNeighbor(node.X, node.Y + 1))
                {
                    count++;
                }
                if (LivingNeighbor(node.X + 1, node.Y + 1))
                {
                    count++;
                }
                if (LivingNeighbor(node.X - 1, node.Y - 1))
                {
                    count++;
                }
                if (LivingNeighbor(node.X + 1, node.Y - 1))
                {
                    count++;
                }
                if (LivingNeighbor(node.X - 1, node.Y + 1))
                {
                    count++;
                }

                if ((node.Alive && count < 2) || (node.Alive && count > 3))
                {
                    node._state = GameNode.State.WillDie;
                }
                else if (!node.Alive && count == 3)
                {
                    node._state = GameNode.State.WillBirth;
                }
            }
        }

        public void UpdateBoard()
        {
            foreach(var node in GameNodes)
            {
                if(node._state == GameNode.State.WillDie)
                {
                    node.Kill();                    
                }
                else if(node._state == GameNode.State.WillBirth)
                {
                    node.Birth();
                }
            }
        }

        public bool LivingNeighbor(int x, int y)
        {           
            var neighbor = GameNodes.Select(n => n).Where(n => n.X == x && n.Y == y).FirstOrDefault();
            if (neighbor != null && neighbor.Alive)
            {
                return true;
            }
            return false;
        }
    }
}
