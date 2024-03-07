using Quizly.Modules.Quizes.Application;

namespace Quizly.Modules.Quizes.Infrastructure;
using Microsoft.AspNetCore.SignalR;

public class QuizHub : Hub
{
    private readonly GameLobby _gameLobby;

    public QuizHub(GameLobby gameLobby)
    {
        _gameLobby = gameLobby;
    }

    public async Task SearchGame(AwaitingPlayer awaitingPlayer)
    {
        await _gameLobby.SearchGame(Context.UserIdentifier!, awaitingPlayer);
    }

    public async Task StopSearchingGame()
    {
        await _gameLobby.StopSearchingGame(Context.UserIdentifier!);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await _gameLobby.StopSearchingGame(Context.UserIdentifier!);
        await base.OnDisconnectedAsync(exception);
    }
}