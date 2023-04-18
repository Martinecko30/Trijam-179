using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Tower : MonoBehaviour
{
    [SerializeField] public static int[] prices = { 40, 100, 250 };

    [SerializeField] public int level = 1;
    [SerializeField] public int damage = 2;

    [SerializeField] private Sprite[] sprites;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float destinationOffset = 0.2f;

    public List<GameObject> bullets;
    private GameObject target;
    [SerializeField] private float bulletSpeed = 15;

    private SpriteRenderer spriteRenderer;

    [Header("Timer")]
    private float defTime = 1f;
    private float timer = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Timer();
        if (target == null || Vector3.Distance(transform.position, target.transform.position) > 20)
            foreach (var enemy in GameManager.Instance.enemies)
                if (Vector3.Distance(transform.position, enemy.transform.position) <= 4)
                    target = enemy;

        foreach (GameObject bullet in bullets) {
            if(Vector3.Distance(bullet.transform.position, target.transform.position) <= destinationOffset) {
                bullets.Remove(bullet);
                target.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(bullet);
            }
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        }
    }

    private void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) TimerRunOut();
    }

    private void TimerRunOut()
    {
        Shoot();
        timer = defTime;
    }

    private void Shoot()
    {
        if (target == null) return;
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.parent = transform.parent;
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        bullets.Add(bullet);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.money < prices[level]) return;

            if (level >= 3) return;

            level += 1;
            damage += 2;
            spriteRenderer.sprite = sprites[level-1];

            GameManager.Instance.money -= prices[level - 1];
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Ahoj!");
            GameManager.Instance.money += 20;
            GameManager.Instance.towers.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(GameManager.Instance.clickCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(GameManager.Instance.defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}