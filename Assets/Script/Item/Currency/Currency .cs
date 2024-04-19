using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Currency:Item
{
    public float burstDuration = 0.3f;
    public CurrencyManager.CurrencyType typeItem;
    public float speedMove=5f;
    bool isMove=true;
    public GameObject target;
 

   public override void Start()
    {

        GetComponent<SpriteRenderer>().sprite=sprite;
       

    }
    public override void PlayBurstAnimation()
    {
        StartCoroutine(BurstAnimation());
    }

    public virtual IEnumerator BurstAnimation()
    {
        float elapsedTime = 0f;
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.5f;

        while (elapsedTime < burstDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / burstDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;
    }
  
    public override void Update()
    {
        if(isMove)
        {
            transform.position=Vector3.Lerp(transform.position,target.transform.position,speedMove*Time.deltaTime);
        }
    }
    public override IEnumerator TriggerAfterDelay(float delay) => base.TriggerAfterDelay(delay);
    public override void TriggerItem()
    {
        CurrencyManager.instance.AddItem(typeItem, dropCount);
        gameObject.GetComponent<Collider2D>().enabled = false;
        isMove = true;
        Destroy(gameObject,3f);
    }

}