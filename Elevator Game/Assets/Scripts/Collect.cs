using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public float pickUpRange;

    [Header("What To Give")]
    public int AmountToGiveWood;
    public int AmountToGivePills;
    public int AmountToGiveBatteries;

    [Header("What To Give Items")]
    public int giveHammer;

    GameObject player;
    ItemManager ItemManager;
    void Start()
    {
        player = GameObject.Find("Player");
        ItemManager = player.GetComponent<ItemManager>();
    }
    public void CollectItem()
    {
        if (ItemManager.wood < 100000)
        {
            ItemManager.wood += AmountToGiveWood;
        }
        if (ItemManager.pills < 100000)
        {
            ItemManager.pills += AmountToGivePills;
        }
        if (ItemManager.batteries < 100000)
        {
            ItemManager.batteries += AmountToGiveBatteries;
        }
        if (ItemManager.hammer < 1)
        {
            ItemManager.hammer += giveHammer;
        }
        Destroy(gameObject);
    }
}
