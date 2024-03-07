using System.Collections.Concurrent;
using Quizly.Modules.Quizes.Application;

namespace Quizly.Modules.Quizes.Infrastructure;

public class GameLobby
{
    // todo: redis??
    // todo: concurrent dictionary ale tylko z userem i userid i category
    private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, AwaitingPlayer>> _awaitingPlayers = new();
    private readonly ConcurrentDictionary<string, AwaitingPlayer> _players = new();

    public GameLobby()
    {
    }

    public async Task SearchGame(string userId, AwaitingPlayer awaitingPlayer)
    {
        if (!_awaitingPlayers.ContainsKey(awaitingPlayer.CategoryId))
        {
            _awaitingPlayers.TryAdd(awaitingPlayer.CategoryId, new ConcurrentDictionary<string, AwaitingPlayer>());
        }

        if (_awaitingPlayers[awaitingPlayer.CategoryId].ContainsKey(awaitingPlayer.UserId))
        {
            return;
        }

        if (_awaitingPlayers[awaitingPlayer.CategoryId].Any())
        {
            var player = _awaitingPlayers[awaitingPlayer.CategoryId].First();
            if (_awaitingPlayers[awaitingPlayer.CategoryId].TryRemove(player))
            {
                // todo: start game
            }
        }
        else
        {
            _awaitingPlayers[awaitingPlayer.CategoryId].TryAdd(awaitingPlayer.UserId, awaitingPlayer);
            _players.TryAdd(userId, awaitingPlayer);
        }
    }

    public async Task StopSearchingGame(string userId)
    {
        if (_players.TryGetValue(userId, out var player))
        {
            _awaitingPlayers[player.CategoryId].TryRemove(player.CategoryId, out player);
        }
    }
}