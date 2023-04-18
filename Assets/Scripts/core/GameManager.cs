using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("Cursor")]
    public Texture2D defaultCursor;
    public Texture2D clickCursor;

    [Header("UI")]
    [SerializeField] private TMP_Text moneyText;

    [Header("Paths")]
    [SerializeField] public List<PathNode> pathNodes;
    [SerializeField] public PathNode startNode, endNode;

    [Header("Towers")]
    public List<GameObject> towers;
    [SerializeField] public GameObject towerPrefab;

    [Header("enemies")]
    public List<GameObject> enemies;
    [SerializeField] private GameObject normalEnemy;

    [Header("Timer")]
    [SerializeField] private float minTime = 0.2f;
    [SerializeField] private float maxTime = 2f;
    private float timer = 1;

    [Header("Player")]
    [SerializeField] public int money = 120;
    [SerializeField] public int health = 5;

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    private void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) TimerRunOut();
    }

    void Update()
    {
        moneyText.text = money + "";
        Timer();
        if (health <= 0) GameOver();
    }

    private void GameOver()
    {

    }

    private void TimerRunOut()
    {
        SpawnEnemy();
        timer = Random.Range(minTime, maxTime);
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(normalEnemy);
        enemy.transform.parent = this.gameObject.transform;
        enemies.Add(enemy);
    }
}