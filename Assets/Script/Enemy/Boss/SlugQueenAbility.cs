using UnityEngine;

internal class SlugQueenAbility : ISkillBoss
{
    private Enemy minionPrefab;
    private float timer;
    private float skillCooldown;
    private GameObject minionInstance;
    private Transform player;
    private Transform owner;
    public SlugQueenAbility(Enemy minionPrefab,
        float skillCooldown, Transform owner, Transform player)
    {
        this.minionPrefab = minionPrefab;
        this.player = player;
        this.skillCooldown = skillCooldown;
        this.owner = owner;
    }

    public void ActiveSkill()
    {
        float distance = owner.transform.position.x - player.transform.position.x;
        if (distance <= 8)
        {
            timer += Time.deltaTime;
            if (timer >= skillCooldown)
            {
                minionInstance =Object.Instantiate(minionPrefab.gameObject);
                minionInstance.GetComponent<Minion>().owner = this.owner;
                minionInstance.GetComponent<Enemy>().health=owner.GetComponent<Enemy>().health/20;
                minionInstance.GetComponent<Enemy>().currentHealth = minionInstance.GetComponent<Enemy>().health;
                minionInstance.transform.SetParent(owner.transform);
                minionInstance.transform.position = new Vector3(owner.transform.position.x - 2, owner.transform.position.y, owner.transform.position.z);
                timer = 0;
            }
            if (minionInstance == null)
            {
                

            }
            
        }
    }
}