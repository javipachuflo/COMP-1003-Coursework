using System;
using System.Runtime.InteropServices;   // Don't use anything else than System and only use C-core functionality; read the specs!

/// <summary>
/// Implement a binary search tree 
/// 
/// Notes
/// 1) Don't rename any of the method names in this file or change their arguments or return types or their order in the file.
/// 2) If you want to add methods do this in the space indicated at the top of the Program.
/// 3) You can add fields to the structures Tree, Node, DataEntry, if you find this necessary or useful.
/// 4) Some of the method stubs have return statements that you may need to change (the code wouldn't run without return statements).
/// 
///    You can ignore most warnings - many of them result from requirements of Object-Orientated Programming or other constraints
///    unimportant for COMP1003.
///    
/// </summary>



/// <summary>
/// Declare what sort of data we store in the tree.
/// 
/// We use simple integers for convenience, but this could be anything sortable in general.
/// </summary>
class DataEntry
{
    public int data;
}


/// <summary>
/// A single node in the tree;
/// </summary>
class Node
{
    public DataEntry data;
    public Node right;
    public Node left;
}


/// <summary>
/// The top-level tree structure
/// </summary>
class Tree
{
    public Node root;
}



class Program
{

    /// THIS LINE: If you want to add methods add them between THIS LINE and THAT LINE


    /// Your methods go here  .... (and nowhere else)
    /// 

    /// <summary> 
    ///
    /// Search for a node by comparing values
    ///
    /// </summary>
    static Node SearchTreeItemReturn_item(Node tree, Node item)
    {
        //  Fill in proper code 

        if (IsEqual(tree, item))
        {
            return item;

        }
        else if (item.data.data < tree.data.data)
        {
            return SearchTreeItemReturn_item(tree.left, item);

        }
        else if (item.data.data > tree.data.data)
        {
            return SearchTreeItemReturn_item(tree.right, item);

        }
        else
        {
            return null;
        }
    }

