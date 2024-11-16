using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class MoveElementToPoint : MonoBehaviour
{
    [SerializeField] private Vector2 targetPosition = Vector2.zero;
    [SerializeField] private float movementDuration = 1f;
    [SerializeField] private Ease easeType = Ease.InOutBack;

    private RectTransform objectToMove;
    private Tween vectorTween;

    private void Awake()
    {
        objectToMove = GetComponent<RectTransform>();
        if (!objectToMove)
        {
            throw new NullReferenceException("Can't find RectTransform object of element");
        }
    }

    private void Start()
    {
        vectorTween?.Kill();
        vectorTween = objectToMove.DOAnchorPos(targetPosition, movementDuration).SetEase(easeType);
    }

    private void OnDisable()
    {
        vectorTween?.Kill();
    }
}
