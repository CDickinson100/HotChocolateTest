using HotChocolate.Subscriptions;

namespace HotChocolateTest;

public class Background : BackgroundService
{
    private readonly ITopicEventSender _topicEventSender;

    public Background(ITopicEventSender topicEventSender)
    {
        _topicEventSender = topicEventSender;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _topicEventSender.SendAsync("topic", new Data("Hello World!"), stoppingToken);
            await Task.Delay(100, stoppingToken);
        }
    }
}