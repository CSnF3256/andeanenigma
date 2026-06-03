using UnityEngine;
using UnityEngine.UI;

public class ModuloSelvaLightsOut : MonoBehaviour
{
    public AmazoniaLevelManager levelManager;
    public Image[] celdas;

    private bool[] activas = new bool[9];
    private bool resuelto = false;

    void Start()
    {
        // Estado inicial recomendado
        activas[0] = false;
        activas[1] = true;
        activas[2] = false;
        activas[3] = true;
        activas[4] = false;
        activas[5] = true;
        activas[6] = false;
        activas[7] = true;
        activas[8] = false;

        ActualizarVisual();
    }

    public void TocarCelda(int indice)
    {
        if (resuelto) return;

        Cambiar(indice);

        int fila = indice / 3;
        int columna = indice % 3;

        if (fila > 0) Cambiar(indice - 3);
        if (fila < 2) Cambiar(indice + 3);
        if (columna > 0) Cambiar(indice - 1);
        if (columna < 2) Cambiar(indice + 1);

        ActualizarVisual();

        if (TodasActivas())
        {
            resuelto = true;

            if (levelManager != null)
                levelManager.RegistrarModuloResuelto();
        }
    }

    void Cambiar(int indice)
    {
        activas[indice] = !activas[indice];
    }

    bool TodasActivas()
    {
        for (int i = 0; i < activas.Length; i++)
        {
            if (!activas[i])
                return false;
        }

        return true;
    }

    void ActualizarVisual()
    {
        for (int i = 0; i < celdas.Length; i++)
        {
            if (celdas[i] != null)
            {
                celdas[i].color = activas[i] ? Color.green : Color.gray;
            }
        }
    }
}