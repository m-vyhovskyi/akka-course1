using System;
using Akka.Actor;
using Akka.Console.Exceptions;

namespace Akka.Console.Actors
{
    public class PlaybackStatisticsActor : ReceiveActor
    {
        public PlaybackStatisticsActor()
        {
            Context.ActorOf(Props.Create<MoviePlayCounterActor>(), "MoviePlayCounter");
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(exception =>
            {
                if (exception is SimulatedCorruptStateException)
                {
                    return Directive.Restart;
                }
                if (exception is SimulatedTerribleMovieException)
                {
                    return Directive.Resume;
                }
                return Directive.Restart;
            });
        }

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