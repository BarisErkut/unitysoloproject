using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 50;

    private List<GameObject> pool;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        //Optionally, expand the pool if all objects are in use
        GameObject newObj = Instantiate(enemyPrefab);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}
