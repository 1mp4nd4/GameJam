using System.Collections.Generic;
using UnityEngine;

public class LifeSubscribe : MonoBehaviour
{
    private ModuleController moduleController;
    [SerializeField] private List<GameModule> modulesList = new();
    [SerializeField] private float Errors;
    private Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        foreach (var module in modulesList)
        {
            module.SequenceEvent += OnSequenceEvent;
        }
    }

    private void OnSequenceEvent(bool correct)
    {
        if (!correct)
            ErrorDetected();
    }

    private void ErrorDetected()
    {
        Debug.Log("Error detected");
        Errors++;
        animator.SetFloat("currentErrors", Errors);
    }

    private void OnDisable()
    {
        foreach (var module in modulesList)
        {
            module.SequenceEvent -= OnSequenceEvent;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}