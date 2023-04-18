public class NormalEnemy : Enemy
{
    private void Start()
    {
        currentPathNode = GameManager.Instance.startNode;
        transform.position = currentPathNode.transform.position;
        SetNextPathNode();
    }

    private void FixedUpdate()
    {
        if(health <= 0)
        {
            GameManager.Instance.money += moneyDrop;
            GameManager.Instance.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }

        if (currentPathNode == GameManager.Instance.endNode && IsOnDestination(GameManager.Instance.endNode.transform.position))
        {
            GameManager.Instance.health -= 1;
            GameManager.Instance.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }

        MoveToCurrentNode();

        if (IsOnDestination(currentPathNode.transform.position))
            SetNextPathNode();
    }
}