using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    [SerializeField] GameObject plasticPrefab;
    [SerializeField] GameObject paperPrefab;
    [SerializeField] GameObject glassPrefab;
    int numberOfObjects;
    MeshCollider meshCollider;

    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        numberOfObjects = Random.Range(1,4);
        SpawnObjects();
        meshCollider.enabled = false;
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject selectedPrefab = GetRandomPrefab();
            // Rastgele bir nokta al
            Vector3 randomPoint = GetRandomPointOnObject();

            // Noktada objeyi spawnla
            Instantiate(selectedPrefab, randomPoint, Quaternion.identity);
        }
    }

    Vector3 GetRandomPointOnObject()
    {
        // Objeye ait bir MeshCollider var mı kontrol et
        
        if (meshCollider == null)
        {
            // Eğer MeshCollider yoksa uyarı ver ve (0, 0, 0) noktasını dön
            Debug.LogWarning("Objeye ait MeshCollider bulunamadı.");
            return Vector3.zero;
        }

        // Rastgele bir nokta al, objenin yüzeyinde olacak şekilde
        Vector3 randomPoint = new Vector3(
            Random.Range(meshCollider.bounds.min.x, meshCollider.bounds.max.x),
            meshCollider.bounds.max.y, // Objenin üstünde spawn etmek istiyoruz, bu yüzden y eksenini kullanıyoruz
            Random.Range(meshCollider.bounds.min.z, meshCollider.bounds.max.z)
        );

        return randomPoint;
    }

    GameObject GetRandomPrefab()
    {
        // prefab'ları bir diziye koy
        GameObject[] prefabs = { plasticPrefab, paperPrefab, glassPrefab };

        // diziden rastgele bir prefab seç
        int randomIndex = Random.Range(0, prefabs.Length);
        return prefabs[randomIndex];
    }

}