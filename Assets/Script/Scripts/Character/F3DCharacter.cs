using UnityEngine;
using System.Collections;

public class F3DCharacter : MonoBehaviour
{
    public int Health;
   
    private int hitTriggerCounter;
    private float _hitTriggerTimer;
    private Rigidbody2D rBody;
    private ShootingController shootingController;
    private bool isDead;

    // Use this for initialization
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
     
        shootingController = GetComponent<ShootingController>();
    }

    public void OnDamage(int damageAmount)
    {
       
        if (isDead) return;

        // Substract incoming damage
        if (Health > 0)
            Health -= damageAmount;

        // Dead Already?
        if (Health <= 0)
        {
            Health = 0;
            isDead = true;

            // Player Death sequence
          //  _controller.Character.SetBool(Random.Range(-1f, 1f) > 0 ? "DeathFront" : "DeathBack", true);

            // Dead dont do shit
            //_controller.enabled = false;
            gameObject.layer = LayerMask.NameToLayer("Dead");
            rBody.drag = 2f;

//            for (int i = 0; i < _colliders.Length; i++)
//                _colliders[i].enabled = false;
            shootingController.Drop();

            // Disable blob shadow under the character
            //if (_controller.Shadow)
            //    _controller.Shadow.enabled = false;

            //
            return;
        }

        // Play Hit Animation and limit hit animation triggering 
        //if (hitTriggerCounter < 1)
        //    _controller.Character.SetTrigger("Hit");
        hitTriggerCounter++;
    }

    private void LateUpdate()
    {
        // Dead... Quit trying
        if (isDead) return;
    //    if (Input.GetKeyDown(KeyCode.K))
    //        OnDamage(1000);

        // Handle Hit Trigger timer
        if (_hitTriggerTimer > 0.5f) // <- Hit timer
        {
            hitTriggerCounter = 0;
            _hitTriggerTimer = 0;
        }
        _hitTriggerTimer += Time.deltaTime;
    }
}