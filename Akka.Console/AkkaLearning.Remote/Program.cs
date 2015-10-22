using Akka.Actor;
using AkkaLearning.Common;

namespace AkkaLearning.Remote
{
    internal class Program
    {
        private static ActorSystem ActorSystem;

        private static void Main(string[] args)
        {
            ColorConsole.WriteLineGray("Creating Remote Actor System");
            ActorSystem = ActorSystem.Create("MoviewStreamingActorSystem");
            ActorSystem.AwaitTermination();
        }
    }
}