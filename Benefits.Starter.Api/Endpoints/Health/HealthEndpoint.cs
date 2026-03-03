using FastEndpoints;

namespace Benefits.Starter.Api.Endpoints.Health
{
    public sealed class HealthEndpoint : EndpointWithoutRequest<string>
    {
        public override void Configure()
        {
            Get("/health");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await Send.OkAsync("ok", ct);
        }
    }
}
