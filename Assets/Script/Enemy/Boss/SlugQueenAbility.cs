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
        float skillCooldown, Transform owner)
    {
        this.minionPrefab = minionPrefab;
        player =Object.FindAnyObjectByType<PlayerController>().transform;
        this.skillCooldown = skillCooldown;
        this.owner = owner;
    }

    public void ActiveSkill()
    {
        float distance = owner.transform.position.x - player.transform.position.x;
        if (distance <= 8)
        {
            if (timer >= skillCooldown)
            {
                minionInstance =Object.Instantiate(minionPrefab.gameObject);

                minionInstance.transform.SetParent(owner.transform);
                minionInstance.transform.position = new Vector3(owner.transform.position.x - 2, owner.transform.position.y, owner.transform.position.z);
                timer = 0;
            }
            if (minionInstance != null)
            {
                if (minionInstance.transform.position.x >= owner.transform.position.x)
                {

                    Object.Destroy(minionInstance);
                   owner.GetComponent<Enemy>().currentHealth += 100;
                }

            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}