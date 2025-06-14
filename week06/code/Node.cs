public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value == Data)
        {
            // Value already exists, do not insert duplicates
            return;
        }
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        {
            // TODO Start Problem 1
            if (value == Data)
            {
                // Value already exists, do not insert duplicates
                return true;
            }
            if (value < Data)
            {
                // Insert to the left
                if (Left is null)
                    return false; // Value not found in the left subtree
                else
                    return Left.Contains(value);
            }
            else
            {
                // Insert to the right
                if (Right is null)
                    return false; // Value not found in the right subtree
                else
                    return Right.Contains(value);
            }
        }

    }

    public int GetHeight()
    //Implement the GetHeight function in the Node class to get the height of the BinarySearchTree. The height of any tree (or subtree) is defined 
    //as one plus the height of either the left subtree or the right subtree (whichever one is bigger). If the tree has only the root node,
    // then this would be 1 plus the maximum height of either subtree which would be 0. Therefore, the height of a tree with only the root node is 1. You will need to use recursion to solve this problem.
    {
        // TODO Start Problem 3


        if (Left == null && Right == null)
        {
            return 1;
        }

        int leftSubtreeHeight;

        if (Left != null)
        {
            leftSubtreeHeight = Left.GetHeight();
        }
        else
        {

            leftSubtreeHeight = 0;
        }

        int rightSubtreeHeight;

        if (Right != null)
        {
            rightSubtreeHeight = Right.GetHeight();
        }
        else
        {

            rightSubtreeHeight = 0;
        }


        return 1 + Math.Max(leftSubtreeHeight, rightSubtreeHeight); // the secret of this recursive function is that it returns the height of the 
                                                                    //tree to its parent who is waiting to complete, which is 1 plus the maximum height of either subtree
    }
}

