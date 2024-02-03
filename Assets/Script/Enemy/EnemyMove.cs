using UnityEngine;

internal class EnemyMove : IMove
{
    private float speed;
    private GameObject enemy;
    public EnemyMove(float speed, GameObject enemy)
    {
        this.speed = speed;
        this.enemy = enemy;
    }

    public void Move()
    {
        enemy.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}