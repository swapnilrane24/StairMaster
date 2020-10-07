using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Script which control UI logic
/// </summary>
public class UIManager : MonoBehaviour
{
    //Reference to the menu panels
    //We make them SerializeField as we want to edit the private variable from Inspector
    [SerializeField] private GameObject mainMenu, gameoverManu;
    //Reference to GameManager
    [SerializeField] private GameManager gameManager;

    //Method called when Play button is pressed
    public void PlayButton()
    {
        //we set the gameStatus to playing
        gameManager.gameStatus = GameStatus.Playing;
        //and deactivate the mainmenu
        mainMenu.SetActive(false);
    }

    //Method called when Restart button is pressed
    public void RestartButton()
    {
        //Reload the same level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //method called when game is over
    public void GameIsOver()
    {
        //activate the game over menu
        gameoverManu.SetActive(true);
    }
}
