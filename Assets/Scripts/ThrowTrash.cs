using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ThrowTrash : MonoBehaviour
{
    [SerializeField] TrashType trashType;

    public void OnTriggerEnter(Collider other) 
    {
        Debug.Log("ThrowTrash");
        
        SpawnManager.Instance.EmptyTrash(trashType, gameObject.transform);
    }
}