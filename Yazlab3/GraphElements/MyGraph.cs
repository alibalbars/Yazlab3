using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab3.GraphElements
{
    class MyGraph
    {
        public List<MyNode> Nodes { get; set; }
        public List<MyPipe> Pipes { get; set; }

        public MyGraph()
        {
            Nodes = new List<MyNode>();
            Pipes = new List<MyPipe>();
        }
    }
}
