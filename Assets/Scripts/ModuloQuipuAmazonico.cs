using UnityEngine;
using TMPro;

public class ModuloQuipuAmazonico : MonoBehaviour
{
    public AmazoniaLevelManager levelManager;

    public TMP_Text textoJaguar;
    public TMP_Text textoAnaconda;
    public TMP_Text textoGuacamayo;

    private int jaguar = 1;
    private int anaconda = 1;
    private int guacamayo = 1;

    private bool resuelto = false;

    void Start()
    {
        ActualizarTextos();
    }

    public void CambiarJaguar(int cambio)
    {
        if (resuelto) return;

        jaguar += cambio;
        if (jaguar < 1) jaguar = 9;
        if (jaguar > 9) jaguar = 1;

        ActualizarTextos();
    }

    public void CambiarAnaconda(int cambio)
    {
        if (resuelto) return;

        anaconda += cambio;
        if (anaconda < 1) anaconda = 9;
        if (anaconda > 9) anaconda = 1;

        ActualizarTextos();
    }

    public void CambiarGuacamayo(int cambio)
    {
        if (resuelto) return;

        guacamayo += cambio;
        if (guacamayo < 1) guacamayo = 9;
        if (guacamayo > 9) guacamayo = 1;

        ActualizarTextos();
    }

    public void Confirmar()
    {
        if (resuelto) return;

        if (jaguar == 7 && anaconda == 3 && guacamayo == 5)
        {
            resuelto = true;

            if (levelManager != null)
                levelManager.RegistrarModuloResuelto();
        }
        else
        {
            Debug.Log("Quipu amazónico incorrecto.");
        }
    }

    void ActualizarTextos()
    {
        textoJaguar.text = jaguar.ToString();
        textoAnaconda.text = anaconda.ToString();
        textoGuacamayo.text = guacamayo.ToString();
    }
}