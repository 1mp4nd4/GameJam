using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        GameController.Instance.ChangeScene(GameController.Scenes.Testing);
    }

    public void QuitGame()
    {
        GameController.Instance.QuitGame();
    }
}