    static Node SearchTreeItem_ReturnItem_StoreParent(Node this_node, Node item_to_find, Node parent)
    {
        //  Fill in proper code 

        if (this_node == null)
        {
            return null;
        }

        if (IsEqual(this_node, item_to_find))
        {
            return parent;

        }

        if (item_to_find.data.data < this_node.data.data)
        {
            return SearchTreeItem_ReturnItem_StoreParent(this_node.left, item_to_find, this_node);

        }
        else if (item_to_find.data.data > this_node.data.data)
        {
            return SearchTreeItem_ReturnItem_StoreParent(this_node.right, item_to_find, this_node);

        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// Will count the amount of nodes in root node's tree
    /// </summary>
    /// <param name="tree">root node of the tree you want to count</param>
    /// <returns>count of Nodes in root node's tree</returns>
    static int CountNodes(Node tree)
    {
        if (tree == null)
            return 0;

        // Count this node + left subtree + right subtree
        return 1 + CountNodes(tree.left) + CountNodes(tree.right);
    }

    /// THAT LINE: If you want to add methods add them between THIS LINE and THAT LINE



    /// <summary>
    /// Recursively traverse a tree depth-first printing data in in-fix order.
    /// 
    /// Note that we expect the root Node as argument, not a Tree structure.
    /// Otherwise we would need an auxiliary function as we do recursion over Nodes.
    /// 
    /// In fact, the method below can print any non-empty sub-tree.
    /// 
    /// </summary>
    /// <param name="subtree">The *root node* of the tree to traverse and print</param>
    static void PrintTree(Node tree)
    {
        if (tree.left != null)
            PrintTree(tree.left);

        Console.Write(tree.data.data + "  ");

        if (tree.right != null)
            PrintTree(tree.right);
    }


    /// <summary>
    /// Compare whether the data in one Node is smaller than data in another Node. 
    /// 
    /// The data held in Nodes could be different from integers, but it must be sortable.
    /// This function/method defines when the data in Node item1 is smaller than in item2.
    /// As we assume Integers for convenience, the comparison is just the usual "smaller than".
    /// </summary>
    /// <param name="item1">First Node</param>
    /// <param name="item2">Second Node</param>
    /// <returns>True if the data in item1 is smaller than the data in item2, and false otherwise.</returns>
    static bool IsSmaller(Node item1, Node item2)
    {
        return item1.data.data < item2.data.data;
    }


    /// <summary>
    /// Predicate that checks if two Nodes hold the same value. 
    /// 
    /// As we assume Integers for convenience, the comparison is just the usual "equality" on integers.
    /// Equality could be more complicated for other sorts of data.
    /// </summary>
    /// <param name="item1">First Node</param>
    /// <param name="item2">Second Node</param>
    /// <returns>True if two Nodes have the same value, false otherwise.</returns>
    static bool IsEqual(Node item1, Node item2)
    {
        if (item1.data.data == item2.data.data)
        {
            return true;
        }
        else
        {
            return false; // you can replace this statement; it is here because the stub code wouldn't run without it
        }

    }


    /// <summary>
    /// Insert a Node into a Tree
    /// 
    /// Note that the root node has to be provided, not the Tree reference, because we do recursion over the Nodes.
    /// The function makes use of IsSmaller and would work for other sorts of data than Integers.
    /// </summary>
    /// <param name="tree">The *root node* of the tree</param>
    /// <param name="item">The item to insert</param>
    static void InsertItem(ref Node tree, Node item)
    {
        if (tree == null)                           // if tree Node is empty, make item the tree's Node
        {
            tree = item;
            return;
        }

        if (IsSmaller(item, tree))                  // if item data is smaller than tree's data
        {
            InsertItem(ref tree.left, item);        //     recursively insert into the left subtree
        }
        else if (IsSmaller(tree, item))             // if item data is larger than tree's data
        {
            InsertItem(ref tree.right, item);       //     recursively insert into the right subtree
        }

        // otherwise the item data is already in the tree and we discard it 
    }


    /// <summary>
    /// Insert a Node into a Tree
    /// 
    /// This is an auxiliary function that expects a Tree structure, in contrast to the previous method. 
    /// It always inserts on the toplevel and is not recursive. It's just a wrapper.
    /// </summary>
    /// <param name="tree">The Tree (not a Node as in InsertItem())</param>
    /// <param name="item">The Node to insert</param>
    static void InsertTree(Tree tree, Node item)
    {
        InsertItem(ref tree.root, item);
    }


    /// <summary>
    /// Find a value in a tree.
    /// 
    /// This requires the IsEqual() predicate defined above for general data.
    /// </summary>
    /// <param name="tree">The root node of the Tree.</param>
    /// <param name="value">The Data to find</param>
    /// <returns>True if the value is found and false otherwise.</returns>
    static bool SearchTree(Node tree, DataEntry value)
    {
        //  Fill in proper code 

        //check if anything is null, if yes return false, if not, continue
        //is the value of the node inputted the same as the value of the node we want
        //if yes, found
        //if not, if the value of the current node is bigger than the desired value, go left, if it's smaller, go right.

        if (tree == null || tree.data == null || value == null)
        {
            return false;
        }

        if (tree.data.data == value.data)
        {
            return true;

        }
        else if (value.data < tree.data.data)
        {
            return SearchTree(tree.left, value);

        }
        else if (value.data > tree.data.data)
        {
            return SearchTree(tree.right, value);

        }
        else
        {
            return false;
        }

    }


    /// <summary>
    /// Find a Node in a tree
    /// 
    /// This compares Node references not data values.
    /// </summary>
    /// <param name="tree">The root node of the tree.</param>
    /// <param name="item">The Node (reference) to be found.</param>
    /// <returns>True if the Node is found, false otherwise.</returns>
    static bool SearchTreeItem(Node tree, Node item)
    {
        //  Fill in proper code 

        if (IsEqual(tree, item))
        {
            return true;

        }
        else if (item.data.data < tree.data.data)
        {
            return SearchTreeItem(tree.left, item);

        }
        else if (item.data.data > tree.data.data)
        {
            return SearchTreeItem(tree.right, item);

        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Delete a Node from a tree
    /// </summary>
    /// <param name="tree">The root of the tree</param>
    /// <param name="item">The Node to remove</param>
    static void DeleteItem(Tree tree, Node item)
    {
        //  Fill in proper code 

        //access the root, find the node through the value

        Node foundItem = SearchTreeItemReturn_item(tree.root, item); // "CTRL + F12" to see function quickly, then "CTRL + -"(minus) to go back
        foundItem = null;
    }


    /// <summary>
    /// Returns how many elements are in a Tree
    /// </summary>
    /// <param name="tree">The Tree.</param>
    /// <returns>The number of items in the tree.</returns>
    static int Size(Tree tree)
    {
        //  Fill in proper code 

        // get root node of the tree, then search it as count how many

        return CountNodes(tree.root); // "CTRL + F12" to see function quickly, then "CTRL + -"(minus) to go back
    }


    /// <summary>
    /// Returns the depth of a tree with root "tree"
    /// 
    /// Note that this function should work for any non-empty subtree
    /// </summary>
    /// <param name="tree">The root of the tree</param>
    /// <returns>The depth of the tree.</returns>
    static int Depth(Node tree)
    {
        if (tree == null)
        {
            return 0;

        }

        int leftDepth = Depth(tree.left);
        int rightDepth = Depth(tree.right);

        return 1 + Math.Max(leftDepth, rightDepth);

    }


    /// <summary>
    /// Find the parent of Node node in Tree tree.
    /// </summary>
    /// <param name="tree">The Tree</param>
    /// <param name="node">The Node</param>
    /// <returns>The parent of node in the tree, or null if node has no parent.</returns>
    static Node Parent(Tree tree, Node node)
    {
        // first, search for the node
        // meanwhile, while searcing for the node, pass the previous node as a parameter, so it is still accessible
        // once node found, return the parameter node

        return SearchTreeItem_ReturnItem_StoreParent(tree.root, node, null); // "CTRL + F12" to see function quickly, then "CTRL + -"(minus) to go back

    }

    /// <summary>
    /// Find the Node with maximum value in a (sub-)tree, given the IsSmaller predicate.
    /// </summary>
    /// <param name="tree">The root node of the tree to search.</param>
    /// <returns>The Node that contains the largest value in the sub-tree provided.</returns>
    static Node FindMax(Node tree)
    {
        // check root node value and store it as max_value
        // check next values, if one of the values is bigger than previous value, then this value becomes max_value

        if (tree == null)
        {
            return null;
        }

        Node max_value = tree;

        Node max_left = FindMax(tree.left);
        Node max_right = FindMax(tree.right);

        if (max_left != null && IsSmaller(max_value, max_left))
        {
            max_value = max_left;
        }
        
        if (max_right != null && IsSmaller(max_value, max_right))
        {
            max_value = max_right;
        }

        return max_value;
    }

    static Node FindMin(Node tree)
    {
        if (tree == null)
        {
            return null;
        }

        Node min_value = tree;

        Node min_left = FindMin(tree.left);
        Node min_right = FindMin(tree.right);

        if (min_left != null && IsSmaller(min_left, min_value))
        {
            min_value = min_left;
        }

        if (min_right != null && IsSmaller(min_right, min_value))
        {
            min_value = min_right;
        }

        return min_value;
    }

    /// <summary>
    /// Delete the Node with the smallest value from the Tree. 
    /// </summary>
    /// <param name="tree">The Tree to process.</param>
    static void DeleteMin(Tree tree)
    {
        Node min_value = FindMin(tree.root);
        min_value = null;
    }


    /// SET FUNCTIONS 


    /// <summary>
    /// Merge the items of one tree with another one.
    /// Note that duplicate data entries are prohibited.
    /// </summary>
    /// <param name="tree1">A tree</param>
    /// <param name="tree2">Another tree</param>
    /// <returns>A new tree with all the values from tree1 and tree2.</returns>
    static Tree Union(Tree tree1, Tree tree2)
    {
        return null;
    }


    /// <summary>
    /// Find all values that are in tree1 AND in tree2 and copy them into a new Tree.
    /// </summary>
    /// <param name="tree1">The first Tree</param>
    /// <param name="tree2">The second Tree</param>
    /// <returns>A new Tree with all values in tree1 and tree2.</returns>
    static Tree Intersection(Tree tree1, Tree tree2)
    {
        return null;
    }


    /// <summary>
    /// Compute the set difference of the values of two Trees (interpreted as Sets).
    /// </summary>
    /// <param name="tree1">Tree one</param>
    /// <param name="tree2">Tree two</param>
    /// <returns>The values of the set difference tree1/tree2 in a new Tree.</returns>
    static Tree Difference(Tree tree1, Node tree2)
    {
        return null;
    }


    /// <summary>
    /// Compute the symmetric difference of the values of two Trees (interpreted as Sets).
    /// </summary>
    /// <param name="tree1">Tree one</param>
    /// <param name="tree2">Tree two</param>
    /// <returns>The values of the symmetric difference tree1/tree2 in a new Tree.</returns>
    static Tree SymmetricDifference(Node tree1, Tree tree2)
    {
        return null;
    }



    /*  
     *  TESTING 
     */


    /// <summary>
    /// Testing of the Tree methods that does some reasonable checks.
    /// It does not have to be exhaustive but sufficient to suggest the code is correct.
    /// </summary>
    static void TreeTests()  // some tests
    {
        Tree tree = new Tree();
        Random r = new Random();
        DataEntry data;


        // Build a tree inserting 10 random values as data

        Console.WriteLine("Build a tree inserting 10 random values as data");

        for (int i = 1; i <= 10; i++)
        {
            data = new DataEntry();
            data.data = r.Next(10);

            Node current = new Node();
            current.left = null;
            current.right = null;
            current.data = data;

            InsertItem(ref tree.root, current);
            // InsertTree(tree, current);
        }

        // print out the (ordered!) tree

        Console.WriteLine("Print out the (ordered!) tree");
        PrintTree(tree.root);
        Console.WriteLine();


        // test SearchTree

        Console.WriteLine("Search for 10 random values");

        data = new DataEntry();
        for (int i = 0; i < 10; i++)
        {
            data.data = r.Next(10);       // vvvv this is ugly ... improve it! vvvvv 
            Console.WriteLine(data.data + " was" + (!SearchTree(tree.root, data) ? " NOT" : "") + " found");
        }



        //  Add more tree testing here .... 



    }


    /// <summary>
    /// Testing of the Set methods that does some reasonable checks.
    /// It does not have to be exhaustive but sufficient to suggest the code is correct.
    /// </summary>
    static void SetTests()
    {

        //   Tests for the Set methods

    }



    /// <summary>
    /// The Main entry point into the code. Don't change anythhing here. 
    /// </summary>
    static void Main()
    {
        TreeTests();

        SetTests();
    }

}

