using Microsoft.AspNetCore.Routing;

namespace Quizly.Shared.Abstractions.Endpoints;

public interface IEndpoint
{
    public void UseEndpoints(IEndpointRouteBuilder app);
}