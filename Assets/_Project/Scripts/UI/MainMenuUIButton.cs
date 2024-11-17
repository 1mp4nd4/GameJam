using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuUIButton : MonoBehaviour
{
    [SerializeField] private Image graphic;
    [SerializeField] private TextMeshProUGUI text;

    public void OnPointerDown(Sprite sprite)
    {
        ChangeSprite(sprite);
        Vector3 v = text.transform.localPosition;
        v.y = 1;
        text.transform.localPosition = v;
        text.color = Color.black;
    }

    public void OnPointerUp(Sprite sprite)
    {
        ChangeSprite(sprite);
        Vector3 v = text.transform.localPosition;
        v.y = 13.6f;
        text.transform.localPosition = v;
        text.color = Color.white;
    }

    private void ChangeSprite(Sprite sprite)
    {
        graphic.sprite = sprite;
    }
}
