using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrashInteraction : MonoBehaviour
{
    public TrashType trashType;

    public void Interact(Vector3 playerPosition)
    {
        SpawnManager.Instance.TrashCountUpdate(trashType);
        transform.DOJump(transform.position + Vector3.up * 4f + Vector3.right * 4f, 1f, 1, 0.5f);
        transform.DOScale(0f, 0.5f);
        Debug.Log("destroy");
        Destroy(gameObject, 0.5f);
    }
}
