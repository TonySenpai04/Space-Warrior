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
    public override void TakeDamageUI(float dam)
    {
       StartCoroutine( DisplayAndRiseText(dam));
    }
    private IEnumerator DisplayAndRiseText(float damage)
    {
        // Tạo một thể hiện mới của văn bản nổi
        GameObject floatingTextInstance = Instantiate(floatingText, transform.position + Vector3.up * 2f, Quaternion.identity);

        // Đặt văn bản cho văn bản nổi vừa tạo
        TextMesh textMesh = floatingTextInstance.GetComponent<TextMesh>();
        if (textMesh != null)
        {
            textMesh.text = ((int)damage).ToString(); // Chỉ hiển thị số nguyên
        }

        // Hiển thị văn bản trong một khoảng thời gian
        yield return new WaitForSeconds(0f);

        // Di chuyển văn bản lên trên
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
