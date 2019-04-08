using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueingModels
{
    //pure loss system with infinite population
    public class ErlangB : BasicModel
    {
        //the number of service calls that enter on average per time unit 
        private double m_lambda;
        public double NumberOfServiceCallsOnAveragePerTimeUnit
        {
            get { return m_lambda; }
            set { m_lambda = value; }
        }

        //the average service time of calls or average holding time 
        private double m_beta;
        public double AverageServiceTimeOfCalls
        {
            get { return m_beta; }
            set { m_beta = value; }
        }

        //load=lambda * beta
        private double m_a;
        public double Load
        {
            get { return m_a; }
            set { m_a = value; }
        }

        //number of servers/agents
        private int m_s;
        public int NumberOfServers
        {
            get { return m_s; }
            set { m_s = value; }
        }

        public override void Build()
        {
            m_a = NumberOfServiceCallsOnAveragePerTimeUnit * AverageServiceTimeOfCalls;
        }

        //Grade of Service, aka, probability of delay
        //the probability that an arbitrary caller finds all servers/agents occupied
        public override double GetGradeOfService()
        {
            return ErlangBFormula(Load, NumberOfServers);
        }

        public static double ErlangBFormula(double load, int number_of_servers)
        {
            double c = System.Math.Pow(load, number_of_servers) / Factorial(number_of_servers);
            double sum = 0;
            for (int j = 0; j < number_of_servers; ++j)
            {
                sum += System.Math.Pow(load, number_of_servers) / Factorial(number_of_servers);
            }
            return c / (sum + c);
        }

        public override double GetFractionOfServicesMeetingAnswerTime(double AWT)
        {
            throw new NotImplementedException();
        }

        //average waiting time, the average amount of time that calls spend waiting
        public virtual double GetAverageWaitingTime()
        {
            return GetGradeOfService() * AverageServiceTimeOfCalls / (NumberOfServers - Load);
        }
    }
}
