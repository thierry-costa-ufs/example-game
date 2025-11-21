using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayClicked()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.StartGame();
        }
    }

    public void OnQuitClicked()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.QuitGame();
        }
    }
}
