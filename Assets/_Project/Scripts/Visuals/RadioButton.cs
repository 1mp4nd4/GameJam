using System;
using UnityEngine;

public class RadioButton : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip radioSong;
    [Header("Visual")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite pressedSprite;

    public event Action<AudioClip> OnClick;

    private void OnMouseDown()
    {
        PressButton();
    }

    public void PressButton()
    {
        OnClick?.Invoke(radioSong);
        ChangeSprite(pressedSprite);
    }

    public void ReleaseButton()
    {
        ChangeSprite(defaultSprite);
    }

    private void ChangeSprite(Sprite sprite)
    {
        sr.sprite = sprite;
    }
}
