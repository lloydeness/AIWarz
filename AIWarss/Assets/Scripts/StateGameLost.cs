using UnityEngine;
using System.Collections;

public class StateGameLost : GameState
{
    public StateGameLost(GameManager manager) : base(manager) { }

    public override void OnStateEntered() { }
    public override void OnStateExit() { }
    public override void StateUpdate() { }
    public override void StateGUI()
    {
        GUILayout.Label("state: GAME LOST");
    }
}

public class StateGameWon : GameState
{
    public StateGameWon(GameManager manager) : base(manager) { }

    public override void OnStateEntered() { }
    public override void OnStateExit() { }
    public override void StateUpdate() { }
    public override void StateGUI()
    {
        GUILayout.Label("state: GAME WON");
    }
}
