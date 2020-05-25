using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Yazlab3.GraphElements;

namespace Yazlab3
{
    static class Methods
    {
        public static void AddNodes(this MyGraph graph, List<MyNode> listOfNodes)
        {
            
        }

        public static List<MyNode> getNodeList(int count)
        {
            if (count < 1)
            {
                return null;
            }

            var listOfNodes = new List<MyNode>();
            var listOfLetters = getAlphabet(count);
            for (int i = 0; i < count; i++)
            {
                var node = new MyNode();
                node.Name = listOfLetters[i];
                listOfNodes.Add(node);
            }
            return listOfNodes;
        }

        public static List<string> getAlphabet(int count)
        {
            int asciiNumber = 65;
            var listOfLetters = new List<string>();

            for (int i = 0; i < count; i++)
            {
                listOfLetters.Add(((char)asciiNumber).ToString());
                asciiNumber++;
            }

            return listOfLetters;
        }
    }
}
