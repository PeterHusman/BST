using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node
    {
        public Node(int key)
        {
            Key = key;
        }
        public Node Parent;
        public Node LChild;
        public Node RChild;
        public int Key;

        public int ChildrenCount
        {
            get
            {
                return Convert.ToInt32(LChild != null) + Convert.ToInt32(RChild != null);
            }
        }

        public int Height;
        public int Balance;
    }
}
