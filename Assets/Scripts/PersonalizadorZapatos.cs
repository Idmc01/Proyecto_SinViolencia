using UnityEngine;

public class PersonalizadorZapatos : MonoBehaviour
{
    public Transform slotZapatos; // Generalmente es el mismo que slotCamisa o SlotObjeto
    private GameObject zapatosSeleccionados;
    private GameObject zapatosColocados;

    public void SeleccionarZapatos(GameObject zapatos)
    {
        zapatosSeleccionados = zapatos;
    }

    public void ColocarZapatos()
    {
        if (zapatosColocados != null)
            zapatosColocados.SetActive(false);

        if (zapatosSeleccionados != null)
        {
            zapatosSeleccionados.SetActive(true);

            // Usamos la posición base del slot con un offset hacia abajo
            Vector3 posicion = slotZapatos.position;
            posicion.y -= 1.7f; // Ajustá según lo necesites

            zapatosSeleccionados.transform.position = posicion;
            zapatosColocados = zapatosSeleccionados;
        }
    }
}

