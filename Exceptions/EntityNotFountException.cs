namespace ForumSystem.Exceptions
{
    public class EntityNotFountException : ApplicationException
    {
        public EntityNotFountException(string message)
           : base(message)
        {
        }
    }
}
