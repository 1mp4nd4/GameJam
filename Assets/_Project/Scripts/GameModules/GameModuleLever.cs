using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameModuleLever : GameModule
{
    [SerializeField] private List<GameObject> gameObjects;
    [SerializeField] public List<int> correctSequence;
    [SerializeField] private int currentIndex;
    //private Animator _animator;

    [Header("Lever animation")]
    [SerializeField] private RectTransform leverTransform;
    [SerializeField] private float animationSpeed = 0.5f;
    [SerializeField] private Ease animationEase = Ease.OutBack;

    private Sequence leverSequence;


    private void Start()
    {
        foreach (var gameObject in gameObjects)
        {
            //gameObject.AddComponent<HoverAnim>();
            gameObject.AddComponent<Clickable>().OnClick += () =>
            {
                int index = GetGameObjectIndex(gameObject);
                Debug.Log($"GameObject clicked: {gameObject.name}, Index: {index}");
                OnGameObjectClicked(index);
            };
        }
    }

    private void OnDisable()
    {
        leverSequence?.Kill();
    }

    private int GetGameObjectIndex(GameObject gameObject)
    {
        return gameObjects.IndexOf(gameObject);
    }

    private void OnGameObjectClicked(int index)
    {
        int ypos = index == 1 ? -1 : 1;
        MoveLeverGraphic(ypos);

        //if (index == 0 || index == 1)
        //{
        //   MoveLeverGraphic(-1f);
        //}
        //else
        //{
        //    MoveLeverGraphic(1f);
        //}
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

    //Use this method with values 1f for up, -1f for down, it'll reset automatically.
    //Ideally we should disable the clicking part when the lever is moved so it doesn't repeat the animation but just in case
    //I've made it so the animation resets before starting. If this is not desired, remove the "true" when doing "leverSequence?.Kill(true);"
    private void MoveLeverGraphic(float ypos)
    {

        leverSequence?.Kill(true);
        leverSequence = DOTween.Sequence();
        leverSequence.Append(leverTransform.DOAnchorPosY(ypos, animationSpeed)).AppendInterval(2f).Append(leverTransform.DOAnchorPosY(0f, animationSpeed)).SetEase(animationEase);
        leverSequence.Play();
    }


    //public class HoverAnim : MonoBehaviour
    //{
    //    private Animator animator;
    //    void Awake()
    //    {
    //        animator = GetComponent<Animator>();
    //        if (animator == null)
    //        {
    //            Debug.LogError("Animator component not found on the GameObject.");
    //        }
    //    }
        
    //    void OnMouseOver()
    //    {
    //        animator.SetBool("Hover", true);
    //    }

    //    void OnMouseExit()
    //    {
    //        animator.SetBool("Hover", false);
    //        if (animator.GetBool("HasClicked"))
    //        {
    //            animator.SetBool("HasClicked", false);
    //        }
    //    }

    //    private void OnMouseDown()
    //    { 
    //        animator.SetTrigger("Press");
    //        animator.SetBool("HasClicked", true);
    //    }
        
    //}

}