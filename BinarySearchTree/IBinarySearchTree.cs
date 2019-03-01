using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IBinarySearchTree<T> where T: IComparable
{

     string Summary(int indent = 0);

    bool Contains(T soughtValue);

    void Add(T newValue);

    #region Traverse
    //Returns a List of the string values in the tree, as traversed.
    //Follow 'left to right' convention
     List<string> TraverseBreadthFirst();

     List<string> TraverseDepthFirstPreOrder();

     List<string> TraverseDepthFirstInOrder();

    List<string> TraverseDepthFirstPostOrder();
    #endregion

    void Remove(T value);
}
