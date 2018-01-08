using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BinaryTree
    {
        public BinaryTree()
        {
            Root = null;
        }

        public Node Search(int key)
        {
            if(IsEmpty())
            {
                return null;
            }
            Node current = Root;
            while (current != null)
            {
                if (key < current.Key)
                {
                    if (current.LChild == null)
                    {
                        return null;
                    }
                    current = current.LChild;
                }
                else if(key > current.Key)
                {
                    if (current.RChild == null)
                    {
                        return null;
                    }
                    current = current.RChild;
                }
                else if(key == current.Key)
                {
                    return current;
                }
            }
            return null;
        }

        public void Insert(Node n)
        {
            if(IsEmpty())
            {
                Root = n;
                Root.Parent = null;
                return;
            }
            Node current = Root;
            while(true)
            {
                if(n.Key < current.Key)
                {
                    if(current.LChild == null)
                    {
                        current.LChild = n;
                        return;
                    }
                    current = current.LChild;
                }
                else
                {
                    if (current.RChild == null)
                    {
                        current.RChild = n;
                        return;
                    }
                    current = current.RChild;
                }
            }
            
        }

        public void Delete(Node n)
        {
            if(IsEmpty())
            {
                return;
            }
            

        }

        public bool IsEmpty()
        {
            return Root == null;
        }

        public Node Root;

    }
}
