using System.Collections.Generic;
using UnityEngine;

public class ModuleController : MonoBehaviour
{
    [SerializeField] private List<GameModule> modulesList = new();

    [SerializeField] private int maxErrors = 3;
    private int currentErrors = 0;

    private int correctModules = 0;

    private void Start()
    {
        currentErrors = 0;
    }

    private void OnEnable()
    {
        foreach (var module in modulesList)
        {
            module.SequenceEvent += ModuleCheck;
        }
    }

    private void OnDisable()
    {
        foreach (var module in modulesList)
        {
            module.SequenceEvent -= ModuleCheck;
        }
    }

    private void ModuleCheck(bool correct)
    {
        if (correct)
            CorrectModuleDetected();
        else
            ErrorDetected();
    }

    private void ErrorDetected()
    {
        Debug.Log("Error detected");
        currentErrors++;
        if (currentErrors >= maxErrors)
            Debug.Log("Game over");
    }

    private void CorrectModuleDetected()
    {
        Debug.Log("Correct module detected");
        correctModules++;
        if (correctModules >= modulesList.Count)
            Debug.Log("Crisis adverted. You won");
    }
}
