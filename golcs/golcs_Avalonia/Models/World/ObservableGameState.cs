using CommunityToolkit.Mvvm.ComponentModel;

namespace golcs.Models.World;

public class ObservableGameState : ObservableObject   
{
    private readonly GameState gamestate;

    public ObservableGameState(GameState gamestate) => this.gamestate = gamestate;

    public int High_score
    {
        get => gamestate.high_score;
        //I don't get this shit, send help
        set => SetProperty(gamestate.high_score, value, gamestate, (state, score) => state.high_score = score);
    }
}
