using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearchTree;

namespace BinaryForest.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void InsertTest()
        {
            var tree = new BinaryTree();
            tree.Insert(3);
            tree.Insert(4);

            Assert.AreEqual(3, tree.Root.Key, $"Insert failed: Expected root to have a value of 3; instead, it has a value of {tree.Root.Key}");
            
        }

        [TestMethod]
        public void DeleteTest()
        {
            var tree = new BinaryTree();
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(1);
            tree.Insert(2);
            tree.Delete(3);
            Assert.AreEqual(2, tree.Root.Key, $"Delete failed: Expected root to have a value of 2; instead, it had a value of {tree.Root.Key}");
        }
    }
    [TestClass]
    public class AVLTreeTests
    {
        [TestMethod]
        public void LeftRotateTest()
        {
            var tree = new AVLTree();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            Assert.AreEqual(2, tree.Root.Key, $"Rebalance failed: Expected root to have a value of 2; instead, it had a value of {tree.Root.Key}");
        }

        [TestMethod]
        public void RightRotateTest()
        {
            var tree = new AVLTree();
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);
            Assert.AreEqual(2, tree.Root.Key, $"Rebalance failed: Expected root to have a value of 2; instead, it had a value of {tree.Root.Key}");
        }

        [TestMethod]
        public void DoubleLeftRotateTest()
        {
            var tree = new AVLTree();
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(2);
            Assert.AreEqual(2, tree.Root.Key, $"Rebalance failed: Expected root to have a value of 2; instead, it had a value of {tree.Root.Key}");
        }

        [TestMethod]
        public void DoubleRightRotateTest()
        {
            var tree = new AVLTree();
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(2);
            Assert.AreEqual(2, tree.Root.Key, $"Rebalance failed: Expected root to have a value of 2; instead, it had a value of {tree.Root.Key}");
        }

        [TestMethod]
        public void RebalanceTest()
        {
            var tree = new AVLTree();
            for (int i = 0; i < 100; i++)
            {
                tree.Insert(i);
                Assert.AreEqual(0, tree.Search(i).Balance, 1, $"Tree unbalanced: Node with value {i} was expected to be between -1 and 1 balance. Instead, it had a balance of {tree.Search(i).Balance}");
            }

        }

    }

    [TestClass]
    public class RBTreeTests
    {
    }
}
