﻿using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFBus.Tests.TestClasses
{
    public class EventTestSagaData : SagaData
    {
        public int Counter { get; set; }

        public bool EventReceived { get; set; }
    }
}
