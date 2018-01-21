using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class AVLTree : BinaryTree
    {
        public new void Insert(int key)
        {
            Node n = new Node(key);
            base.Insert(n);
            RecalculateHeightsAndBalances(n);
        }

        public new void Delete(int key)
        {
            Node n = Search(key);
            Delete(n);
        }
        public new void Delete(Node n)
        {
            Node a = n.Parent;
            base.Delete(n);
            if (n.ChildrenCount > 1)
            {
                Node current = n.LChild;
                while (current.RChild != null)
                {
                    current = current.RChild;
                }
                a = current;
            }
            
            
            RecalculateHeightsAndBalances(a);
        }

        public new void Insert(Node n)
        {
            base.Insert(n);
            RecalculateHeightsAndBalances(n);
        }


        public void RecalculateHeightsAndBalances(Node start)
        {
            

            if (start.Balance * start.Balance > 1)
            {
                Rebalance(start);
            }
            if (start.Parent == null)
            {
                return;
            }
            RecalculateHeightsAndBalances(start.Parent);
        }

        public void Rebalance(Node n)
        {
            if (n.Balance < -1)
            {
                if(n.LChild.Balance > 0)
                {
                    LeftRotate(n.LChild);
                    RightRotate(n);
                    return;
                }
                RightRotate(n);

            }
            else if (n.Balance > 1)
            {
                if(n.RChild.Balance < 0)
                {
                    RightRotate(n.RChild);
                    LeftRotate(n);
                    return;
                }
                LeftRotate(n);
            }
        }

        public void RightRotate(Node n)
        {
            if (n.Parent == null)
            {
                Root = n.LChild;
                n.LChild.Parent = null;

            }
            else
            {
                n.LChild.Parent = n.Parent;
                if (n == n.Parent.LChild)
                {
                    n.Parent.LChild = n.LChild;
                }
                else
                {
                    n.Parent.RChild = n.LChild;
                }
            }
            n.Parent = n.LChild;
            Node toBeLChild = n.Parent.RChild;
            n.Parent.RChild = n;
            n.LChild = toBeLChild;
        }

        public void LeftRotate(Node n)
        {
            if (n.Parent == null)
            {
                Root = n.RChild;
                n.RChild.Parent = null;

            }
            else
            {
                n.RChild.Parent = n.Parent;
                if (n == n.Parent.LChild)
                {
                    n.Parent.LChild = n.RChild;
                }
                else
                {
                    n.Parent.RChild = n.RChild;
                }
            }
            n.Parent = n.RChild;
            Node toBeRChild = n.Parent.LChild;
            n.Parent.LChild = n;
            n.RChild = toBeRChild;
        }

    }
}
