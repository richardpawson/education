﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BinarySearchTree {
    protected string Root { get; set; }  //Initially hard-wired to string type

    protected BinarySearchTree LeftChild { get; set; }

    protected BinarySearchTree RightChild { get; set; }

    public int Depth { get; protected set; }

    public BinarySearchTree(string root) //Constructor
    {
        Root = root;
        Depth = 1;
    }

    public BinarySearchTree(string root, BinarySearchTree left, BinarySearchTree right) : this(root)
    {
        LeftChild = left;
        RightChild = right;
        Depth = 1 + Math.Max(left is null? 0 : left.Depth, right is null ? 0 : right.Depth);
    }

    public override string ToString() //Helps with debugging to see the root value
    {
        return Root;
    }

    public string Summary(int indent = 0)
    {
        string s = Root + "\n";
        var sb = new StringBuilder(indent + 1);
        for (int i = 0; i < indent; i++)
        {
            sb.Append("  ");
        }
        var spaces = sb.ToString();
        if (LeftChild != null)
        {
            s += spaces + "L:" + LeftChild.Summary(indent + 1);
        }
        if (RightChild != null)
        {
            s += spaces + "R:" + RightChild.Summary(indent + 1);
        }
        return s;
    }

    public bool Contains(string soughtValue)
    {
        return Root == soughtValue ||
               (LeftChild != null && LeftChild.Contains(soughtValue)) ||
               (RightChild != null && RightChild.Contains(soughtValue));
    }

    //Returns true if addition has increased tree depth
    public virtual bool Add(string newValue)
    {
        bool depthIncreased = false;
        if (newValue is null) return false;  //Don't add null values
        if (newValue.CompareTo(Root) >= 0)
        {
            depthIncreased |= AddToRightChild(newValue);
        }
        else
        {
            depthIncreased |= AddToLeftChild(newValue);
        }
        if (depthIncreased) Depth += 1;
        return depthIncreased;
    }

    private bool AddToLeftChild(string newValue)
    {
        if (LeftChild is null)
        {
            LeftChild = new BinarySearchTree(newValue);
            return RightChild is null;  //Depth has been increased
        }
        else
        {
            return LeftChild.Add(newValue);
        }
    }

    private bool AddToRightChild(string newValue)
    {
        if (RightChild is null)
        {
            RightChild = new BinarySearchTree(newValue);
            return LeftChild is null;  //Depth has been increased
        }
        else
        {
            return RightChild.Add(newValue);
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
            visited.Add(visiting.Root);
            if (visiting.LeftChild != null) queue.Enqueue(visiting.LeftChild);
            if (visiting.RightChild != null) queue.Enqueue(visiting.RightChild);
        }
        return visited;
    }

    public List<string> TraverseDepthFirstPreOrder()
    {
        var visited = new List<string>();
        visited.Add(Root);
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
        visited.Add(Root);
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
        visited.Add(Root);
        return visited;
    }
    #endregion

    #region Remove
    public virtual void Remove(string value)
    {
        if (Root == value)
        {
            Root = null;
            var stack = new Stack<string>();
            PushAllChildrenOntoStack(stack, LeftChild);
            LeftChild = null;
            PushAllChildrenOntoStack(stack, RightChild);
            RightChild = null;
            if (stack.Count > 0)
            {
                Root = stack.Pop();
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
            stack.Push(tree.Root);
            PushAllChildrenOntoStack(stack, tree.LeftChild);
            PushAllChildrenOntoStack(stack, tree.RightChild);
        }
    }
    #endregion
}
