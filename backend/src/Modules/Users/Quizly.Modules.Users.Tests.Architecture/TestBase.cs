using System.Reflection;
using Quizly.Modules.Users.Infrastructure;

namespace Quizly.Modules.Users.Tests.Architecture;

public abstract class TestBase
{
    protected static Assembly InfrastructureAssembly => typeof(UsersInfrastructure).Assembly;
}