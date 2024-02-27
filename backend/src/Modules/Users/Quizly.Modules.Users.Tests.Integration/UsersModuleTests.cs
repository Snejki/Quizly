using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Modules.Users.Infrastructure.DAL;
using Quizly.Shared.Tests.Integration;
using Xunit;

namespace Quizly.Modules.Users.Tests.Infrastructure;

public abstract class UsersModuleTests : ModuleTests<UsersDbContext>
{
}