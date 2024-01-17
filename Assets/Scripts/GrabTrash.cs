using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTrash : MonoBehaviour
{
    public List<GameObject> Trashes = new List<GameObject>();
    void Update() 
    {
        if(SpawnManager.Instance.PaperCount > 0)
        {
            Trashes[0].SetActive(true);
        }
        else
        {
            Trashes[0].SetActive(false);
        }

        if(SpawnManager.Instance.PlasticCount > 0)
        {
            Trashes[1].SetActive(true);
        }
        else
        {
            Trashes[1].SetActive(false);
        }

        if(SpawnManager.Instance.GlassCount > 0)
        {
            Trashes[2].SetActive(true);
        }
        else
        {
            Trashes[2].SetActive(false);
        }
    }
}
