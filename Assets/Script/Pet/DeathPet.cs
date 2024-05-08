using UnityEngine;
using UnityEngine.UI;

public class DeathPet : Pet
{
    [SerializeField] private int ammunition = 0;
    [SerializeField] private  int maxAmmunition = 3;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float ammunitionTime = 30f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform player;
    [SerializeField] private float force;
    [SerializeField] private Image image;
    [SerializeField] private Text ammunitiontxt;
    public override void Start()
    {
        maxAmmunition = maxAmmunition + level - 1;
    }
    public override void ActivateSkill()
    {
        if (ammunition >= 1)
        {
            GameObject peijectileIns= Instantiate(projectile,player.transform.position+new Vector3(0,0.5f,0),Quaternion.identity);
            peijectileIns.GetComponent<Rigidbody2D>().AddForce(player.transform.right * force, ForceMode2D.Force);
            ammunition -= 1;

        }

        
    }

    public void Update()
    {
        ammunitiontxt.text = ammunition.ToString();
        if (ammunition < maxAmmunition && timer < ammunitionTime)
        {
            image.fillAmount=timer/ammunitionTime;
            timer += Time.deltaTime;

            if (timer >= ammunitionTime)
            {
                ammunition++;
                Debug.Log("Đã tích trữ 1 viên đạn. Số lượng đạn hiện tại: " + ammunition);

                image.fillAmount = timer = 0f;
            }
        }
    }
    public override string GetSkillDescription()
    {
        return "Create a vortex to destroy enemies, accumulating once every "+ ammunitionTime+ " seconds, up to "+ maxAmmunition + " times";
    }
    public override void Restart()
    {
        ammunition = 0;
        timer = 0f;
    }
    public override void Upgrade()
    {
        maxAmmunition++;
    }
    public override void UpdateSkillAfterLoadData()
    {
        maxAmmunition = maxAmmunition + level - 1;
        GetSkillDescription();
    }
}
