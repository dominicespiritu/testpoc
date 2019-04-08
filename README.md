# cs-queung-models

Queueing Models implemented in .NET

# Features

* Erlang-B
* Extended Erlang-B
* Erlang-C
* MMs

# Usage

### Erlang-B

```cs 
ErlangB queue = new ErlangB();
queue.NumberOfServers = 2;
queue.NumberOfServiceCallsOnAveragePerTimeUnit = 100;
queue.AverageServiceTimeOfCalls = 0.002;
queue.Build();

Console.WriteLine("The average amount of time that calls spend waiting: {0}", queue.GetAverageWaitingTime());
Console.WriteLine("The probability that an arbitrary caller finds all servers/agents occupied: {0}", queue.GetGradeOfService());
```

### Extended Erlang-B

```cs 
ExtendedErlangB queue = new ExtendedErlangB();
queue.NumberOfServers = 2;
queue.NumberOfServiceCallsOnAveragePerTimeUnit = 100;
queue.AverageServiceTimeOfCalls = 0.002;
queue.Build();

Console.WriteLine("The average amount of time that calls spend waiting: {0}", queue.GetAverageWaitingTime());
Console.WriteLine("The probability that an arbitrary caller finds all servers/agents occupied: {0}", queue.GetGradeOfService());
```


### Erlang-C

```cs 
ErlangC queue = new ErlangC();
queue.NumberOfServers = 2;
queue.NumberOfServiceCallsOnAveragePerTimeUnit = 100;
queue.AverageServiceTimeOfCalls = 0.002;
queue.Build();

Console.WriteLine("The average amount of time that calls spend waiting: {0}", queue.GetAverageWaitingTime());
Console.WriteLine("The fraction of services meeting the answer time AWT: {0}", queue.GetFractionOfServicesMeetingAnswerTime(1.5));
```
