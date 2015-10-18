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
            var playbackActorProps = Props.Create<PlaybackActor>();
            var playbackActorRef = ac.ActorOf(playbackActorProps, "PlaybackActor");

            playbackActorRef.Tell(new PlayMovieMessage("AKKA.NET: The Movie", 32));
            playbackActorRef.Tell(new PlayMovieMessage("Star Wars, Episode 1", 33));
            playbackActorRef.Tell(new PlayMovieMessage("Sitting at the EDGE", 32));
            playbackActorRef.Tell(new PlayMovieMessage("Bee Gees - The Dest", 40));

            playbackActorRef.Tell(PoisonPill.Instance);

            SC.WriteLine("Actor System created");
            
            SC.ReadLine();

            ac.Shutdown();
            ac.AwaitTermination();
            SC.WriteLine("Actor System Shutdown");
        }
    }
}
