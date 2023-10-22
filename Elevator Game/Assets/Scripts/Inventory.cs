using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    ItemManager ItemManager;
    public bool InvOpen = false;
    public bool HoldingSomething = false;
    public GameObject inventory;
    public GameObject Fpcamera;
    [SerializeField] private PlayerCam cam;
    [SerializeField] private PlayerMovement move;

    [Header("Mats")]
    public GameObject pillsPrefab;
    public GameObject batteriesPrefab;
    public GameObject woodPrefab;

    [Header("Items")]
    public GameObject hammerPrefab;

    void Start()
    {
        ItemManager = GetComponent<ItemManager>();
    }

    void Update()
    {
        Escape();
        ItemCheck();

        if (Input.GetKeyDown(KeyCode.I))
        {
            InvOpen = true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InvOpen = true;
        }

        if (InvOpen == true)
        {
            cam.enabled = false;
            move.enabled = false;
            Fpcamera.transform.rotation = Quaternion.Euler(25, Fpcamera.transform.rotation.eulerAngles.y, Fpcamera.transform.rotation.eulerAngles.z);
            HoldingSomething = false;
            inventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        if (InvOpen == false)
        {
            inventory.SetActive(false);
            move.enabled = true;
            cam.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void ItemCheck()
    {
        if (InvOpen == true)
        {
            //////////////////////////[ Item ]//////////////////////////
            if (ItemManager.hammer == 1)
            {
                hammerPrefab.SetActive(true);
            }
            else hammerPrefab.SetActive(false);

            //////////////////////////[ Mats ]///////////////////////////

            if (ItemManager.pills >= 1)
            {
                pillsPrefab.SetActive(true);
            }
            else pillsPrefab.SetActive(false);
            if (ItemManager.batteries >= 1)
            {
                batteriesPrefab.SetActive(true);
            }
            else batteriesPrefab.SetActive(false);
            if (ItemManager.wood >= 1)
            {
                woodPrefab.SetActive(true);
            }
            else woodPrefab.SetActive(false);
        }
        else return;
    }

    void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && InvOpen == true)
        {
            ForceEscape();
        }
    }

    void ForceEscape()
    {
        InvOpen = false;
    }
}
