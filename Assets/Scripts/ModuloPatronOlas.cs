using UnityEngine;
using UnityEngine.UI;

public class ModuloPatronOlas : MonoBehaviour
{
    public CostaLevelManager levelManager;
    public Image[] celdas;

    private bool[] activas = new bool[9];

    private bool[] solucion = new bool[9]
    {
        true, false, true,
        false, true, false,
        true, false, true
    };

    private bool resuelto = false;

    void Start()
    {
        ActualizarVisual();
    }

    public void CambiarCelda(int indice)
    {
        if (resuelto) return;

        activas[indice] = !activas[indice];
        ActualizarVisual();
    }

    public void Confirmar()
    {
        if (resuelto) return;

        for (int i = 0; i < solucion.Length; i++)
        {
            if (activas[i] != solucion[i])
            {
                Debug.Log("Patrón de olas incorrecto.");
                return;
            }
        }

        resuelto = true;
        Debug.Log("Módulo Patrón de Olas resuelto.");

        if (levelManager != null)
        {
            levelManager.RegistrarModuloResuelto();
            levelManager.MostrarPistaQuipu();
        }
    }

    void ActualizarVisual()
    {
        for (int i = 0; i < celdas.Length; i++)
        {
            if (celdas[i] != null)
            {
                celdas[i].color = activas[i] ? Color.cyan : Color.gray;
            }
        }
    }
}