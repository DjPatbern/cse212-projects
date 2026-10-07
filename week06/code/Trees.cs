public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();

        InsertMiddle(
            sortedNumbers,
            0,
            sortedNumbers.Length - 1,
            bst
        );

        return bst;
    }

    private static void InsertMiddle(
        int[] sortedNumbers,
        int first,
        int last,
        BinarySearchTree bst)
    {
        // Base case:
        // There are no values left in this range.
        if (first > last)
        {
            return;
        }

        // Find the middle index.
        int middle = (first + last) / 2;

        // Insert the middle value first.
        bst.Insert(sortedNumbers[middle]);

        // Recursively insert the middle values
        // from the left half.
        InsertMiddle(
            sortedNumbers,
            first,
            middle - 1,
            bst
        );

        // Recursively insert the middle values
        // from the right half.
        InsertMiddle(
            sortedNumbers,
            middle + 1,
            last,
            bst
        );
    }
}