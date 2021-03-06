﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueingModels
{
    //infinite-queue queuing system
    //link: http://web2.uwindsor.ca/math/hlynka/qsoft.html
    //LINK: http://www.mitan.co.uk/erlang/elgcmath.htm
    public class ErlangC : BasicModel
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

        //probability of delay
        //the probability that an arbitrary caller finds all servers/agents occupied
        private double GetProbabilityOfDelay()
        {
            return ErlangCFormula(Load, NumberOfServers);
        }

        public static double ErlangCFormula(double load, int number_of_server)
        {
            //double c = Math.Pow(load, number_of_server) / (Factorial(number_of_server - 1) * (number_of_server - load));
            //double sum = 0;
            //for (int j = 0; j < number_of_server; ++j)
            //{
            //    sum += (Math.Pow(load, j) / Factorial(j));
            //}
            //return c / (sum + c);

            double product=1;
            for(int j=1; j <= number_of_server-1; j++)
            {
            product=product * j / load +1;
            }
            return 1 / (product * (number_of_server - load) / load + 1);
        }

        //telephone service fraction, the fraction of services meeting the answer time AWT
        public override double GetFractionOfServicesMeetingAnswerTime(double AWT)
        {
            double TSF = 0; 
            if (m_a < m_s)
            {

                TSF = 1 - GetProbabilityOfDelay() * System.Math.Exp(-(NumberOfServers - Load) * AWT / AverageServiceTimeOfCalls);
            }
            else
            {
                TSF = 0;
            }
            return TSF;
        }

        //average waiting time, the average amount of time that calls spend waiting
        public double GetAverageWaitingTime()
        {
            return GetProbabilityOfDelay() * AverageServiceTimeOfCalls / (NumberOfServers - Load);
        }

        public override double GetGradeOfService()
        {
            throw new NotImplementedException();
        }
    }
}
