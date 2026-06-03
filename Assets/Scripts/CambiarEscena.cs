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
    public void IrAHistoriaNivelCosta()
    {
        SceneManager.LoadScene("HistoriaNivelCosta");
    }
    public void IrAHistoriaNivelAmazonia()
    {
        SceneManager.LoadScene("HistoriaAmazonia");
    }

    public void IrANivelAmazonia()
    {
        SceneManager.LoadScene("Nivel_Amazonia_Napo");
    }

    public void IrANivelGalapagos()
    {
        SceneManager.LoadScene("Nivel_Galapagos");
    }
    public void IrAHistoriaGalapagos()
    {
        SceneManager.LoadScene("HistoriaGalapagos");
    }
    public void IrANivelCostaManabi()
    {
        SceneManager.LoadScene("Nivel_Costa_Manabi");
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