using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 10;
    [SerializeField] public float movSpeed = 10;
    [SerializeField] private float destinationOffset = 0.1f;
    [SerializeField] public int moneyDrop = 12;
    protected PathNode currentPathNode;

    private void Start()
    {
        currentPathNode = GameManager.Instance.startNode;
        SetNextPathNode();
    }

    protected void MoveToCurrentNode()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPathNode.transform.position, movSpeed * Time.deltaTime);
    }

    protected void SetNextPathNode()
    {
        int nextRandInt = Random.Range(0, currentPathNode.nextNodes.Count);
        currentPathNode = currentPathNode.nextNodes[nextRandInt];
    }

    protected bool IsOnDestination(Vector3 destination)
    {
        return Vector3.Distance(transform.position, destination) <= destinationOffset;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}