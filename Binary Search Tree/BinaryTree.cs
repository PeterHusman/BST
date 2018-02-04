using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        public BinaryTree()
        {
            Root = null;
        }

        public bool IsValid()
        {
            return isValid(root);
        }

        public Node InvalidNode()
        {
            return invalidNode(Root);
        }

        private Node invalidNode(Node start)
        {
            if (start.RChild != null)
            {
                if (start.RChild.Key < start.Key)
                {
                    return start.RChild;
                }
                return invalidNode(start.RChild);
            }
            if (start.LChild != null)
            {
                if (start.LChild.Key > start.Key)
                {
                    return start.LChild;
                }
                return invalidNode(start.LChild);

            }

            return null;

        }

        private bool isValid(Node start)
        {

            if (start.RChild != null)
            {
                if (start.RChild.Key < start.Key || !isValid(start.RChild))
                {
                    return false;
                }
            }
            if(start.LChild != null)
            {
                if(start.LChild.Key > start.Key || !isValid(start.LChild))
                {
                    return false;
                }
                
            }

            return true;
        }


        public Node Search(int key)
        {
            if (IsEmpty())
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
                else if (key > current.Key)
                {
                    if (current.RChild == null)
                    {
                        return null;
                    }
                    current = current.RChild;
                }
                else if (key == current.Key)
                {
                    return current;
                }
            }
            return null;
        }

        public void Insert(Node n)
        {
            if (IsEmpty())
            {
                Root = n;
                Root.Parent = null;
                return;
            }
            Node current = Root;
            while (true)
            {
                if (n.Key < current.Key)
                {
                    if (current.LChild == null)
                    {
                        current.LChild = n;
                        n.Parent = current;
                        return;
                    }
                    current = current.LChild;
                }
                else if (n.Key > current.Key)
                {
                    if (current.RChild == null)
                    {
                        current.RChild = n;
                        n.Parent = current;
                        return;
                    }
                    current = current.RChild;
                }
                else
                {
                    throw new Exception("Cannot insert duplicate values into a tree.");
                }
            }

        }

        public void Insert(int key)
        {
            Insert(new Node(key));
        }

        public void Delete(Node n)
        {
            if (IsEmpty())
            {
                return;
            }
            bool isRoot = n == Root;
            
            bool isLeft = false;
            if (!isRoot && n.Parent.LChild == n)
            {
                isLeft = true;
            }
            if (n.ChildrenCount == 0)
            {
                if(isRoot)
                {
                    Root = null;
                    return;
                }
                if (isLeft)
                {
                    n.Parent.LChild = null;
                }
                else
                {
                    n.Parent.RChild = null;
                }
                return;
            }
            if (n.ChildrenCount == 1)
            {
                Node child = n.LChild == null ? n.RChild : n.LChild;
                if(isRoot)
                {
                    Root = child;
                    Root.Parent = null;
                    return;
                }
                child.Parent = n.Parent;
                if (isLeft)
                {
                    n.Parent.LChild = child;
                }
                else
                {
                    n.Parent.RChild = child;
                }
                return;
            }
            if(n.ChildrenCount > 1)
            {
                Node current = n.LChild;
                while(current.RChild != null)
                {
                    current = current.RChild;
                }
                if(isRoot)
                {
                    Root.Key = current.Key;
                    
                }
                else if (isLeft)
                {
                    n.Parent.LChild.Key = current.Key;
                }
                else
                {
                    n.Parent.RChild.Key = current.Key;
                }
                bool isRight = current.Parent.RChild == current;
                if (current.LChild != null)
                {
                    current.LChild.Parent = current.Parent;
                    if (isRight)
                    {
                        current.Parent.RChild = current.LChild;
                    }
                    else
                    {
                        current.Parent.LChild = current.LChild;
                    }


                }
                else
                {
                    if (isRight)
                    {
                        current.Parent.RChild = null;
                    }
                    else
                    {
                        current.Parent.LChild = null;
                    }
                }
                return;
            }

        }



        public void Delete(int key)
        {
            if (IsEmpty())
            {
                return;
            }
            Delete(Search(key));

        }

        

        public bool IsEmpty()
        {
            return Root == null;
        }


        private Node root;
        public Node Root
        {
            get
            {
                return root;
            }
            protected set
            {
                root = value;
            }
        }

    }
}
