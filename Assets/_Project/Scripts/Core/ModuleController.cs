using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModuleController : MonoBehaviour
{
    [SerializeField] private List<GameModule> modulesList = new();
    [SerializeField] private int maxErrors = 3;
    [SerializeField] public int currentErrors = 0;
    [SerializeField] private int correctModules = 0;
    [SerializeField] private int currentLevel;
    [SerializeField] private List<string> serialCodeByLevel = new();
    [SerializeField] private List<int> level1Lever = new List<int>();
    [SerializeField] private List<int> level2Lever = new List<int>();
    [SerializeField] private List<int> level3Lever = new List<int>();
    [SerializeField] private List<int> level1Button = new List<int>();
    [SerializeField] private List<int> level2Button = new List<int>();
    [SerializeField] private List<int> level3Button = new List<int>();
    [Header("Visuals")][Space][SerializeField] private LampIndicatorColor lampFeedback;
    [SerializeField] private List<List<int>> leverLevels;
    [SerializeField] private List<List<int>> buttonLevels;
    [SerializeField] private TextMeshProUGUI serialText;

    private void Awake()
    {
        leverLevels = new List<List<int>> { level1Lever, level2Lever, level3Lever };
        buttonLevels = new List<List<int>> { level1Button, level2Button, level3Button };

    }

    private void Start()
    {
        currentErrors = 0;
        PopulateCorrectSequences(leverLevels, buttonLevels, 0);
    }

    private void OnEnable()
    {
        foreach (var module in modulesList)
        {
            module.SequenceEvent += OnSequenceEvent;
        }

    }

    private void OnDisable()
    {
        foreach (var module in modulesList)
        {
            module.SequenceEvent -= OnSequenceEvent;
        }
    }

    private void OnSequenceEvent(bool correct)
    {
        if (correct)
            CorrectModuleDetected();
        else
            ErrorDetected();
    }

    private void ErrorDetected()
    {
        lampFeedback.IncorrectSequenceFeedback();
        Debug.Log("Error detected");
        currentErrors++;
        if (currentErrors >= maxErrors)
        {
            Debug.Log("Game over");
            GameController.Instance.ChangeScene(GameController.Scenes.Gameover);
        }

    }



    private void CorrectModuleDetected()
    {
        lampFeedback.CorrectSequenceFeedback();
        Debug.Log("Correct module detected");
        correctModules++;
        if (correctModules >= modulesList.Count)
        {
            Debug.Log("Crisis adverted.");
            currentLevel++;
            if (currentLevel < 3)
            {
                PopulateCorrectSequences(leverLevels, buttonLevels, currentLevel);
                correctModules = 0;
            }
            else if (currentLevel == 3)
            {
                GameController.Instance.ChangeScene(GameController.Scenes.MainMenu);
            }
        }
    }

    private void PopulateCorrectSequences(List<List<int>> leverLevels, List<List<int>> buttonLevels, int level)
    {
        Debug.Log($"Populating sequences for level {level}");
        serialText.SetText(serialCodeByLevel[level]);
        foreach (var module in modulesList)
        {
            if (module is GameModuleLever leverModule)
            {
                leverModule.correctSequence = leverLevels[level];
                Debug.Log($"Populated correctSequence for {module.name}");
                leverModule.currentIndex = 0;
            }
            if (module is GameModuleButtons buttonModule)
            {
                buttonModule.correctSequence = buttonLevels[level];
                Debug.Log($"Populated correctSequence for {module.name}");
                buttonModule.currentIndex = 0;
            }
        }
    }
}
