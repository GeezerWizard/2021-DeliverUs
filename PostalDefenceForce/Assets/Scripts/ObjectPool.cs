using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int objectsToSpawnPerFrame = 2;
    public int targetObjectsToSpawn = 200;
    public GameObject objectToPool;
    private List<GameObject> objectPool = new List<GameObject>();

    public void AddObjectsToObjectPool()
    {
        if (objectToPool == null)
        {
            Debug.LogError("Please set a value for objectToPool");
            return;
        }

        if (objectPool.Count < targetObjectsToSpawn)
        {
            for (int i = 0; i < objectsToSpawnPerFrame; i++)
            {
                AddObjectToPool();
            }
        }
    }

    public GameObject AddObjectToPool()
    {
        GameObject tempObject = Instantiate(objectToPool);
        tempObject.SetActive(false);
        objectPool.Add(tempObject);

        return tempObject;
    }

    public GameObject GetPooledObject()
    {
        GameObject objectToReturn = null;

        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeSelf)
            {
                objectToReturn = objectPool[i];
                break;
            }
        }

        if (objectToReturn == null)
        {
            objectToReturn = AddObjectToPool();
        }

        return objectToReturn;
    }

    public void DisablePooledObject(GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
    }

}
