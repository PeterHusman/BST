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
            Node n = new Node(key);
            base.Delete(n);
            RecalculateHeightsAndBalances(n);
        }

        public new void Insert(Node n)
        {
            base.Insert(n);
            RecalculateHeightsAndBalances(n);
        }


        public void RecalculateHeightsAndBalances(Node start)
        {
            if (start.Parent == null)
            {
                return;
            }
             
            if(start.Balance * start.Balance > 1)
            {
                Rebalance(start);
            }
            RecalculateHeightsAndBalances(start.Parent);
        }

        public void Rebalance(Node n)
        {
            if(n.Balance < -1)
            {
                n.LChild.Parent = n.Parent;
                n.Parent = n.LChild;
                Node toBeLChild = n.LChild.RChild;
                n.LChild.RChild = n;
                n.LChild = toBeLChild;

            }
            else if(n.Balance > 1)
            {
                n.RChild.Parent = n.Parent;
                n.Parent = n.RChild;
                Node toBeRChild = n.RChild.LChild;
                n.RChild.LChild = n;
                n.RChild = toBeRChild;
            }
        }

    }
}
