using System;
using Akka.Actor;
using Akka.Console.Messages;

namespace Akka.Console.Actors
{
    public class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            Context.ActorOf(Props.Create<UserCoordinatorActor>(), "UserCoordinator");
            Context.ActorOf(Props.Create<PlaybackStatisticsActor>(), "PlaybackStatistics");
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
            ColorConsole.WriteLineGreen("Playback Actor PreRestart because of " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("Playback Actor PostRestart because of " + reason);
            base.PostRestart(reason);
        }
    }
}