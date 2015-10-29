//GameState .cs
using UnityEngine;
using System.Collections;
public abstract class GameState //:MonoBehviour
{
    protected GameManager gameManager;
    public GameState(GameManager manager)
    {
        gameManager = manager;
    }

    public abstract void OnStateEntered();
    public abstract void OnStateExit();
    public abstract void StateUpdate();
    public abstract void StateGUI();
}
