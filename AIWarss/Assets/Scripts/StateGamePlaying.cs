﻿using UnityEngine;
using System.Collections;

public class StateGamePlaying : GameState
{
    private bool isPaused = false;

    public StateGamePlaying(GameManager manager) : base(manager) { }

    public override void OnStateEntered() { }
    public override void OnStateExit() { }
    public override void StateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGameMode();
            }
            else
            {
                PauseGameMode();
            }
        }
    }
    public override void StateGUI()
    {
        if (isPaused)
        {
            string[] names = QualitySettings.names;
            string message = "Game Paused. Press ESC to resume or select a new quality setting below.";
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.Label(message, GUILayout.Width(200));
            for (int i = 0; i < names.Length; i++)
            {
                if (GUILayout.Button(names[i], GUILayout.Width(200)))
                {
                    QualitySettings.SetQualityLevel(i, true);
                }
            }
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.EndArea();
        }
        else
        {
            GUILayout.Label("state: GAME PLAYING");
            if (GUILayout.Button("WIN the game"))
            {
                gameManager.NewGameState(gameManager.stateGameWon);
            }
            if (GUILayout.Button("LOSE the	game"))
            {
                gameManager.NewGameState(gameManager.stateGameLost);
            }
        }
    }

    private void ResumeGameMode()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    private void PauseGameMode()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
    }
}


