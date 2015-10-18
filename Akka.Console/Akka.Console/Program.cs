using Akka.Actor;
using Akka.Console.Actors;
using Akka.Console.Messages;
using SC = System.Console;

namespace Akka.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var ac = ActorSystem.Create("SYS1");

            var userActorProps = Props.Create<UserActor>();
            var userActorRef = ac.ActorOf(userActorProps, "UserActor");

            SC.ReadKey();
            SC.WriteLine("Sending a PlayMovieMessage ('AKKA.NET: The Movie'");
            userActorRef.Tell(new PlayMovieMessage("AKKA.NET: The Movie", 32));

            SC.ReadKey();
            SC.WriteLine("Sending another PlayMovieMessage ('Star Wars, Episode 1'");
            userActorRef.Tell(new PlayMovieMessage("Star Wars, Episode 1", 33));

            SC.ReadKey();
            SC.WriteLine("Sending a StopMovieMessage");
            userActorRef.Tell(new StopMovieMessage());

            SC.ReadKey();
            SC.WriteLine("Sending another StopMovieMessage");
            userActorRef.Tell(new StopMovieMessage());

            SC.WriteLine("Actor System created");
            
            SC.ReadLine();

            ac.Shutdown();
            ac.AwaitTermination();
            SC.WriteLine("Actor System Shutdown");
        }
    }
}
