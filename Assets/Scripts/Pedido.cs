using UnityEngine;
using System.Collections.Generic;

public class Pedido : MonoBehaviour
{
    public GameObject[] modeloPrefab;      
    public GameObject[] SombreroPrefab;
    public GameObject[] CamisaPrefab;
    public GameObject[] ZapatoPrefab;

    public Transform modeloSpawnPoint;      
    public Transform sombreroSpawnPoint;
    public Transform camisaSpawnPoint;
    public Transform zapatoSpawnPoint;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start()
    {
            SpawnRandomCombination();
    }
    public void SpawnRandomCombination()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        spawnedObjects.Clear();

        if (modeloPrefab.Length > 0 && modeloSpawnPoint != null)
        {
            int indexA = Random.Range(0, modeloPrefab.Length);
            GameObject spawnedA = Instantiate(modeloPrefab[indexA], modeloSpawnPoint.position, Quaternion.identity);

            if (spawnedA.name.ToLower().Contains("rojo"))
            {
                Vector3 pos = spawnedA.transform.position;
                pos.y -= 0.27f;
                spawnedA.transform.position = pos;
            }

            spawnedObjects.Add(spawnedA);
        }

        if (SombreroPrefab.Length > 0 && sombreroSpawnPoint != null)
        {
            int indexB = Random.Range(0, SombreroPrefab.Length);
            GameObject spawnedB = Instantiate(SombreroPrefab[indexB], sombreroSpawnPoint.position, Quaternion.identity);
            spawnedObjects.Add(spawnedB);
        }

        if(CamisaPrefab.Length > 0 && camisaSpawnPoint != null)
        {
            int indexB = Random.Range(0, CamisaPrefab.Length);
            GameObject spawnedC = Instantiate(CamisaPrefab[indexB], camisaSpawnPoint.position, Quaternion.identity);
            spawnedObjects.Add(spawnedC);
        }

        if (ZapatoPrefab.Length > 0 && zapatoSpawnPoint != null)
        {
            int indexB = Random.Range(0, ZapatoPrefab.Length);
            GameObject spawnedD = Instantiate(ZapatoPrefab[indexB], zapatoSpawnPoint.position, Quaternion.identity);
            spawnedObjects.Add(spawnedD);
        }
    }
}
