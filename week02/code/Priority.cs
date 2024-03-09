public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Create a queue with the following people & priorities:
        // Bob (1), Tim (3), Sue (2), George (3)
        // Dequeue until the queue is empty
        // Expected Result: Tim, George, Sue, Bob
        Console.WriteLine("Test 1");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 3);
        priorityQueue.Enqueue("Sue", 2);
        priorityQueue.Enqueue("George", 3);

        for (int i = 0; i < 4; i++) {
            Console.WriteLine(priorityQueue.Dequeue());
        }

        // Defect(s) Found: Dequeue is not removing the highest priority item(person) from the list. In the above test, only Tim is displayed four times. After fixing this defect, another one was found: George isn't removed until last, despite being the same priority as Tim. This was fixed by removing the "- 1" in the for statement "index < _queue.Count - 1". After fixing this, "George" was appearing before "Tim," despite Tim being further in front in the queue. To fix this, I removed the "=" sign from "_queue[index].Priority >= _queue[highPriorityIndex].Priority" to force the first highest number to be dealt with first. (Leaving the equal sign meant that any entry with a priority equal to that of the highest priority would be treated as the highest priority.)

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Create a list with the following person & priority:
        // Bob (1)
        // Dequeue Bob from the list and then attempt to dequeue again.
        // Expected Result: An error message will appear.
        Console.WriteLine("Test 2");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);

        for (int i = 0; i < 2; i++) {
            Console.WriteLine(priorityQueue.Dequeue());
        }
        // Defect(s) Found: As with the above test, dequeue is not removing Bob from the list. After fixing this issue, the error message "The queue is empty." displayed properly.

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below

    }
}