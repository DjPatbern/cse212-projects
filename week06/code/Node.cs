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
        // Problem 1:
        // Only insert unique values.
        // If the value equals Data, do nothing.
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
            {
                Left = new Node(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else
        {
            // Insert to the right
            if (Right is null)
            {
                Right = new Node(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
    }

    public bool Contains(int value)
    {
        // Problem 2:
        // The current node contains the value.
        if (value == Data)
        {
            return true;
        }

        // Smaller values can only be in the left subtree.
        if (value < Data)
        {
            if (Left is null)
            {
                return false;
            }

            return Left.Contains(value);
        }

        // Larger values can only be in the right subtree.
        if (Right is null)
        {
            return false;
        }

        return Right.Contains(value);
    }

    public int GetHeight()
    {
        // Problem 4:
        // A missing subtree has height 0.
        int leftHeight = 0;
        int rightHeight = 0;

        if (Left is not null)
        {
            leftHeight = Left.GetHeight();
        }

        if (Right is not null)
        {
            rightHeight = Right.GetHeight();
        }

        // Current node adds 1 to the larger subtree.
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}