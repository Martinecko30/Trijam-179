using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    int currentSprite = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine("BulletLifeCoroutine");
    }

    private IEnumerator BulletLifeCoroutine()
    {
        spriteRenderer.sprite = sprites[currentSprite];
        currentSprite += 1;
        Mathf.Clamp(currentSprite, 0, sprites.Length-1);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("BulletLifeCoroutine");
    }
}
