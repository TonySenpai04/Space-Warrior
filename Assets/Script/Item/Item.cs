using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Item:MonoBehaviour
{
    public Sprite sprite;
    public string lootName;
    public int dropChange;
    public int count;
    public float burstDuration = 0.3f;
    public ItemManager.ItemType typeItem;
    public float speedMove=5f;
    bool isMove=true;
    public GameObject target;

   public virtual void Start()
    {

        GetComponent<SpriteRenderer>().sprite=sprite;
       

    }
    public virtual void PlayBurstAnimation()
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
    public virtual void OnMouseDown()
    {
        TriggerItem();
    }
    public virtual void Update()
    {
        if(isMove)
        {
            transform.position=Vector3.Lerp(transform.position,target.transform.position,speedMove*Time.deltaTime);
        }
    }
    public virtual IEnumerator TriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        TriggerItem();
    }
    public virtual void TriggerItem()
    {
        ItemManager.instance.AddItem(typeItem, count);
        gameObject.GetComponent<Collider2D>().enabled = false;
        isMove = true;
        Destroy(gameObject,3f);
    }

}