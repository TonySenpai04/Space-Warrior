using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthUI : EnemyHealthUIBase
{


    public override void Start()
    {
      base.Start();
    }
    public override void FixedUpdate()
    {
       base.FixedUpdate();
    }
    public override void UpdateHealthText()
    {
        if (parent.transform.localScale.x < 0)
        {
            healthText.rectTransform.localScale = new Vector3(-0.01f,0.01f,1);
        }
        healthText.text = ((int)enemyData.currentHealth).ToString();
    }
    public override void TakeDamageUI(float dam, Color color)
    {
       StartCoroutine( DisplayAndRiseText(dam,color));
    }
    private IEnumerator DisplayAndRiseText(float damage,Color color)
    {
        GameObject floatingTextInstance = Instantiate(floatingText, transform.position + Vector3.up * 2f, Quaternion.identity);


        TextMesh textMesh = floatingTextInstance.GetComponent<TextMesh>();
        if (textMesh != null)
        {
            textMesh.text = ((int)damage).ToString();
            textMesh.color = color;
        }

        yield return new WaitForSeconds(0f);
        float startY = floatingTextInstance.transform.position.y;
        float targetY = startY + 0.5f;
        if (floatingTextInstance != null)
        {
            while (floatingTextInstance.transform.position.y < targetY)
            {
                float newY = floatingTextInstance.transform.position.y + 1f * Time.deltaTime;
                floatingTextInstance.transform.position = new Vector3(floatingTextInstance.transform.position.x, newY, floatingTextInstance.transform.position.z);
                yield return null;
            }
        }
        

    }
}
