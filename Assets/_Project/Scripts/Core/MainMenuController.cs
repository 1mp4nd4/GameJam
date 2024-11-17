using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        GameController.Instance.ChangeScene(GameController.Scenes.Gameplay);
    }

    public void QuitGame()
    {
        GameController.Instance.QuitGame();
    }
}
