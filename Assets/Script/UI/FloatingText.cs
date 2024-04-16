using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject!=null)
        Destroy(this.gameObject,1f);
    }
   
}
