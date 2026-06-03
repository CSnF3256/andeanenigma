using UnityEngine;
using TMPro;

public class ModuloQuipuCostero : MonoBehaviour
{
    public CostaLevelManager levelManager;

    public TMP_Text textoOla;
    public TMP_Text textoPez;
    public TMP_Text textoConcha;

    private int ola = 1;
    private int pez = 1;
    private int concha = 1;

    private bool resuelto = false;

    void Start()
    {
        ActualizarTextos();
    }

    public void CambiarOla(int cambio)
    {
        if (resuelto) return;

        ola += cambio;

        if (ola < 1) ola = 9;
        if (ola > 9) ola = 1;

        ActualizarTextos();
    }

    public void CambiarPez(int cambio)
    {
        if (resuelto) return;

        pez += cambio;

        if (pez < 1) pez = 9;
        if (pez > 9) pez = 1;

        ActualizarTextos();
    }

    public void CambiarConcha(int cambio)
    {
        if (resuelto) return;

        concha += cambio;

        if (concha < 1) concha = 9;
        if (concha > 9) concha = 1;

        ActualizarTextos();
    }

    public void Confirmar()
    {
        if (resuelto) return;

        if (ola == 3 && pez == 5 && concha == 1)
        {
            resuelto = true;
            Debug.Log("Módulo Quipu Costero resuelto.");

            if (levelManager != null)
                levelManager.RegistrarModuloResuelto();
        }
        else
        {
            Debug.Log("Quipu incorrecto.");
        }
    }

    void ActualizarTextos()
    {
        textoOla.text = ola.ToString();
        textoPez.text = pez.ToString();
        textoConcha.text = concha.ToString();
    }
}