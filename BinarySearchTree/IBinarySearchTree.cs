using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IBinarySearchTree
{

     string Summary(int indent = 0);

    bool Contains(string soughtValue);

    void Add(string newValue);

    #region Traverse
    //Returns a List of the string values in the tree, as traversed.
    //Follow 'left to right' convention
     List<string> TraverseBreadthFirst();

     List<string> TraverseDepthFirstPreOrder();

     List<string> TraverseDepthFirstInOrder();

    List<string> TraverseDepthFirstPostOrder();
    #endregion

    void Remove(string value);
}
