using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> roadsList;
    [SerializeField] GameObject roadPrefab1;
    [SerializeField] GameObject roadPrefab2;
    [SerializeField] GameObject roadPrefab3;
    [SerializeField] GameObject roadPrefab4;
    [SerializeField] GameObject roadPrefab5;
    [SerializeField] GameObject roadPrefab6;
    [SerializeField] GameObject taskPrefab;
    [SerializeField] GameObject roads;
    List<GameObject> roadPrefabList = new List<GameObject>();
    GameObject roadPrefab;

    int counter = 0;
    int mod;
    private float RoadZoffset = 50f;

    void Start()
    {
        roadPrefabList.Add(roadPrefab1);
        roadPrefabList.Add(roadPrefab2);
        roadPrefabList.Add(roadPrefab3);
        roadPrefabList.Add(roadPrefab4);
        roadPrefabList.Add(roadPrefab5);
        roadPrefabList.Add(roadPrefab6);

        if ( roadsList != null && roadsList.Count > 0)
        {
            roadsList = roadsList.OrderBy( road => road.transform.position.z).ToList();
        }
        
    }

    public void SpawnRoad()
    {
        int modDivider = UnityEngine.Random.Range(3,5);
        mod = counter % 4;

        if ( mod == 0)
        {
            SpawnTaskRoad();
        }
        else
        {
            SpawnBasicRoad();

        }

        counter++;

    }

    public void SpawnBasicRoad()
    {
        GameObject removedRoad = roadsList[0];
        Vector3 roadPosition = new Vector3(0, 0, removedRoad.transform.position.z);
        roadPosition.z = roadPosition.z + Math.Abs((roadsList.Count) * RoadZoffset);

        roadsList.RemoveAt(0);
        //Destroy(removedRoad);

        roadPrefab = RandomRoad(roadPrefabList);
        float degree = 90f;
        if ( roadPrefab == roadPrefab3 || roadPrefab == roadPrefab6)
        {
            List<float> tempList = new List<float>() { 90.0f, 270.0f };
            System.Random random = new System.Random();
            int index = random.Next(tempList.Count);
            degree = tempList[index];
        }

        Quaternion rotation = Quaternion.Euler(0, degree, 0);
        GameObject newRoad = Instantiate(roadPrefab, roadPosition, rotation);
        roadsList.Add(newRoad);
        newRoad.transform.SetParent(roads.transform);
        newRoad.name =  "Road";
        Debug.Log("SpawnRoad çalıştı");
    }

    public void SpawnTaskRoad()
    {
    
        GameObject removedRoad = roadsList[0];
        Vector3 roadPosition = new Vector3(0, 0, removedRoad.transform.position.z);
        roadPosition.z = roadPosition.z + Math.Abs((roadsList.Count) * RoadZoffset);
        Quaternion rotation = Quaternion.Euler(0, 90, 0);

        roadsList.RemoveAt(0);
        //Destroy(removedRoad);

        GameObject newRoad = Instantiate(taskPrefab, roadPosition, rotation);
        roadsList.Add(newRoad);
        newRoad.transform.SetParent(roads.transform);
        newRoad.name = "TaskRoad";
        newRoad.tag = "TaskRoad";
        Debug.Log("SpawnTaskRoad çalıştı");

    }

    public GameObject RandomRoad(List<GameObject> list)
    {
        // Rastgele sayı üretme
        System.Random random = new System.Random();
        int randomIndex = random.Next(roadPrefabList.Count);

        // Rastgele seçilen öğeyi döndürme
        return roadPrefabList[randomIndex];
    }
}
