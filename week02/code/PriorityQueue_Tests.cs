using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities. The item with the highest
    // priority is placed at the back of the queue.
    // Expected Result: "High" should be returned because it has the highest priority.
    // Defect(s) Found: The original loop did not examine the last item in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items where two items have the same highest priority.
    // Expected Result: "First" should be returned because it was added before "Second".
    // Defect(s) Found: The original code used >= when comparing priorities, causing
    // the later item with the same priority to be selected instead of the first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add three items with different priorities and dequeue all three.
    // Expected Result: Items should be returned in priority order:
    // High, Medium, Low.
    // Defect(s) Found: The original Dequeue method returned the selected value
    // but did not remove the item from the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue an item from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the
    // message "The queue is empty."
    // Defect(s) Found: None. The original code correctly throws the required exception.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                $"Unexpected exception of type {e.GetType()} caught: {e.Message}"
            );
        }
    }

    [TestMethod]
    // Scenario: Add several items where the highest priority occurs more than once,
    // then dequeue repeatedly.
    // Expected Result: Equal-priority items should be removed in FIFO order.
    // Expected order: FirstHigh, SecondHigh, Medium, Low.
    // Defect(s) Found: This verifies that equal priorities maintain FIFO order
    // and that each item is actually removed after being dequeued.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("FirstHigh", 10);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("SecondHigh", 10);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }
}