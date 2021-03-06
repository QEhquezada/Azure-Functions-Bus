﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFBus
{
    public interface IBus
    {
        /// <summary>
        /// Sends a message to a queue named like the service.
        /// </summary>
        Task SendAsync<T>(T input, string serviceName, TimeSpan? initialVisibilityDelay = null) where T : class;

        Task PublishAsync<T>(T input, string topic, TimeSpan? initialVisibilityDelay = null) where T : class;

        ISerializeMessages Serializer { get; }

        AFBusMessageContext Context { get; set; }
    }
}
