using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private ICameraFollow cameraFollow;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
  

    void Start()
    {
        InitializeVariables();
    }
    public void InitializeVariables()
    {
        cameraFollow = new CameraFollow(this.player, this.gameObject, this.offset);

    }
    void Update()
    {
        cameraFollow.FollowPlayer();
        
    }
    
}
