namespace Akka.Console.Messages
{
    public class PlayMovieMessage
    {
        public PlayMovieMessage(string title, int age)
        {
            Title = title;
            Age = age;
        }

        public string Title { get; private set; }
        public int Age { get; private set; }
    }
}