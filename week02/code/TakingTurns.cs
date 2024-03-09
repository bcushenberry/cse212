public static class TakingTurns {
    public static void Test() {
        // TODO Problem 1 - Run test cases and fix the code to match requirements
        // Test Cases

        // Test 1
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
        // run until the queue is empty
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        Console.WriteLine("Test 1");
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);    // This can be un-commented out for debug help
        while (players.Length > 0)
            players.GetNextPerson();
        // Defect(s) Found: The players are not being displayed in the expected order. Instead of looping through all people once before starting again, the same person is displayed until they are completely out of the queue. FIFO order doesn't seem to be working here, either - we first add Bob x2, but GetNextPerson first displays Sue x3, which was added last. The order is LIFO, like a stack.
        // Actual Result: Sue, Sue, Sue, Tim, Tim, Tim, Tim, Tim, Bob, Bob
        // Fix: "Insert" is being used in PersonQueue to enqueue people to the list, rather than "Add". Changing "Insert" to "Add" fixed the issue.

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
        // After running 5 times, add George with 3 turns.  Run until the queue is empty.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
        Console.WriteLine("Test 2");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 5; i++) {
            players.GetNextPerson();
            // Console.WriteLine(players);
        }

        players.AddPerson("George", 3);
        // Console.WriteLine(players);
        while (players.Length > 0)
            players.GetNextPerson();

        // Defect(s) Found: This appears to be more or less the same issue as Test 1 - the players are displayed in LIFO order, and are not looped through individually but rather all at once. Once George is added to the end of the queue, he immediately displayed first three times.
        // Actual Result: Sue, Sue, Sue, Tim, Tim, George, George, George, Tim, Tim, Tim, Bob, Bob 
        // Fix: "Insert" is being used in PersonQueue to enqueue people to the list, rather than "Add". Changing "Insert" to "Add" fixed the issue.        

        Console.WriteLine("---------");

        // Test 3
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
        // Run 10 times.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        Console.WriteLine("Test 3");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 0);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);
        for (int i = 0; i < 10; i++) {
            players.GetNextPerson();
            // Console.WriteLine(players);
        }
        // Defect(s) Found: As with the above tests, the names are displayed in LIFO order, and a single person's name is displayed for all of their turns at once before the next person's name is displayed. Additionally, Tim's name is only displayed once before being removed from the list entirely, so the last four loops display "No one is in the queue."
        // Actual Result: Sue, Sue, Sue, Tim, Bob, Bob, No one is in the queue., No one is in the queue., No one is in the queue., No one is in the queue.
        // Fix: GetNextPerson() was not keeping people with 0 or negative turns in the queue. To fix this, a new check was added to GetNextPerson() to see if the person's initial number of turns is <= 0, and if so, they automatically get queued. In order to avoid having an infinite loop, people who start with more than 0 turns have their turns reduced until they hit 0, at which point they are no longer enqueued.

        Console.WriteLine("---------");

         // Test 4
        // Scenario: Create a queue with the following people and turns: Tim (Forever), Sue (3)
        // Run 10 times.
        // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
        Console.WriteLine("Test 4");
        players = new TakingTurnsQueue();
        players.AddPerson("Tim", -3);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);
        for (int i = 0; i < 10; i++) {
            players.GetNextPerson();
            // Console.WriteLine(players);
        }
        // Defect(s) Found: As with the above tests, the names are displayed in LIFO order, and a single person's name is displayed for all of their turns at once before the next person's name is displayed. Additionally, Tim is only displayed once before being removed from the list, and the last six loops only display "No one is in the queue."
        // Actual Result: Sue, Sue, Sue, Tim, No one is in the queue., No one is in the queue., No one is in the queue., No one is in the queue., No one is in the queue., No one is in the queue.
        // Fix: GetNextPerson() was not keeping people with 0 or negative turns in the queue. To fix this, a new check was added to GetNextPerson() to see if the person's initial number of turns is <= 0, and if so, they automatically get queued. In order to avoid having an infinite loop, people who start with more than 0 turns have their turns reduced until they hit 0, at which point they are no longer enqueued.

        Console.WriteLine("---------");

        // Test 5
        // Scenario: Try to get the next person from an empty queue
        // Expected Result: Error message should be displayed
        Console.WriteLine("Test 5");
        players = new TakingTurnsQueue();
        players.GetNextPerson();
        // Defect(s) Found: None - the error message "No one in the queue." is displayed properly.
    }
}