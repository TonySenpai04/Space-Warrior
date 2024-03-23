using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public  abstract class EnemyHealthUIBase:MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI healthText;
    [SerializeField] protected Enemy enemyData;
    [SerializeField] protected float fontSize = 60;
    [SerializeField] protected Transform parent;
    [SerializeField] protected GameObject floatingText;
    [SerializeField] protected Vector3 offSet;

    public virtual void Start()
    {
        enemyData = GetComponentInParent<Enemy>();
        healthText.fontSize = fontSize;
        healthText.text = ((int)enemyData.currentHealth).ToString();
        parent = enemyData.transform;
        if (healthText == null)
        {
            Debug.LogError("Health Text reference is not set!");
        }
    }
    public virtual void FixedUpdate()
    {
        UpdateHealthText();
    }
    public virtual  void UpdateHealthText()
    {
        
    }
    public virtual void TakeDamageUI(float dam,Color color)
    {
    }

}