namespace Akka.Common.Messages
{
    public class StopMovieMessage:IUserMessage
    {
        public int UserId { get; private set; }

        public StopMovieMessage(int userId)
        {
            UserId = userId;
        }
    }
}