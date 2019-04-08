using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueingModels
{
    class Program
    {
        static void Main(string[] args)
        {
            RunErlangB();
            RunErlangC();
            RunExtendedErlangB();
        }

        static void RunErlangB()
        {
            ErlangB queue = new ErlangB();
            queue.NumberOfServers = 2;
            queue.NumberOfServiceCallsOnAveragePerTimeUnit = 100;
            queue.AverageServiceTimeOfCalls = 0.002;
            queue.Build();

            Console.WriteLine("The average amount of time that calls spend waiting: {0}", queue.GetAverageWaitingTime());
            Console.WriteLine("The probability that an arbitrary caller finds all servers/agents occupied: {0}", queue.GetGradeOfService());
        }

        static void RunErlangC()
        {
            ErlangC queue = new ErlangC();
            queue.NumberOfServers = 2;
            queue.NumberOfServiceCallsOnAveragePerTimeUnit = 100;
            queue.AverageServiceTimeOfCalls = 0.002;
            queue.Build();

            Console.WriteLine("The average amount of time that calls spend waiting: {0}", queue.GetAverageWaitingTime());
            Console.WriteLine("The fraction of services meeting the answer time AWT: {0}", queue.GetFractionOfServicesMeetingAnswerTime(1.5));
        }

        static void RunExtendedErlangB()
        {
            ExtendedErlangB queue = new ExtendedErlangB();
            queue.NumberOfServers = 2;
            queue.NumberOfServiceCallsOnAveragePerTimeUnit = 100;
            queue.AverageServiceTimeOfCalls = 0.002;
            queue.Build();

            Console.WriteLine("The average amount of time that calls spend waiting: {0}", queue.GetAverageWaitingTime());
            Console.WriteLine("The probability that an arbitrary caller finds all servers/agents occupied: {0}", queue.GetGradeOfService());
        }
    }
}
