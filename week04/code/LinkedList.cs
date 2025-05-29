using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head; // The "?" at the end means head can be null. 
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    /// Create a new node (we will call it newNode)
    // Set the "next" of the new node to the current head (newNode.Next = head)
    // Set the "prev" of the current head to the new node (head.Prev = newNode)
    // Set the head equal to the new node (head = newNode

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
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>

    // Create a new node (we will call it newNode) *
    // Set the "prev" of the new node to the current tail (newNode.Prev = tail)
    // Set the "next" of the current tail to the new node (tail.Next = newNode)
    // Set the tail equal to the new node (tail = newNode)

    public void InsertTail(int value)
    {
        // If the list is empty, then point both head and tail to the new node.
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Prev = _tail; // Set the "prev" of the new node to the current tail
            _tail.Next = newNode; // Set the "next" of the current tail to the new node ()
            _tail = newNode; // Update the head to point to the new node
        }

    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    /// 


    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        if (_tail == _head)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the Tail
        // will be affected.
        else if (_tail is not null)
        {
            _tail = _tail.Prev; // Make the previous of the current tail, to be the new tail.
            _tail!.Next = null; // Disconnect the new tail from the removed tail by setting Next to null.
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        // Start at the beginning (the head)
        var current = _head;

        // Loop until we have found our value or reached the end (null)
        while (current != null) //&& current.Data != value
        {
            // If we found a matching value, and turns out is the head, then remove it using RemoveHead()
            if (current.Data == value && current == _head)
            {
                this.RemoveHead();
                return;
            }
            // If we found a matching value, and turns out is the tail, then remove it using RemoveTail()
            else if (current.Data == value && current == _tail)
            {
                this.RemoveTail();
                return;
            }
            // If we found our value, then remove it from the middle and return (Exit)
            else if (value == current.Data)
            {
                // The node is in the middle. 
                current.Next!.Prev = current.Prev; // Set the prev of the node after current to the node before current (current.Next.Prev = current.Prev)
                current.Prev!.Next = current.Next; // Set the next of the node before current to the node after current 
                return;
            }
            else
            // If the value is not the head, the tail or any in the middle, then move to the next one
            {
                // Follow the pointer to the next node
                current = current.Next;
            }
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4

        var current = _head;

        // Loop until the node is null
        while (current != null) //&& current.Data != value
        {
            // If we found a matching with the oldValue, then repace it with the new value, and then keep looping to find more. 
            if (current.Data == oldValue)
            {
                current.Data = newValue;
                current = current.Next;
            }

            else
            // If no match, move to the next node
            {
                // Follow the pointer to the next node
                current = current.Next;
            }
        }

    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        var curr = _tail;
        while (curr is not null)
        {
            yield return curr.Data;
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