using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Contract;

namespace Server
{
    public class CounterService: ICounter
    {
        private int _value = 0;

        public int Add(int num)
        {
            _value += num;
            Console.WriteLine("Method Add called with argument {0}. Method  returned {1}", num, _value);
            return _value;
        }
    }
}
