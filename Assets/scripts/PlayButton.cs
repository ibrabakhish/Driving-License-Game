using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private MainMenuController mainMenuController;

    void Start()
    {
        mainMenuController = GetComponentInParent<MainMenuController>();
        Button playButton = GetComponent<Button>();

        // Add a listener to the Play button
        playButton.onClick.AddListener(PlayGame);
    }

    void PlayGame()
    {
        // Call the PlayGame method in the MainMenuController
        mainMenuController.PlayGame();
        Debug.Log("Salam");
    }
}
