using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueingModels
{
    // interarrival time: M (exponential distribution)
    // service time: M (exponential distribution)
    // server count: s (constant)
    public class MMs : BasicModel
    {
        //mean arrival rate (expected number of arrivals per unit time) of new customers
        protected double m_lambda;
        public double MeanArrivalRate
        {
            get
            {
                return m_lambda;
            }
            set { m_lambda = value; }
        }

        //mean service rate for overral system (expected number of customers completing service per unit time) 
        protected double m_mu;
        public double MeanServiceRate
        {
            get
            {
                return m_mu;
            }
            set { m_mu = value; }
        }

        // number of servers
        protected int m_s;
        public int NumberOfServers
        {
            get
            {
                return m_s;
            }
            set { m_s = value; }
        }

        // utilization factor rho=lambda / (s * mu)
        protected double m_rho;
        public double UtilitizationFactor
        {
            get
            {
                return m_rho;
            }
        }

        // expected queue length (excludes customers being served)
        protected double m_Lq;
        public double ExpectedQueueLength
        {
            get
            {
                return m_Lq;
            }
        }

        //expected waiting time in queue (excludees service time) for each individual
        protected double m_Wq;
        public double ExpectedWaitingTimeInQueue
        {
            get
            {
                return m_Wq;
            }
        }

        //expected number of customers in queueing system
        protected double m_L;
        public double ExpectedNumberOfCustomersInQueueingSystem
        {
            get
            {
                return m_L;
            }
        }

        // expected value of waiting time in system (includes service time) for each individual customer.
        protected double m_W;
        public double ExpectedWaitingTimeInSystem
        {
            get
            {
                return m_W;
            }
        }

        // probability of Wq == 0, i.e., P{Wq=0}
        protected double m_PWq0;
        public double ProbabilityForNoWaitingTimeInQueue
        {
            get
            {
                return m_PWq0;
            }
        }

        //max number of customers in a queueing system
        private int m_N;
        public int MaximumNumberOfCustomersInQueueingSystem
        {
            get { return m_N; }
            set { m_N = value; }
        }

        //load
        private double m_a;
        public double Load
        {
            get { return m_a; }
            set { m_a = value; }
        }

        public override void Build()
        {
            m_rho = MeanArrivalRate / (NumberOfServers * MeanServiceRate);
            m_a = MeanArrivalRate / MeanServiceRate;

            double sum = 0;
            for (int n = 0; n < NumberOfServers; ++n)
            {
                sum += (System.Math.Pow(Load, n) / Factorial(n));
            }
            double P0 = 1 / (sum + System.Math.Pow(Load, NumberOfServers) / Factorial(NumberOfServers - 1) / (NumberOfServers - Load));

            m_Lq = P0 * System.Math.Pow(Load, NumberOfServers) * UtilitizationFactor / (Factorial(NumberOfServers) * System.Math.Pow(1 - Load, 2));
            m_Wq = ExpectedQueueLength / MeanArrivalRate;

            m_W = ExpectedWaitingTimeInQueue + 1 / MeanServiceRate;
            m_L = ExpectedQueueLength + Load;

            m_PWq0 = P0;
            for (int n = 1; n < NumberOfServers; ++n)
            {
                double P_n = System.Math.Pow(Load, n) * P0 / Factorial(n);
                m_PWq0 += P_n;
            }
        }

        public override double GetFractionOfServicesMeetingAnswerTime(double t)
        {
            return 1 - (1 - ProbabilityForNoWaitingTimeInQueue) * System.Math.Exp(-MeanServiceRate * (NumberOfServers - Load) * t);
        }

        public override double GetGradeOfService()
        {
            throw new NotImplementedException();
        }
    }
}
