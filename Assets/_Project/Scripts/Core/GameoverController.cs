using UnityEngine;

public class GameoverController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        GameController.Instance.ChangeScene(GameController.Scenes.MainMenu);
    }
}
