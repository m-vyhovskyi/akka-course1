using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Console.Messages;

namespace Akka.Console.Actors
{
    public class UserActor: ReceiveActor
    {
        private string _currentlyWatching;

        public UserActor()
        {
            System.Console.WriteLine("Creating a User Actor");

            Receive<PlayMovieMessage>(message => HandlePlayMovie(message));
            Receive<StopMovieMessage>(message => HandleStopMovie());
        }

        private void HandleStopMovie()
        {
            if (String.IsNullOrWhiteSpace(_currentlyWatching))
            {
                ColorConsole.WriteLineRed("Error: cannot stop if nothing is playing");
            }
            StopPlayingMovie();

        }

        private void StopPlayingMovie()
        {
            ColorConsole.WriteLineYellow(string.Format("User has stopped watching {0}", _currentlyWatching));
            _currentlyWatching = string.Empty;
        }

        private void HandlePlayMovie(PlayMovieMessage message)
        {
            if (!String.IsNullOrWhiteSpace(_currentlyWatching))
            {
                ColorConsole.WriteLineRed("Error: cannot start playing another movie before stopping the existing one");
            }
            StartPlayingMovie(message.Title);
        }

        private void StartPlayingMovie(string title)
        {
            _currentlyWatching = title;
            ColorConsole.WriteLineYellow(string.Format("User is currently watching {0}",_currentlyWatching));
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