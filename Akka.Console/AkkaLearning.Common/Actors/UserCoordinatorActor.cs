using System;
using System.Collections.Generic;
using Akka.Actor;
using AkkaLearning.Common.Messages;

namespace AkkaLearning.Common.Actors
{
    public class UserCoordinatorActor : ReceiveActor
    {
        private Dictionary<int, IActorRef> _users;

        public UserCoordinatorActor()
        {
            _users = new Dictionary<int, IActorRef>();

            Receive<PlayMovieMessage>(message => PropagateMessage(message));
            Receive<StopMovieMessage>(message => PropagateMessage(message));
        }

        private void PropagateMessage(IUserMessage message)
        {
            CreateChildUserIfNotExists(message.UserId);
            var childActorRef = _users[message.UserId];
            childActorRef.Tell(message);
        }

        private void CreateChildUserIfNotExists(int userId)
        {
            if (!_users.ContainsKey(userId))
            {
                var newActorChildRef = Context.ActorOf(Props.Create(() => new UserActor(userId)), "User" + userId);
                _users.Add(userId, newActorChildRef);

                ColorConsole.WriteLineCyan(string.Format("User Coordinator Actor created new child User Actor for {0} (Total users:{1})", userId, _users.Count));
            }
        }

        protected override void PreStart()
        {
            ColorConsole.WriteLineCyan("User Coordinator Actor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineCyan("User Coordinator Actor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineCyan("User Coordinator Actor PreRestart because of " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineCyan("User Coordinator Actor PostRestart because of " + reason);
            base.PostRestart(reason);
        }

    }
}
