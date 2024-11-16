using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public abstract class MainMenuUIElement : MonoBehaviour
{
    [SerializeField] protected float animationDuration = 1f;
    [SerializeField] protected Vector2 targetPosition = Vector2.zero;
    [SerializeField] protected Ease easeType = Ease.Linear;

    protected RectTransform objectToMove;

    protected void Awake()
    {
        objectToMove = GetComponent<RectTransform>();
    }

    public abstract Tween PlayAnimation();
}
