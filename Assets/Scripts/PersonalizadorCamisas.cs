using UnityEngine;

public class PersonalizadorCamisa : MonoBehaviour
{
    public Transform slotCamisa; // Usar el SlotObjeto existente
    private GameObject camisaSeleccionada;
    private GameObject camisaColocada;

    public void SeleccionarCamisa(GameObject camisa)
    {
        camisaSeleccionada = camisa;
    }

    public void ColocarCamisa()
{
    if (camisaColocada != null)
        camisaColocada.SetActive(false);

    if (camisaSeleccionada != null)
    {
        camisaSeleccionada.SetActive(true);

        // Posición base desde el slot
        Vector3 posicion = slotCamisa.position;

        // Offset hacia abajo en Y (ajustá este valor según el diseño)
        posicion.y -= 0.6f;

        camisaSeleccionada.transform.position = posicion;
        camisaColocada = camisaSeleccionada;
    }
}

}


