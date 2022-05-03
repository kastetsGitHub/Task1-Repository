using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _movement.MoveForward();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            _movement.MoveBackward();
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            _movement.Jump();
        }
    }
}
