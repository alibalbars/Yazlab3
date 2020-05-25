using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab3.GraphElements
{
    class MyPipe
    {
        public string StartingPoint{ get; set; }
        public string EndPoint{ get; set; }
        public int StartingValue { get; set; }
        public int EndingValue { get; set; }

        public MyNode StartingNode { get; set; }
        public MyNode EndingNode { get; set; }

    }
}
