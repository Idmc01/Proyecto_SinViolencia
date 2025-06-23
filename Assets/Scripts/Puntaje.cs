using UnityEngine;
using TMPro;
public class Puntaje : MonoBehaviour
{
    public TMP_Text puntajeTexto; 
    private int puntaje = 0;

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
