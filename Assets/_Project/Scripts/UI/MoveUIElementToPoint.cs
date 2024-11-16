using UnityEngine;
using DG.Tweening;

public class MoveUIElementToPoint : MainMenuUIElement
{
    private Tween moveTween;

    private void OnDisable()
    {
        moveTween?.Kill(true);
    }

    public override Tween PlayAnimation()
    {
        moveTween?.Kill();
        moveTween = objectToMove.DOAnchorPos(targetPosition, animationDuration).SetEase(easeType);
        return moveTween;
    }
}
