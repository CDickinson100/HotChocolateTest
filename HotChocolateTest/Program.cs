using HotChocolateTest;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

builder.Services.AddHostedService<Background>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGraphQL();
app.UseWebSockets();

app.Run();