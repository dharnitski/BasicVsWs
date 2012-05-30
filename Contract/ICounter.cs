﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Contract
{
    [ServiceContract]
    public interface ICounter
    {
        [OperationContract]
        int Add(int num);
    }
}
