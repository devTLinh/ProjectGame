using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseMenuUI;
    public static UI instance;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI killCountText;
    private int killCount = 0;
    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }
    private void Update()
    {
        timerText.text = Time.time.ToString("F1") + "s";
    }
    public void EnableGameOverUI()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
    public void EnablePauseGameUI()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonMusic);
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }
    public void DisablePauseGameUI()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonMusic);
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }
    public void RestartLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    public void AddKillCount()
    {
        killCount++;
        killCountText.text = killCount.ToString();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
