using UnityEngine;

public class PersonalizadorSombrero : MonoBehaviour
{
    public Transform slotSombrero; // Será SlotObjeto
    private GameObject sombreroSeleccionado;
    private GameObject sombreroColocado;

    public void SeleccionarSombrero(GameObject sombrero)
    {
        sombreroSeleccionado = sombrero;
    }

    public void ColocarSombrero()
    {
        if (sombreroColocado != null)
            sombreroColocado.SetActive(false);

        if (sombreroSeleccionado != null)
        {
            sombreroSeleccionado.SetActive(true);
            sombreroSeleccionado.transform.SetParent(null);

            // Ajustar la posición del sombrero con un pequeño offset hacia arriba
            Vector3 posicion = slotSombrero.position;
            posicion.y += 1.7f; // Ajustá este valor según se necesite

            sombreroSeleccionado.transform.position = posicion;

            sombreroColocado = sombreroSeleccionado;
        }
    }
}
