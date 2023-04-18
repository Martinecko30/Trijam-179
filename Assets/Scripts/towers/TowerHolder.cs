using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour
{
    void OnMouseEnter()
    {
        Cursor.SetCursor(GameManager.Instance.clickCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(GameManager.Instance.defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.money < Tower.prices[0]) return;

            if (transform.childCount >= 1) return;

            GameObject tower = Instantiate(GameManager.Instance.towerPrefab);
            tower.transform.parent = transform;
            tower.transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z-0.1f);
            GameManager.Instance.towers.Add(tower);

            GameManager.Instance.money -= Tower.prices[0];
        }
    }
}
