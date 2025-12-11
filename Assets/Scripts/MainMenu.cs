using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuLevel;
    [SerializeField] private GameObject menuName;
    public void EnableMenuLevel()
    {
        menuName.SetActive(false);
        menuLevel.SetActive(true);
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
