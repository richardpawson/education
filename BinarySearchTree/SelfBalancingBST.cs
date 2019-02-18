using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SelfBalancingBST 
{
    protected string Root { get; set; }  //Initially hard-wired to string type

    protected SelfBalancingBST LeftChild { get; set; }

    protected SelfBalancingBST RightChild { get; set; }

    public int Depth { get; protected set; }

    public SelfBalancingBST(string root) //Constructor
    {
        Root = root;
        Depth = 1;
    }

    public SelfBalancingBST(string root, SelfBalancingBST left, SelfBalancingBST right) : this(root)
    {
        LeftChild = left;
        RightChild = right;
        CalculateDepth();
    }

    private void CalculateDepth()
    {
        Depth = 1 + Math.Max(LeftChild is null ? 0 : LeftChild.Depth, RightChild is null ? 0 : RightChild.Depth);
    }

    public override string ToString() //Helps with debugging to see the root value
    {
        return Root;
    }

    public string Summary(int indent = 0)
    {
        string s = Root + "\n";
        var sb = new StringBuilder(indent + 1);
        for (int i = 0; i <= indent; i++)
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

    public virtual void Add(string newValue)
    {
        if (newValue is null) return;  //Don't add null values
        if (newValue.CompareTo(Root) >= 0)
        {
             AddToRightChild(newValue);
        }
        else
        {
            AddToLeftChild(newValue);
        }
        CalculateDepth();
        RebalanceIfNecessary();
    }

    private void AddToLeftChild(string newValue)
    {
        if (LeftChild is null)
        {
            LeftChild = new SelfBalancingBST(newValue);
            if (RightChild is null) Depth += 1;
        }
        else
        {
            LeftChild.Add(newValue);
        }
    }

    private void AddToRightChild(string newValue)
    {
        if (RightChild is null)
        {
            RightChild = new SelfBalancingBST(newValue);
            if (LeftChild is null) Depth += 1;
        }
        else
        {
            RightChild.Add(newValue);
        }
    }

    #region Traverse
    //Returns a List of the string values in the tree, as traversed.
    //Follow 'left to right' convention
    public List<string> TraverseBreadthFirst()
    {
        var visited = new List<string>();
        var queue = new Queue<SelfBalancingBST>();
        queue.Enqueue(this);
        SelfBalancingBST visiting = null;
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
            if (LeftChild.Root is null)
            {
                LeftChild = null;
            }
        }
        else if (RightChild != null && RightChild.Contains(value))
        {
            RightChild.Remove(value);
            if (RightChild.Root is null)
            {
                RightChild = null;
            }
        }
        CalculateDepth();
        RebalanceIfNecessary();
    }

    private void PushAllChildrenOntoStack(Stack<string> stack, SelfBalancingBST tree)
    {
        if (tree != null)
        {
            stack.Push(tree.Root);
            PushAllChildrenOntoStack(stack, tree.LeftChild);
            PushAllChildrenOntoStack(stack, tree.RightChild);
        }
    }
    #endregion


    #region Re-balancing
    public int Balance()
    {
        return (RightChild is null ? 0 : RightChild.Depth) - (LeftChild is null ? 0 : LeftChild.Depth);
    }

    //Returns true if did rebalance
    private void RebalanceIfNecessary()
    {
        if (Balance() < -1)
        {
            RebalanceLeftHeavy();
        }
        else if (Balance() > 1)
        {
            RebalanceRightHeavy();
        }
    }

    private void RebalanceRightHeavy()
    {
        if (RightChild.Balance() < 0)
        {
            RightChild.RotateRight();
        }
        RotateLeft();
    }

    private void RebalanceLeftHeavy()
    {
        if (LeftChild.Balance() > 0)
        {
            LeftChild.RotateLeft();
        }
        RotateRight();
    }

    private void RotateRight()
    {
        RightChild = new SelfBalancingBST(Root, LeftChild.RightChild, RightChild);
        Root = LeftChild.Root;
        LeftChild = LeftChild.LeftChild;
        CalculateDepth();
    }

    private void RotateLeft()
    {
        LeftChild = new SelfBalancingBST(Root, LeftChild, RightChild.LeftChild);
        Root = RightChild.Root;
        RightChild = RightChild.RightChild;
        CalculateDepth();
    }
    #endregion
}
