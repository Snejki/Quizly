using FluentAssertions;
using FluentValidation;
using NetArchTest.Rules;

namespace Quizly.Modules.Users.Tests.Architecture.Infrastructure;

public sealed class ValidatorsTests : TestBase
{
    [Fact]
    public void Validators_Should_Have_Validator_Postfix()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .Should()
            .HaveNameEndingWith("Validator")
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public void Validators_Should_Be_Public_Sealed()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .Should()
            .BeSealed()
            .And()
            .BePublic()
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public void Validators_Should_Not_Be_Outside_Validators_Assembly()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .That()
            .DoNotResideInNamespace("Quizly.Modules.Users.Infrastructure.Validators")
            .ShouldNot()
            .HaveNameEndingWith("Validator")
            .And()
            .NotInherit(typeof(AbstractValidator<>))
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public void In_Validators_Assembly_Should_be_Only_Validators()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .That()
            .ResideInNamespace("Quizly.Modules.Users.Infrastructure.Validators")
            .Should()
            .HaveNameEndingWith("Validator")
            .And()
            .Inherit(typeof(AbstractValidator<>))
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }
}