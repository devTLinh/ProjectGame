using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
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
}
