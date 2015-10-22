using System;
using System.Threading;
using Akka.Actor;
using AkkaLearning.Common;
using AkkaLearning.Common.Actors;
using AkkaLearning.Common.Messages;
using SC = System.Console;

namespace AkkaLearning.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("SYS1");

            var playbackActorProps = Props.Create<PlaybackActor>();
            actorSystem.ActorOf(playbackActorProps, "Playback");

            do
            {
                ShortPause();

                SC.WriteLine();
                SC.ForegroundColor = ConsoleColor.DarkGray;
                SC.WriteLine("enter a command and hit enter");

                var command = SC.ReadLine();
                var commandParts = command.Split(',');

                if (command.StartsWith("play"))
                {
                    int userId = int.Parse(commandParts[1]);
                    string title = commandParts[2];

                    var message = new PlayMovieMessage(title, userId);
                    actorSystem.ActorSelection("/user/Playback/UserCoordinator").Tell(message);
                }

                if (command.StartsWith("stop"))
                {
                    int userId = int.Parse(commandParts[1]);

                    var message = new StopMovieMessage(userId);
                    actorSystem.ActorSelection("/user/Playback/UserCoordinator").Tell(message);
                }

                if (command == "exit")
                {
                    actorSystem.Shutdown();
                    actorSystem.AwaitTermination();
                    ColorConsole.WriteLineGray("Actor system shutdown");
                    SC.ReadKey();
                    Environment.Exit(1);
                }
            } while (true);
        }

        private static void ShortPause()
        {
            Thread.Sleep(500);
        }
    }
}
