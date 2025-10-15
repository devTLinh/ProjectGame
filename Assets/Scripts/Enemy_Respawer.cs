using UnityEngine;

public class Enemy_Respawer : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] respawnPoints;
    [SerializeField] private float cooldown = 3f;
    [Space]
    [SerializeField] private float cooldownDecreaseRate = .01f;
    [SerializeField] private float cooldownCap = .7f;
    private float timer;
    private Transform player;
    private void Awake()
    {
        player = FindFirstObjectByType<Player>().transform;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = cooldown;
            CreateNewEnemy();
            cooldown = Mathf.Max(cooldown - cooldownDecreaseRate, cooldownCap);
        }
    }
    private void CreateNewEnemy()
    {
        int respawnPointIndex = Random.Range(0, respawnPoints.Length);
        Vector3 spawnPosition = respawnPoints[respawnPointIndex].position;
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        if (player.position.x < spawnPosition.x)
            newEnemy.GetComponent<Enemy>().Flip();
    }

}
