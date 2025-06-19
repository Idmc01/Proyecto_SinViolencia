using UnityEngine;

public class Personalizador : MonoBehaviour
{
    public GameObject rojoPrefab;
    public GameObject azulPrefab;
    public Transform puntoColocacion;

    private GameObject objetoSeleccionado;
    private GameObject objetoColocado;

    public void SeleccionarRojo()
    {
        objetoSeleccionado = rojoPrefab;
    }

    public void SeleccionarAzul()
    {
        objetoSeleccionado = azulPrefab;
    }

    public void ColocarObjeto()
    {
        if (objetoColocado != null)
            Destroy(objetoColocado);

        if (objetoSeleccionado != null)
        {
            objetoColocado = Instantiate(objetoSeleccionado, puntoColocacion.position, Quaternion.identity, puntoColocacion);
        }
    }
}

