using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] private List<MainMenuUIElement> uiElements = new();

    private Sequence animationSequence;

    private void Start()
    {
        animationSequence = DOTween.Sequence();
        //Debug.Break();
        //StartAnimationSequence();
    }

    private void StartAnimationSequence()
    {
        foreach (MainMenuUIElement uiElement in uiElements) 
        {
            Tween tween = uiElement.PlayAnimation();
            animationSequence.Insert(0, tween);
        }
        animationSequence.Play();
    }
}
