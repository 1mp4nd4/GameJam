using UnityEngine;
using DG.Tweening;

public class LampIndicatorColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color correctColor;
    [SerializeField] private Color incorrectColor;
    [SerializeField] private float animationDuration = 0.5f;

    private Sequence colorSequence;

    private void OnDisable()
    {
        colorSequence?.Kill(true);
    }

    public void CorrectSequenceFeedback()
    {
        Debug.Log("test2");
        ChangeColor(correctColor);
    }

    public void IncorrectSequenceFeedback()
    {
        ChangeColor(incorrectColor);
    }

    private void ChangeColor(Color color)
    {
        colorSequence?.Kill(true);
        colorSequence = DOTween.Sequence();
        colorSequence.Append(sr.DOColor(color, animationDuration)).AppendInterval(1f).Append(sr.DOColor(Color.white, animationDuration));
        colorSequence.Play();
    }
}
