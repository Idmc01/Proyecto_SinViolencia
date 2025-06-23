using UnityEngine;
using System.Collections.Generic;
using TMPro;

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
    public TMP_Text puntajeTexto;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private List<string> nombresGenerados = new List<string>();

    private bool primeraComb = true;

    
    private int puntaje = 0;

    private void Start()
    {
        SpawnRandomCombination();
    }
    public void SpawnRandomCombination()
    {
        if (checkSolucion() || primeraComb)
        {
            foreach (GameObject obj in spawnedObjects)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
            spawnedObjects.Clear();
            nombresGenerados.Clear();

            if (modeloPrefab.Length > 0 && modeloSpawnPoint != null)
            {
                int indexA = Random.Range(0, modeloPrefab.Length);
                GameObject spawnedA = Instantiate(modeloPrefab[indexA], modeloSpawnPoint.position, Quaternion.identity);

                if (spawnedA.name.ToLower().Contains("oso"))
                {
                    Vector3 pos = spawnedA.transform.position;
                    pos.y -= 0.27f;
                    spawnedA.transform.position = pos;
                }

                spawnedObjects.Add(spawnedA);
                nombresGenerados.Add(LimpiarNombre(spawnedA.name));
            }

            if (SombreroPrefab.Length > 0 && sombreroSpawnPoint != null)
            {
                int indexB = Random.Range(0, SombreroPrefab.Length);
                GameObject spawnedB = Instantiate(SombreroPrefab[indexB], sombreroSpawnPoint.position, Quaternion.identity);
                spawnedObjects.Add(spawnedB);
                nombresGenerados.Add(LimpiarNombre(spawnedB.name));
            }

            if (CamisaPrefab.Length > 0 && camisaSpawnPoint != null)
            {
                int indexB = Random.Range(0, CamisaPrefab.Length);
                GameObject spawnedC = Instantiate(CamisaPrefab[indexB], camisaSpawnPoint.position, Quaternion.identity);
                spawnedObjects.Add(spawnedC);
                nombresGenerados.Add(LimpiarNombre(spawnedC.name));
            }

            if (ZapatoPrefab.Length > 0 && zapatoSpawnPoint != null)
            {
                int indexB = Random.Range(0, ZapatoPrefab.Length);
                GameObject spawnedD = Instantiate(ZapatoPrefab[indexB], zapatoSpawnPoint.position, Quaternion.identity);
                spawnedObjects.Add(spawnedD);
                nombresGenerados.Add(LimpiarNombre(spawnedD.name));
            }
            if (!primeraComb) { SumarPunto(); }
            primeraComb = false;
        }
    }

    public bool checkSolucion()
    {
        GameObject[] todos = GameObject.FindObjectsOfType<GameObject>();

        foreach (string nombreGenerado in nombresGenerados)
        {
            int cantidad = 0;

            foreach (GameObject obj in todos)
            {
                if (!obj.activeInHierarchy) continue;

                string nombreLimpio = LimpiarNombre(obj.name);

                if (nombreLimpio == nombreGenerado)
                {
                    cantidad++;
                }
            }

            if (cantidad < 2)
            {
                // No hay suficientes objetos con este nombre
                return false;
            }
        }

        // Si todos los nombres tienen al menos 2 instancias activas
        return true;
    }

    private string LimpiarNombre(string original)
    {
        return original.Replace("(Clone)", "").Trim().ToLower();
    }

    public void SumarPunto()
    {
        puntaje++;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        puntajeTexto.text = "Puntaje: " + puntaje;
    }
}
