using System;
using System.Collections;
using System.Collections.Generic;


namespace Generics.BinaryTrees
{
    public class BinaryTree
    {
        public static BinaryTree<T> Create<T>(params T[] inputs) where T : IComparable
        {
            var tree = new BinaryTree<T>();
            foreach (var input in inputs)
                tree.Add(input);
            return tree;
        }
    }

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        public BinaryTree<T> Head { get; set; }
        public BinaryTree<T> Left { get; private set; }
        public BinaryTree<T> Right { get; private set; }
        public T Value { get; private set; }
        private int Weight { get; set; }

        private BinaryTree(T key)
        {
            Value = key;
            Weight = 1;
        }

        public BinaryTree() { }

        public void Add(T key)
        {
            if (Weight == 0)
            {
                Weight++;
                Value = key;
                return;
            }
            Weight++;

            if (key.CompareTo(Value) <= 0)
            {
                if (Left == null)
                {
                    Left = new BinaryTree<T>(key) {Head = this};
                    return;
                }
                Left.Add(key);
                return;
            }

            if (Right == null)
            {
                Right = new BinaryTree<T>(key) {Head = this};
                return;
            }
            Right.Add(key);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            if (Weight == 0)
                yield break;

            if (Left != null)
            {
                foreach (var item in Left)
                    yield return item;
            }

            yield return Value;

            if (Right != null)
            {
                foreach (var item in Right)
                    yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}