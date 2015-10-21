using Akka.Actor;
using Akka.Common;

namespace Akka.Remote
{
    class Program
    {
        private static ActorSystem ActorSystem;

        static void Main(string[] args)
        {
            ColorConsole.WriteLineGray("Creating Remote Actor System");

            ActorSystem = ActorSystem.Create("RemoteACtorSystem");

            ActorSystem.AwaitTermination();
        }
    }
}