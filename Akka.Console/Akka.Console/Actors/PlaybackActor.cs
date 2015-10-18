using System;
using Akka.Actor;
using Akka.Console.Messages;

namespace Akka.Console.Actors
{
    public class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            System.Console.WriteLine("A new instance of PlaybackActor is created");

            Receive<PlayMovieMessage>(PlayMovie, message => message.Age > 30);
        }

        private void PlayMovie(PlayMovieMessage message)
        {
            ColorConsole.WriteLineYellow("Got a message: " + message.Title + " with age: " + message.Age);
        }

        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("Playback Actor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("Playback Actor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("Playback Actor PreRestart because of "+reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("Playback Actor PostRestart because of " + reason);
            base.PostRestart(reason);
        }
    }
}