using Unity.VisualScripting;
using UnityEngine;

public class Minion:Enemy
{
  
    [SerializeField] private float speed;
    [SerializeField] private bool movingForward = true;
    [SerializeField] private Transform owner;
    [SerializeField] private float moveDistance = 3f;
    public override void  Awake()
     {
        base.Awake();
     }
    public override void Update()
    {
        if (movingForward)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if ( transform.parent.position.x-transform.position.x >= 5)
            {

                movingForward = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 1);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        }
    }


}