using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuLevel;
    [SerializeField] private GameObject menuName;
    [SerializeField] private GameObject tutorial;
    public void EnableMenuLevel()
    {
        menuName.SetActive(false);
        menuLevel.SetActive(true);
    }
    public void EnableTutorial()
    {
        menuName.SetActive(false);
        tutorial.SetActive(true);
    }
    public void BackToMainMenu()
    {
        tutorial.SetActive(false);
        menuName.SetActive(true);
    }
    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
