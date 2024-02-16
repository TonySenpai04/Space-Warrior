using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item:MonoBehaviour
{
    public Sprite sprite;
    public string lootName;
    public int dropChange;
    public int count;
    public float burstDuration = 0.3f;
    public ItemManager.ItemType typeItem;

    public virtual void Start()
    {
        GetComponent<SpriteRenderer>().sprite=sprite;
    }
    public void PlayBurstAnimation()
    {
        StartCoroutine(BurstAnimation());
    }

    private IEnumerator BurstAnimation()
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
}