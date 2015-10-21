using System;
using System.Linq;

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
            var asms = AppDomain.CurrentDomain.GetAssemblies().ToArray();
            var typeName = "Akka.Remote.Deadline, Akka.Remote";
            var deadlineType = typeof(Akka.Remote.Deadline);
            Type t = Type.GetType(typeName);
            if (t == null)
            {
                foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    t = a.GetType("Akka.Remote.Deadline");
                    if (t != null)
                        break;
                }
            }
            Console.WriteLine("Type is "+t.ToString());
            ActorSystem = ActorSystem.Create("RemoteActorSystem");

            ActorSystem.AwaitTermination();
        }
    }
}