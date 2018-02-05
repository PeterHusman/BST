using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            RBTree tree = new RBTree();
            

            while (true)
            {
                string s = Console.ReadLine();
                if (s[0] == 'i')
                {
                    s = s.Remove(0, 1);
                    tree.Insert(int.Parse(s));
                }
                else if (s[0] == 'd')
                {
                    s = s.Remove(0, 1);
                    tree.Delete(int.Parse(s));
                }
                else if (s[0] == 's')
                {
                    s = s.Remove(0, 1);
                    tree.Search(int.Parse(s));
                }
                Render(tree);


            }
        }

        public static void Render(BinaryTree tree)
        {
            Console.Clear();
            RenderNode(tree.Root);
        }

        public static void RenderNode(Node n, int x = 20, int y = 0, int xDiff = 10)
        {
            if (n == null)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            if (n.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(n.Key);
            if (n.LChild != null)
            {
                RenderNode(n.LChild, x - xDiff, y + 1, (int)Math.Ceiling(xDiff/2f));
            }
            if (n.RChild != null)
            {
                RenderNode(n.RChild, x + xDiff, y + 1, (int)Math.Ceiling(xDiff / 2f));
            }
            return;
        }
    }
}
