using UnityEngine;

public class Personalizador : MonoBehaviour
{
    public GameObject rojoObjeto;
    public GameObject azulObjeto;

    public Transform puntoColocacion;

    private GameObject objetoSeleccionado;
    private GameObject objetoColocado;

    public void SeleccionarRojo()
    {
        objetoSeleccionado = rojoObjeto;
    }

    public void SeleccionarAzul()
    {
        objetoSeleccionado = azulObjeto;
    }

    public void ColocarObjeto()
    {
        if (objetoColocado != null)
        {
            objetoColocado.SetActive(false);
        }

        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.SetActive(true);

            // Posición base
            Vector3 posicion = puntoColocacion.position;

            // Offset específico para azul
            if (objetoSeleccionado == azulObjeto)
            {
                posicion.y += 0.6f; // Ajustá este valor según tu escena
            }

            objetoSeleccionado.transform.position = posicion;

            objetoColocado = objetoSeleccionado;
        }
    }
}






