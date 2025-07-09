public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The node is always added to the back of the queue regardless of priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the value with the highest priority.
    /// If multiple items share the same highest priority, 
    /// the one added earliest is removed (FIFO).
    /// </summary>
    /// <returns>Value of the highest-priority item</returns>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the item with the highest priority (maintain FIFO)
        int highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) // ✅ FIXED: loop includes last item
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Remove and return the item
        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // ✅ FIXED: actually remove the item
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
