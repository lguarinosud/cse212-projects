using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and check that they are dequeued in the order they were added.
    // Expected Result: First out: "A", second out: "B", third out: "C". This will be compared when dequieued and the equal assertion
    // needs to be true.
    // Defect(s) Found: In first enqueued, Expected A but got B. A few issues:
    // 1. In the Dequeue method, the loop was starting from 1 instead of 0, which caused it to skip the first item.
    // 2. The condition in the loop was checking for less or equal than instead of less  causing to carry over, if equal priority, the last item added instead of first.
    // 3. A line was missing to remove the item from the queue. 
    // 4. Within the for loop, the iteration was from 0 until queue.Count -1 was less than index, which made it skip the last item. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());

    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and check that they are dequeued in the order of priority.
    // Expected Result: First out: "C", second out: "B", third out: "A". This will be compared when dequieued and the equal assertion
    // needs to be true.
    // Defect(s) Found: In first enqueued, it Expected C but got B. 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);


        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());

    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Enqueue mutiple items with different priorities. Two of them have the same priority.
    // Expected Result: First out: "C", second out: "B", third out: "A". This will be compared when dequieued and the equal assertion
    // needs to be true.
    // Defect(s) Found: In second enqueued, it Expected B but got C. 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());

    }
}