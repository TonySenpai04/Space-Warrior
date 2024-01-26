using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private MovementControllerBase movementController;
    [SerializeField]private ShootingControllerBase shootingController;
    [SerializeField] private AnimationControllerBase animationController;
    public float damage=5f;
    public static PlayerController instance;
    private void Start()
    {
        instance=this;
    }
    private void Update()
    {
        shootingController.Shoot();
    }
    private void FixedUpdate()
    {
        movementController.Move();
    }


}
