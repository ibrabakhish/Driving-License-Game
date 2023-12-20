using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Method to be called when the Play button is clicked
    public void PlayGame()
    {
        // Replace "LevelName" with the actual name of your level scene
        SceneManager.LoadScene("MainScene");
    }
}
