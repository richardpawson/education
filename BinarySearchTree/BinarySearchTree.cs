using System;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree
{
    private string RootValue { get; set; }

    private BinarySearchTree LeftChild { get; set; }

    private BinarySearchTree RightChild { get; set; }

    public BinarySearchTree(string rootValue) //Costructor
    {
        RootValue = rootValue;
    }

    public override string ToString() //Helps with debugging to see the root value
    {
        return RootValue;
    }

    public bool Contains(string soughtValue)
    {
        return RootValue == soughtValue || 
               (LeftChild != null && LeftChild.Contains(soughtValue)) ||
               (RightChild != null && RightChild.Contains(soughtValue));
    }

    public void Add(string newValue)
    {
        if (newValue.CompareTo(RootValue) >= 0)
        {
            if (RightChild is null)
            {
                RightChild = new BinarySearchTree(newValue);
            }
            else
            {
                RightChild.Add(newValue);
            }
        }
        else
        {
            if (LeftChild is null)
            {
                LeftChild = new BinarySearchTree(newValue);
            }
            else
            {
                LeftChild.Add(newValue);
            }
        }
    }

    #region Traverse
    //Returns a List of the string values in the tree, as traversed.
    //Follow 'left to right' convention
    public List<string> TraverseBreadthFirst()
    {
        var visited = new List<string>();
        var queue = new Queue<BinarySearchTree>();
        queue.Enqueue(this);
        BinarySearchTree visiting = null;
        while (queue.Count > 0)
        {
            visiting = queue.Dequeue();
            visited.Add(visiting.RootValue);
            if (visiting.LeftChild != null) queue.Enqueue(visiting.LeftChild);
            if (visiting.RightChild != null) queue.Enqueue(visiting.RightChild);
        }
        return visited;
    }

    public List<string> TraverseDepthFirstPreOrder()
    {
        var visited = new List<string>();
        visited.Add(RootValue);
        if (LeftChild != null)
        {
            visited.AddRange(LeftChild.TraverseDepthFirstPreOrder());
        }
        if (RightChild != null)
        {
            visited.AddRange(RightChild.TraverseDepthFirstPreOrder());
        }
        return visited;
    }

    public List<string> TraverseDepthFirstInOrder()
    {
        var visited = new List<string>();
        if (LeftChild != null)
        {
            visited.AddRange(LeftChild.TraverseDepthFirstInOrder());
        }
        visited.Add(RootValue);
        if (RightChild != null)
        {
            visited.AddRange(RightChild.TraverseDepthFirstInOrder());
        }
        return visited;
    }

    public List<string> TraverseDepthFirstPostOrder()
    {
        var visited = new List<string>();
        if (LeftChild != null)
        {
            visited.AddRange(LeftChild.TraverseDepthFirstPostOrder());
        }
        if (RightChild != null)
        {
            visited.AddRange(RightChild.TraverseDepthFirstPostOrder());
        }
        visited.Add(RootValue);
        return visited;
    }
#endregion

    #region Remove
    public void Remove(string value)
    {
        if (RootValue == value)
        {
            RootValue = null;
            var stack = new Stack<string>();
            PushAllChildrenOntoStack(stack, LeftChild);
            LeftChild = null;
            PushAllChildrenOntoStack(stack, RightChild);
            RightChild = null;
            if (stack.Count > 0)
            {
                RootValue = stack.Pop();
            }
            while (stack.Count > 0)
            {
                Add(stack.Pop());
            }
        }
        else if (LeftChild != null && LeftChild.Contains(value))
        {
            LeftChild.Remove(value);
        }
        else if (RightChild != null && RightChild.Contains(value))
        {
            RightChild.Remove(value);
        }
    }

    private void PushAllChildrenOntoStack(Stack<string> stack, BinarySearchTree tree)
    {
        if (tree != null)
        {
            stack.Push(tree.RootValue);
            PushAllChildrenOntoStack(stack, tree.LeftChild);
            PushAllChildrenOntoStack(stack, tree.RightChild);
        }
    }
    #endregion
}
