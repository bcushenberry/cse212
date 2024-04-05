public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value != Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value) {
        // TODO Start Problem 2
        if (value == Data)
            return false;

        else if (value < Data) {
            if (Left is not null)
            {
                if (Left.Data == value)
                    return true;

                else
                    return Left.Contains(value);
            }
            else
                return false;
        }

        else
        {
            if (Right is not null)
            {
                if (Right.Data == value)
                    return true;

                else
                    return Right.Contains(value);
            }
            else
                return false;
    }
}
    public int GetHeight() {
        // TODO Start Problem 4
        int leftHeight = 1;
        int rightHeight = 1;

        if (Left is null && Right is null)
            return 1;

        if (Left is not null)
            leftHeight = Left.GetHeight() + 1;

        if (Right is not null)
            rightHeight = Right.GetHeight() + 1;
        
        if (leftHeight > rightHeight)
            return leftHeight;
        else
            return rightHeight;
    }
}