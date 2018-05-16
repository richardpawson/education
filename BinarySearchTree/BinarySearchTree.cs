using System;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree
{

    public BinarySearchTree(string rootValue) //Costructor
    {
        throw new NotImplementedException();
    }

    public bool Contains(string soughtValue)
    {
        throw new NotImplementedException();
    }

    public void Add(string newValue)
    {
        throw new NotImplementedException();
    }

    #region Traverse
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
    #endregion

    #region Remove
    public void Remove(string value)
    {
        throw new NotImplementedException();
    }

    private void PushAllChildrenOntoStack(Stack<string> stack, BinarySearchTree tree)
    {
        throw new NotImplementedException();
    }
    #endregion
}
