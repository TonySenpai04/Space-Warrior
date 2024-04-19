using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms;

public abstract class Item:MonoBehaviour
{
    public Sprite sprite;
    public string lootName;
    public int dropChange;
    public int dropCount;


    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        
    }
    public virtual void PlayBurstAnimation()
    {

    }
    public virtual void TriggerItem()
    {

    }
    public virtual IEnumerator TriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        TriggerItem();
    }
}