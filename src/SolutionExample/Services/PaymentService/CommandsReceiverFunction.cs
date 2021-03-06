using System;
using System.Threading.Tasks;
using AFBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace PaymentService
{
    public static class CommandsReceiverFunction
    {
        public static HandlersContainer container = new HandlersContainer();

        static CommandsReceiverFunction()
        {
            HandlersContainer.AddDependency<IPaymentsRepository, InMemoryPaymentsRepository>();
        }


        [FunctionName("PaymentServiceEndpointFunction")]
        public static async Task Run([QueueTrigger("paymentservice")]string myQueueItem, TraceWriter log)
        {
            log.Info($"PaymentServiceCommandReceiverFunction received a message: {myQueueItem}");

            await container.HandleAsync(myQueueItem, log);
        }
    }
}
