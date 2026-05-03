using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public void IrAHistoria()
    {
        SceneManager.LoadScene("HistoriaInicial");
    }

    public void IrAPrimerDesafio()
    {
        SceneManager.LoadScene("Nivel_Artefacto_Sierra");
    }
    public void IrAsegundahistoria()
    {
        SceneManager.LoadScene("Historiaseguirnivel");
    }
    public void IrANiveles()
    {
        SceneManager.LoadScene("Niveles");
    }

    public void IrAMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}