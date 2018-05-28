using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFBus.Tests.TestClasses
{
    public class EventTestSaga : Saga<EventTestSagaData>, IHandleStartingSaga<EventSagaStartingMessage>,  IHandleCommandWithCorrelation<EventSagaIntermediateMessage>, IHandleEventWithCorrelation<EventMessage>
    {
        private const string PARTITION_KEY = "SimpleTestSaga";

        
        public Task HandleAsync(IBus bus, SimpleSagaStartingMessage input, TraceWriter Log)
        {           

            this.Data.PartitionKey = PARTITION_KEY;
            this.Data.RowKey = input.Id.ToString();
            this.Data.Counter++;
            InvocationCounter.Instance.AddOne();

            return Task.CompletedTask;
        }

        public Task HandleAsync(IBus bus, EventSagaIntermediateMessage input, TraceWriter Log)
        {
            this.Data.Counter++;

            InvocationCounter.Instance.AddOne();
            
            return Task.CompletedTask;
        }

        public Task HandleEventAsync(IBus bus, EventMessage message, TraceWriter log)
        {
            this.Data.EventReceived = true;

            return Task.CompletedTask;
        }

        public async Task<SagaData> LookForInstance(EventSagaIntermediateMessage message)
        {
            var sagaData =  await SagaPersistence.GetSagaData<EventTestSagaData>(PARTITION_KEY, message.Id.ToString());

            return sagaData;
        }

        public Task<List<SagaData>> LookForInstances(EventMessage message)
        {
            
        }
    }
}
