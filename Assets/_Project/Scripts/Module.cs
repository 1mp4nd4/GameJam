using System.Collections.Generic;
using UnityEngine;

public class SequenceChecker : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;
    [SerializeField] private List<int> correctSequence;

    private int currentIndex = 0;

    private void Start()
    {
        if (gameObjects.Count == 0 || correctSequence.Count == 0)
        {
            Debug.LogError("The gameObjects list and the correctSequence list must not be empty.");
            return;
        }

        for (int i = 0; i < gameObjects.Count; i++)
        {
            int index = i; // Capture the current index 
            gameObjects[i].AddComponent<BoxCollider>(); // Ensure the GameObject has a collider
            gameObjects[i].AddComponent<Clickable>().OnClick += () => OnGameObjectClicked(index);
        }
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
                currentIndex = 0; // Reset for next sequence
            }
        }
        else
        {
            Debug.LogError("Incorrect object clicked!");
            currentIndex = 0; // Reset sequence on error
        }
    }
}

public class Clickable : MonoBehaviour
{
    public delegate void ClickAction();
    public event ClickAction OnClick;

    private void OnMouseDown()
    {
        OnClick?.Invoke();
    }
}