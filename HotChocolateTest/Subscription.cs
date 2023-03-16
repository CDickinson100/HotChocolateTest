using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace HotChocolateTest;

public class Subscription
{
    public ValueTask<ISourceStream<Data>> SubscribeToPositionStream([Service] ITopicEventReceiver receiver)
    {
        return receiver.SubscribeAsync<Data>("topic");
    }

    [Subscribe(With = nameof(SubscribeToPositionStream))]
    public Data PositionStream([EventMessage] Data pricedPosition)
    {
        return pricedPosition;
    }
}