using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class RBTree : BinaryTree
    {
        public new void Insert(int key)
        {
            if (IsEmpty())
            {
                Root = new Node(key);
                Root.Red = false;
                return;
            }
            insert(Root, key);
            Root.Red = false;
        }

        public new void Insert(Node n)
        {
            Insert(n.Key);
        }

        private void insert(Node current, int key)
        {
            //as we move down the tree

            if(current.RChild.Red && current.LChild.Red)
            {
                FlipColor(current);
            }

            Node nextCurrent;
            if (key > current.Key)
            {
                nextCurrent = current.RChild;
                if (nextCurrent == null)
                {
                    current.RChild = new Node(key);
                    return;
                }
            }
            else if (key < current.Key)
            {
                nextCurrent = current.LChild;
                if (nextCurrent == null)
                {
                    current.LChild = new Node(key);
                    return;
                }
            }
            else
            {
                throw new Exception("Cannot insert duplicate values into a tree.");
            }
            insert(nextCurrent, key);

            //as we move back up the tree

            //if right is red, rotate left
            if(current.RChild.Red)
            {
                LeftRotate(current);
            }


            //if there is a red chain on the left (node.Left.IsRed && node.Left.Left.IsRed), rotate right
            if(current.LChild.Red&&current.LChild.LChild.Red)
            {
                RightRotate(current);
            }


            //rotates: new parent.Color = oldParent.Color
                //oldParent.Color = red;

        }

        private void FlipColor(Node n)
        {
            n.RChild.Red = !n.RChild.Red;
            n.LChild.Red = !n.LChild.Red;
            n.Red = !n.Red;
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
                if (n.LChild.Balance > 0)
                {
                    LeftRotate(n.LChild);
                    RightRotate(n);
                    return;
                }
                RightRotate(n);

            }
            else if (n.Balance > 1)
            {
                if (n.RChild.Balance < 0)
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
