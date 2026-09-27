using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);

        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // Create a new node.
        Node newNode = new(value);

        // If the list is empty, the new node becomes both
        // the head and the tail.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            // Connect the new node to the current tail.
            newNode.Prev = _tail;
            _tail.Next = newNode;

            // Make the new node the new tail.
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail
        // to null resulting in an empty list. This also covers an empty list.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // Empty list or single-node list.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // More than one node exists.
        else if (_tail is not null)
        {
            // Disconnect the current tail from the previous node.
            _tail.Prev!.Next = null;

            // Move the tail backward.
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);

                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }

                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the matching node is the head, reuse RemoveHead.
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If the matching node is the tail, reuse RemoveTail.
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    // Connect the node before curr to the node after curr.
                    curr.Prev!.Next = curr.Next;

                    // Connect the node after curr to the node before curr.
                    curr.Next!.Prev = curr.Prev;
                }

                // Only remove the first matching value.
                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            // Continue through the entire list because all
            // matching values must be replaced.
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List.
    /// </summary>
    public IEnumerable Reverse()
    {
        // Start at the tail because we are moving backwards.
        var curr = _tail;

        while (curr is not null)
        {
            yield return curr.Data;

            // Follow Prev instead of Next.
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}