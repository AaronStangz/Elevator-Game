using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{ 
    public GameObject lid;
    public GameObject spawnPoint;
    public float OpenRange;
    private bool opened = false;

    public List<GameObject> Item;
    public void open()
    {
        if(opened == false)
        {

            Instantiate(Item[Random.Range(0, Item.Count)], spawnPoint.transform.position, spawnPoint.transform.rotation);
            Destroy(lid);
            opened = true;
        }
       
    }
}
