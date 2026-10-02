using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + ... + n^2.
    /// If n <= 0, return 0.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
        {
            return 0;
        }

        // Recursive case:
        // n^2 plus the sum of all squares before n.
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size'
    /// from 'letters' into results.
    /// </summary>
    public static void PermutationsChoose(
        List<string> results,
        string letters,
        int size,
        string word = "")
    {
        // Base case:
        // Once the word reaches the requested size,
        // we have created one complete permutation.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each available letter.
        for (int i = 0; i < letters.Length; i++)
        {
            char selectedLetter = letters[i];

            // Remove the selected letter so it cannot
            // be used again in this permutation.
            string remainingLetters =
                letters[..i] + letters[(i + 1)..];

            PermutationsChoose(
                results,
                remainingLetters,
                size,
                word + selectedLetter
            );
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb s stairs
    /// using steps of size 1, 2, or 3.
    /// </summary>
    public static decimal CountWaysToClimb(
        int s,
        Dictionary<int, decimal>? remember = null)
    {
        // Base cases
        if (s == 0)
            return 0;

        if (s == 1)
            return 1;

        if (s == 2)
            return 2;

        if (s == 3)
            return 4;

        // Create the memoization dictionary the first
        // time the function is called.
        remember ??= new Dictionary<int, decimal>();

        // If this problem was already solved, use
        // the stored answer instead of calculating it again.
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve the smaller problems recursively.
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Remember the result for future recursive calls.
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Replace each wildcard with every possible
    /// combination of 0 and 1.
    /// </summary>
    public static void WildcardBinary(
        string pattern,
        List<string> results)
    {
        // Find the first wildcard.
        int wildcardIndex = pattern.IndexOf('*');

        // Base case:
        // If there are no wildcards left, this is
        // one complete binary string.
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace the wildcard with 0.
        string withZero =
            pattern[..wildcardIndex] +
            "0" +
            pattern[(wildcardIndex + 1)..];

        // Replace the wildcard with 1.
        string withOne =
            pattern[..wildcardIndex] +
            "1" +
            pattern[(wildcardIndex + 1)..];

        // Recursively solve both possibilities.
        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start
    /// at (0,0) and end at the end square.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize the path on the first call.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add our current position to the current path.
        currPath.Add((x, y));

        // Base case:
        // If the current position is the end,
        // save this complete path.
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());

            // Backtrack before returning.
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Try moving right.
        if (maze.IsValidMove(currPath, x + 1, y))
        {
            SolveMaze(results, maze, x + 1, y, currPath);
        }

        // Try moving down.
        if (maze.IsValidMove(currPath, x, y + 1))
        {
            SolveMaze(results, maze, x, y + 1, currPath);
        }

        // Try moving left.
        if (maze.IsValidMove(currPath, x - 1, y))
        {
            SolveMaze(results, maze, x - 1, y, currPath);
        }

        // Try moving up.
        if (maze.IsValidMove(currPath, x, y - 1))
        {
            SolveMaze(results, maze, x, y - 1, currPath);
        }

        // Backtrack:
        // Remove this position so another recursive branch
        // can explore a different route.
        currPath.RemoveAt(currPath.Count - 1);
    }
}