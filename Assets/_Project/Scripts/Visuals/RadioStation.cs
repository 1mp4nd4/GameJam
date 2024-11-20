using UnityEngine;

public class RadioStation : MonoBehaviour
{
    [SerializeField] private RadioButton[] radioButtons;
    [SerializeField] private AudioSource musicSource;

    private int selectedIndex;

    private void Start()
    {
        selectedIndex = -1;
        radioButtons[0].PressButton();
        UpdateButtonSprites(0);
    }

    private void OnEnable()
    {
        for (int i = 0; i < radioButtons.Length; i++)
        {
            int index = i;
            radioButtons[i].OnClick += clip =>
            {
                ChangeRadioStation(clip, index);
                UpdateButtonSprites(index);
            };
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < radioButtons.Length; i++)
        {
            int index = i;
            radioButtons[i].OnClick -= clip =>
            {
                ChangeRadioStation(clip, index);
                UpdateButtonSprites(index);
            };
        }
    }

    private void ChangeRadioStation(AudioClip clipToPlay, int index)
    {
        if(selectedIndex != index)
        {
            selectedIndex = index;
            musicSource.Stop();
            musicSource.clip = clipToPlay;
            musicSource.Play();

            Debug.Log($"Button {index} selected. Playing clip: {clipToPlay.name}");
        }
    }

    private void UpdateButtonSprites(int pressedIndex)
    {
        for (int i = 0; i < radioButtons.Length; i++)
        {
            if (i != pressedIndex)
            {
                radioButtons[i].ReleaseButton();
            }
        }
    }
}
