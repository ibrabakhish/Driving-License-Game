using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        // Attach the button click event listener
        startButton.onClick.AddListener(StartScene);
    }

    // Function to be called when the button is clicked
    void StartScene()
    {
        // Change the scene here
        Debug.Log("Ssalam");
        SceneManager.LoadScene("MainScene");
    }
}
