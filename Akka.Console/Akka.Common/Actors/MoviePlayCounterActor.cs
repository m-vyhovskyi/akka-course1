using System;
using System.Collections.Generic;

using Akka.Actor;
using Akka.Common.Exceptions;
using Akka.Common.Messages;

namespace Akka.Common.Actors
{
    public class MoviePlayCounterActor : ReceiveActor
    {
        private Dictionary<string, int> _moviePlayCounts;

        public MoviePlayCounterActor()
        {
            _moviePlayCounts = new Dictionary<string, int>();
            Receive<IncrementPlayCountMessage>(message => HandleIncrementMessage(message));
        }

        private void HandleIncrementMessage(IncrementPlayCountMessage message)
        {
            if (_moviePlayCounts.ContainsKey(message.Title))
            {
                _moviePlayCounts[message.Title]++;
            }
            else
            {
                _moviePlayCounts.Add(message.Title, 1);
            }

            if (_moviePlayCounts[message.Title] > 3)
            {
                throw new SimulatedCorruptStateException();
            }

            if (message.Title == "Terrible")
            {
                throw new SimulatedTerribleMovieException();
            }

            ColorConsole.WriteMagenta(string.Format("MoviePlayCounterActor '{0}' has been watched {1} times",message.Title, _moviePlayCounts[message.Title]));
        }

        protected override void PreStart()
        {
            ColorConsole.WriteMagenta("Movie Play Counter Actor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteMagenta("Movie Play Counter Actor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteMagenta("Movie Play Counter Actor PreRestart because of " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteMagenta("Movie Play Counter Actor PostRestart because of " + reason);
            base.PostRestart(reason);
        }

    }
}