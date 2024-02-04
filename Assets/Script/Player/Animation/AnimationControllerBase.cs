using UnityEngine;

public class AnimationControllerBase:MonoBehaviour
{
    public Animator animator;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void Idle()
    {

    }
    public virtual void Move()
    {

    }
}