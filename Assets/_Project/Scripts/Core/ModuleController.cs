using System.Collections.Generic;
using UnityEngine;

public class ModuleController : MonoBehaviour
{
    [SerializeField] private List<int> modulesList = new();

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

        }
    }

    private void OnDisable()
    {
        foreach (var module in modulesList)
        {

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

    }

    private void CorrectModuleDetected()
    {

    }
}
