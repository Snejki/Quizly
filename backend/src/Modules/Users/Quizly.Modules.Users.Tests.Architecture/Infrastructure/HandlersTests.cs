using FluentAssertions;
using MediatR;
using NetArchTest.Rules;
using Quizly.Modules.Users.Infrastructure;

namespace Quizly.Modules.Users.Tests.Architecture.Infrastructure;

public sealed class HandlersTests : TestBase
{
    [Fact]
    public void CommandAndQueryHandlers_Should_Have_CommandHandler_Or_QueryHandler_Postfix()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .That()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Or()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .Or()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public void CommandAndQueryHandlers_Should_Be_Sealed()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .That()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Or()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Should()
            .BeSealed()
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public void CommandAndQueryHandlers_Should_Be_Internal()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .That()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Or()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Should()
            .NotBePublic()
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public void CommandHandlers_Should_Be_Only_In_Commands_Namespace()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .That()
            .DoNotResideInNamespaceStartingWith("Quizly.Modules.Users.Infrastructure.Commands")
            .ShouldNot()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public void QueryHandlers_Should_Be_Only_In_Queries_Namespace()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .That()
            .DoNotResideInNamespaceStartingWith("Quizly.Modules.Users.Infrastructure.Queries")
            .ShouldNot()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }
}