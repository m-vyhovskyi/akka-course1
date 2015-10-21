using System;
using Akka.Actor;

namespace Akka.Console.Actors
{
    public class PlaybackStatisticsActor : ReceiveActor
    {
        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("Playback Statistics Actor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("Playback Statistics Actor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("Playback Statistics Actor PreRestart because of " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("Playback Statistics Actor PostRestart because of " + reason);
            base.PostRestart(reason);
        }
    }
}