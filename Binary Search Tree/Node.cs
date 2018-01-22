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
            height = 1;
            Red = true;
        }


        public Node Parent;

        public bool Red;

        public Node LChild;
        public Node RChild;
        public int Key;

        private int height;

        public int ChildrenCount
        {
            get
            {
                return Convert.ToInt32(LChild != null) + Convert.ToInt32(RChild != null);
            }
        }

        public int Height
        {
            get
            {
                height = Math.Max(LChild == null ? 0 : LChild.height, RChild == null ? 0 : RChild.height) + 1;
                return height;
            }
            private set
            {
                height = value;
            }
        }
        public int Balance
        {
            get
            {
                int lHeight = LChild == null ? 0 : LChild.Height;
                int rHeight = RChild == null ? 0 : RChild.Height;
                return rHeight - lHeight;
            }
        }
    }
}
