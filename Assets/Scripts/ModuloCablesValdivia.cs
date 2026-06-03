using UnityEngine;
using TMPro;

public class ModuloCablesValdivia : MonoBehaviour
{
    public CostaLevelManager levelManager;
    public TMP_Text[] textosTerminales;

    private int[] seleccion = new int[4];
    private int[] solucion = new int[4] { 0, 1, 2, 3 };

    private bool resuelto = false;

    private string[] letras = new string[] { "A", "B", "C", "D" };

    void Start()
    {
        ActualizarTextos();
    }

    public void CambiarCable(int indice)
    {
        if (resuelto) return;

        seleccion[indice]++;

        if (seleccion[indice] >= letras.Length)
            seleccion[indice] = 0;

        ActualizarTextos();
    }

    public void Confirmar()
    {
        if (resuelto) return;

        for (int i = 0; i < solucion.Length; i++)
        {
            if (seleccion[i] != solucion[i])
            {
                Debug.Log("Cables incorrectos.");
                return;
            }
        }

        resuelto = true;
        Debug.Log("Módulo Cables Valdivia resuelto.");

        if (levelManager != null)
            levelManager.RegistrarModuloResuelto();
    }

    void ActualizarTextos()
    {
        for (int i = 0; i < textosTerminales.Length; i++)
        {
            textosTerminales[i].text = letras[seleccion[i]];
        }
    }
}