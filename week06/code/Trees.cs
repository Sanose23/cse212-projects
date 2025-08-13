public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider.  For the first call, the full range of 0 to
    /// Length-1 used.
    /// </summary>
public static BinarySearchTree CreateTreeFromSortedList(int[] sorted)
{
    BinarySearchTree tree = new();
    BuildBalanced(tree, sorted, 0, sorted.Length - 1);
    return tree;
}

private static void BuildBalanced(BinarySearchTree tree, int[] arr, int start, int end)
{
    if (start > end) return;

    int mid = (start + end) / 2;
    tree.Insert(arr[mid]);
    BuildBalanced(tree, arr, start, mid - 1);
    BuildBalanced(tree, arr, mid + 1, end);
}

}