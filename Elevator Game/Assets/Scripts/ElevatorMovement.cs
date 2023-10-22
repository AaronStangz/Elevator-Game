using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElevatorMovement : MonoBehaviour
{
    public Transform player;
    public float CurrentMoveSpeed = 1;
    public float MoveSpeed = 5;
    public bool isOnMovingPlatform = false;
    public float BuutonRange;

    void Start()
    {
        
    }

    public void Update()
    {
        MovePlatform();
        if (Input.GetKeyDown(KeyCode.O))
        {
            CurrentMoveSpeed = 0;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            CurrentMoveSpeed = MoveSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.gameObject.transform;
            isOnMovingPlatform = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
            isOnMovingPlatform = false;
        }
    }

    public void MovePlatform()
    {
        transform.Translate(Vector2.down * CurrentMoveSpeed * Time.deltaTime);
    }
    public void PlatformStop()
    {
        CurrentMoveSpeed = 0;
    }
    public void PlatformGo()
    {
        CurrentMoveSpeed = MoveSpeed;
    }
}
