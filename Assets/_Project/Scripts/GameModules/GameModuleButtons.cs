using System.Collections.Generic;
using UnityEngine;

public class GameModuleButtons : GameModule
{
    [SerializeField] private List<GameObject> gameObjects;
    [SerializeField] private List<int> correctSequence;
    [SerializeField] private int currentIndex;

    private void Start()
    {
        if (gameObjects.Count == 0 || correctSequence.Count == 0)
        {
            Debug.LogError("The gameObjects list and the correctSequence list must not be empty.");
            return;
        }

        foreach (var gameObject in gameObjects)
            gameObject.AddComponent<Clickable>().OnClick += () =>
            {
                int index = GetGameObjectIndex(gameObject);
                Debug.Log($"GameObject clicked: {gameObject.name}, Index: {index}");
                OnGameObjectClicked(index);
            };
    }

    private int GetGameObjectIndex(GameObject gameObject)
    {
        return gameObjects.IndexOf(gameObject);
    }

    private void OnGameObjectClicked(int index)
    {
        if (correctSequence[currentIndex] == index)
        {
            Debug.Log("Correct!");
            currentIndex++;
            if (currentIndex >= correctSequence.Count)
            {
                Debug.Log("Sequence completed!");
                OnSequenceEvent(true);
                currentIndex = 0; // Reset for next sequence
            }
        }
        else
        {
            Debug.LogError("Incorrect object clicked!");
            OnSequenceEvent(false);
            currentIndex = 0; // Reset sequence on error
        }
    }
}