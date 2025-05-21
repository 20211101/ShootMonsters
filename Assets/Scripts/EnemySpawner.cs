using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public List<GameObject> spawnedEnemy = new List<GameObject>();
    public GameObject EnemyObj;

    Vector3[] linePosition = new Vector3[3]
    {
        new Vector3(-3, 1, 17),    // 0
        new Vector3(0, 1, 17),     // 1
        new Vector3(3, 1, 17)      // 2
    };

    float spawnTime = 2;
    float purposeTime = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        purposeTime = Time.time + spawnTime; // 0 -> 3
    }

    public void UpdateSpawner()
    {
        if (purposeTime < Time.time)
        {
            int randomLine = Random.Range(0, linePosition.Length); // 0 , 1 , 2
            GameObject monster = Instantiate(EnemyObj, linePosition[randomLine], Quaternion.identity);
            spawnedEnemy.Add(monster);

            purposeTime = Time.time + spawnTime;
        }
    }

    public void DeleteEnemy(GameObject target)
    {
        if(target != null && spawnedEnemy.Contains(target))
        {
            spawnedEnemy.Remove(target);

            target.SetActive(false);
            Destroy(target, 1);
        }
    }

    public void DestroyAllMonsters()
    {
        for(int i = 0; i < spawnedEnemy.Count; i++)
        {
            spawnedEnemy[i].SetActive(false); 
            Destroy(spawnedEnemy[i], 1);
        }
        spawnedEnemy.Clear();
    }
}
