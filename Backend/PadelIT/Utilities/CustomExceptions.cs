namespace PadelIT.Utilities
{
    public class CustomExceptions
    {
    }
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
    public class PlayerNotFoundException : CustomException
    {
        public PlayerNotFoundException() : base("Player does not exist")
        {
        }
    }
}
