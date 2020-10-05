using EventStore.ClientAPI;
using System;
using System.Text;

namespace EventStoreConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = EventStoreConnection.Create("ConnectTo=tcp://admin:changeit@127.0.0.1:1113;UseSslConnection=false", "test-conn");
            conn.ConnectAsync().Wait();

            var streamName = "TestItem+3e93748f-d625-46c8-9574-588e81b03698";
            var eventType = "event-type";
            var data = "{ \"a\":\"2\"}";
            var metadata = "{}";
            var eventPayload = new EventData(Guid.NewGuid(), eventType, true, Encoding.UTF8.GetBytes(data), Encoding.UTF8.GetBytes(metadata));
            conn.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventPayload).Wait();
        }
    }
}
