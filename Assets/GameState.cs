using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    //Event is triggered after the switch state
    public static event Action<GameState> OnGameStateChanged;

    public enum GameState
    {
        intro,
        error,
        lose,
        win
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        
        switch(newState)
        {
            //Main menu
            case GameState.intro:
                throw new NotImplementedException();
                break;
            //Loses lives, checks for lose state
            case GameState.error:
                throw new NotImplementedException();
                break;
            //Plays losescreen, resets scene to intro
            case GameState.lose:
                throw new NotImplementedException();
                break;
            //Plays winscreen, resets scene to intro
            case GameState.win:
                throw new NotImplementedException();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
        //Subscribe on Awake -> GameManager.OnGameStateChanged += my_function ->
        //DONT FORGET TO UNSUBSCRIBE on Destroy -> GameManager.OnGameStateChanged -= my_function
    }

    

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateGameState(GameState.intro);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
