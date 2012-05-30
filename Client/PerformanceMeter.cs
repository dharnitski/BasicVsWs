using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Client
{
    class PerformanceMeter
    {
        public PerformanceMeter(string endpointConfigurationName)
        {
            _endpointConfigurationName = endpointConfigurationName;
        }

        private string _endpointConfigurationName;

        public PerformanceResult Run(int executionCount, Func<int, int> testFunction)
        {
            int output;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            output = testFunction(executionCount);

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            var result = new PerformanceResult
            {
                ExecutionCount = executionCount,
                TotalExecutionTime = ts
            };
            return result;
        }

        public int RunAllCallsInOneContext(int executionCount)
        {
            Console.WriteLine("All calls are made within the same Context");
            int output = 0;
            using (var proxy = new CounterProxy.CounterClient(_endpointConfigurationName))
            {
                for (int i = 0; i < executionCount; i++)
                {
                    output = proxy.Add(1);
                }
            }
            return output;
        }

        public int RunAllCallsInSeparateContext(int executionCount)
        {
            Console.WriteLine("New Context is created for every call");
            int output = 0;
            for (int i = 0; i < executionCount; i++)
            {
                using (var proxy = new CounterProxy.CounterClient(_endpointConfigurationName))
                {
                    output = proxy.Add(1);
                }
            }
            return output;
        }
    }
}
