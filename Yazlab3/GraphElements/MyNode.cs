using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab3.GraphElements
{
    class MyNode
    {
        public string Name { get; set; }
        public List<MyPipe> Pipes { get; set; }
        public bool IsStartingPoint { get; set; }
        public bool IsEndPoint { get; set; }


        public MyNode()
        {
            Pipes = new List<MyPipe>();
        }
        

    }
}
