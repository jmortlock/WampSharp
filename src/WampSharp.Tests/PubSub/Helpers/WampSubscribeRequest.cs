using WampSharp.V1.Core.Contracts.V1;

namespace WampSharp.Tests.PubSub.Helpers
{
    public class WampSubscribeRequest<TMessage>
    {
        public IWampPubSubClient<TMessage> Client { get; set; }
        public string TopicUri { get; set; }
    }
}