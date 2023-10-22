using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private LayerMask Interactable;
    [SerializeField] private LayerMask Collectable;
    [SerializeField] private LayerMask Moveing;
    [SerializeField] ElevatorMovement Elevator;
    void Update()
    {
        if (Camera.main == null) return;

        RaycastHit hit;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 1000);
        if (Physics.SphereCast(ray, 0.5f, out hit, 10, Interactable + Collectable + Moveing))
        {
            if (Interactable.value == (1 << hit.collider.gameObject.layer))
            {
                Debug.Log("Can Interact");
                LootBox box = hit.collider.GetComponent<LootBox>();
                if (Elevator != null) 
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Vector3.Distance(transform.position, Elevator.transform.position) < Elevator.BuutonRange)
                        {
                            if(hit.transform.gameObject.tag == "PlatformGo")
                            {
                                Elevator.PlatformGo();
                            }

                            if (hit.transform.gameObject.tag == "PlatformStop")
                            {
                                Elevator.PlatformStop();
                            }
                        }
                    }
                }
                if (box != null)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Vector3.Distance(transform.position, box.transform.position) < box.OpenRange)
                        {
                            Debug.Log("Opened");
                            box.open();
                        }
                    }
                }
            }
            if (Collectable.value == (1 << hit.collider.gameObject.layer))
            {
                Collect item = hit.collider.GetComponent<Collect>();
                if (item != null)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (hit.distance < item.pickUpRange)
                        {
                            Debug.Log("Collected");
                            item.CollectItem();
                        }
                    }
                }
            }

        }
    }
}
