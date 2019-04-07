using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace GameNode
{
    
    public class GameNode
    { 
        public Rectangle Rec { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Alive { get; set; }
    }   
}
