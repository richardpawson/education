using System;
using System.Collections.Generic;
using System.Linq;

    public class BinarySearchTree
    {
        private Node Root = null;

        public bool IsEmpty()
    {
        throw new NotImplementedException();
    }

        public void Add(string value)
        {

        }

        public void Remove(string value)
        {

        }

        //If value is not in tree: returns null
        private Node FindNode(string value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string value)
        {
            return FindNode(value) != null;
        }

        //Returns a List of the string values in the tree, as traversed.
        //Follow 'left to right' convention
        public List<string> TraverseBreadthFirst()
        {
            throw new NotImplementedException();
        }

        public List<string> TraverseDepthFirstPreOrder()
        {
            throw new NotImplementedException();
        }

        public List<string> TraverseDepthFirstInOrder()
        {
            throw new NotImplementedException();
        }

        public List<string> TraverseDepthFirstPostOrder()
        {
            throw new NotImplementedException();
        }
    }
