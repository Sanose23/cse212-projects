using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities. Dequeue should return highest priority each time.
    // Expected Result: "C" (priority 5), then "D" (3), then "B" (2), then "A" (1)
    // Defect(s) Found: ❌ Highest priority item wasn't properly identified due to incorrect loop range.
    // ✅ Fixed: Loop now checks entire list. Dequeued item is removed properly.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 3);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with same priority. Test if dequeue follows FIFO for equal priority.
    // Expected Result: "X" dequeued before "Y"
    // Defect(s) Found: ✅ No defect — FIFO behavior for equal priority works as expected.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 3);
        priorityQueue.Enqueue("Y", 3);

        Assert.AreEqual("X", priorityQueue.Dequeue());
        Assert.AreEqual("Y", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue.
    // Expected Result: InvalidOperationException with correct message.
    // Defect(s) Found: ✅ Exception thrown as expected when queue is empty.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue(); // Should throw
    }
}
