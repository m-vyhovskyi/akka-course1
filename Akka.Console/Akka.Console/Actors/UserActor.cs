using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Console.Messages;

namespace Akka.Console.Actors
{
    public class UserActor : ReceiveActor
    {
        public int UserId { get; set; }
        private string _currentlyWatching;

        public UserActor(int userId)
        {
            UserId = userId;
            System.Console.WriteLine("Creating a User Actor");

            ColorConsole.WriteLineCyan("Setting initial behaviour to Stopped");
            Stopped();
        }

        private void Playing()
        {
            Receive<PlayMovieMessage>(message => ColorConsole.WriteLineRed("Error: cannot start playing another movie before stopping the existing one"));
            Receive<StopMovieMessage>(message => StopPlayingMovie());
            ColorConsole.WriteLineCyan("User Actor has now become Playing");

        }

        private void Stopped()
        {
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.Title));
            Receive<StopMovieMessage>(message => ColorConsole.WriteLineRed("Error: cannot stop if nothing is playing"));
            ColorConsole.WriteLineCyan("User Actor has now become Stopped");
        }

        private void StopPlayingMovie()
        {
            ColorConsole.WriteLineYellow(string.Format("User has stopped watching {0}", _currentlyWatching));
            _currentlyWatching = string.Empty;
            Become(Stopped);
        }

        private void StartPlayingMovie(string title)
        {
            _currentlyWatching = title;
            ColorConsole.WriteLineYellow(string.Format("User is currently watching {0}", _currentlyWatching));
            Context.ActorSelection("/user/Playback/PlaybackStatistics/MoviePlayCounter").Tell(new IncrementPlayCountMessage { Title = title });
            Become(Playing);
        }

        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("User Actor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("User Actor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("User Actor PreRestart because of " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("User Actor PostRestart because of " + reason);
            base.PostRestart(reason);
        }

    }
}