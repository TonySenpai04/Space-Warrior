using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Enemy enemyData;
    [SerializeField] private float fontSize=60;
    [SerializeField] private Transform parent;

    private void Start()
    {
        enemyData = GetComponentInParent<Enemy>();
        healthText.fontSize = fontSize;
        healthText.text =((int)enemyData.currentHealth).ToString();
        parent= enemyData.transform;
        if (healthText == null)
        {
            Debug.LogError("Health Text reference is not set!");
        }
    }
    private void FixedUpdate()
    {
        UpdateHealthText();
    }
    public void UpdateHealthText()
    {
        if (parent.transform.localScale.x < 0)
        {
            healthText.rectTransform.localScale = new Vector3(-0.01f,0.01f,1);
        }
        healthText.text = ((int)enemyData.currentHealth).ToString();
    }
}
