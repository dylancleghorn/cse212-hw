using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue the highest priority item
    // Expected Result: dequeued item is highest priority
    // Defect(s) Found: dequeue did not return highest priority item. loop was bound incorrectly; passes after removing -1 
    public void HighestPriorityLeavesFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Have Fun", 1);
        priorityQueue.Enqueue("Buy Food", 3);
        priorityQueue.Enqueue("Get Paid", 5);
        Assert.AreEqual("Get Paid", priorityQueue.Dequeue());

    }

    [TestMethod]
    // Scenario: multiple items have same priority
    // Expected Result: the first added gets dequeued
    // Defect(s) Found: last item added was removed; highest index should only update when > not >= to highest found in loop. passes after updating operator.
    public void EqualPrioritiesFollowArrivalOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);
        Assert.AreEqual("First", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: dequeueing removes item from queue 
    // Expected Result: items are removed in correct order
    // Defect(s) Found: failed with multiple dequeue attempts; dequeue was missing RemoveAt, passes after adding.
    public void DequeuedItemIsRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("High", 9);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High2", 9);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: empty queue should error
    // Expected Result: exception thrown, error message returned
    // Defect(s) Found: none, runs successfully
    public void EmptyQueueException()
    {
        var priorityQueue = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(
               () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}