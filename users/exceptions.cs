namespace TimeKeeper.users.exceptions
{
    class NullMainList : Exception
    {
    public NullMainList() : base() { }
    public NullMainList(string message) : base(message) { }
    public NullMainList(string message, Exception inner) : base(message, inner) { }
    }

    class InvalidInput : ArgumentException
    {
    public InvalidInput() : base() { }
    public InvalidInput(string message) : base(message) { }
    public InvalidInput(string message, Exception inner) : base(message, inner) { }
    }

    class InvalidLoginState : Exception
    {
    public InvalidLoginState() : base() { }
    public InvalidLoginState(string message) : base(message) { }
    public InvalidLoginState(string message, Exception inner) : base(message, inner) { }
    }
}