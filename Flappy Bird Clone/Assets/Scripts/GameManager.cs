using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// These are the states for this game.
public enum GameState
{
    TitleScreen, Game, GameOverScreen
}

public class GameManager : MonoBehaviour
{
    public static GameManager current { get; private set; }
    public static GameState state { get; private set; } = GameState.TitleScreen;

    private void Awake() 
    {
        // Check that the instance for GameManager exists, if not set to this class.
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(gameObject);
        } else {
            DestroyImmediate(gameObject);
        }
    }

    public void StartGame()
    {
        // Change the game state so we know we're playing.
        state = GameState.Game;

        // Enable control for the player.
        FindObjectOfType<FlapControl>().Activate();

        // Start the pipe spawning.
        FindObjectOfType<PipeManager>().Spawn();

        // Disable the title screen.
        GameObject.Find("GetReady").SetActive(false);
    }

    public void StopGame()
    {
        // Change the game state so we kknow we lost.
        state = GameState.GameOverScreen;

        // Disable all the colliders on the pipes.
        FindObjectOfType<PipeManager>().Disable();

        // Show the game over UI.
        GameObject.Find("GameOver").SetActive(true);
    }
}
