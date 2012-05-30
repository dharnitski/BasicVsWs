using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class PerformanceResult
    {
        public TimeSpan TotalExecutionTime { get; set; }
        public TimeSpan AvarageExecutionTime  
        { 
            get
            {
                return  TimeSpan.FromTicks(TotalExecutionTime.Ticks / ExecutionCount);
            }
        }
        public int ExecutionCount { get; set; }

        public override string ToString()
        {
            return string.Format("Method was executed {0} times, execution took {1} milliseconds", ExecutionCount, TotalExecutionTime.TotalMilliseconds );
        }
    }
}
