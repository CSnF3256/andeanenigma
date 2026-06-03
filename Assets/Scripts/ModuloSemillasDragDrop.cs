using UnityEngine;
using TMPro;

public class ModuloSemillasDragDrop : MonoBehaviour
{
    [Header("Level Manager")]
    public AmazoniaLevelManager levelManager;

    [Header("Platos")]
    public RectTransform plato1;
    public RectTransform plato2;
    public RectTransform plato3;

    [Header("Semillas")]
    public SemillaDrag semillaG;
    public SemillaDrag semillaC;
    public SemillaDrag semillaU;
    public SemillaDrag semillaI;

    [Header("UI")]
    public TMP_Text textoResultado;

    [Header("Configuración")]
    public float distanciaParaEncajar = 80f;

    private string plato1Letra = "";
    private string plato2Letra = "";
    private string plato3Letra = "";

    private bool resuelto = false;

    public bool IntentarColocarSemilla(SemillaDrag semilla)
    {
        if (resuelto) return false;

        RectTransform semillaRect = semilla.GetComponent<RectTransform>();

        float d1 = Vector2.Distance(semillaRect.anchoredPosition, plato1.anchoredPosition);
        float d2 = Vector2.Distance(semillaRect.anchoredPosition, plato2.anchoredPosition);
        float d3 = Vector2.Distance(semillaRect.anchoredPosition, plato3.anchoredPosition);

        if (d1 <= distanciaParaEncajar && plato1Letra == "")
        {
            plato1Letra = semilla.letraSemilla;
            semilla.ColocarEn(plato1.anchoredPosition);
            return true;
        }

        if (d2 <= distanciaParaEncajar && plato2Letra == "")
        {
            plato2Letra = semilla.letraSemilla;
            semilla.ColocarEn(plato2.anchoredPosition);
            return true;
        }

        if (d3 <= distanciaParaEncajar && plato3Letra == "")
        {
            plato3Letra = semilla.letraSemilla;
            semilla.ColocarEn(plato3.anchoredPosition);
            return true;
        }

        return false;
    }

    public void Confirmar()
    {
        if (resuelto) return;

        if (plato1Letra == "G" && plato2Letra == "C" && plato3Letra == "I")
        {
            resuelto = true;

            if (textoResultado != null)
            {
                textoResultado.text = "Semillas alineadas correctamente.";
            }

            if (levelManager != null)
            {
                levelManager.RegistrarModuloResuelto();
                levelManager.MostrarPistaQuipu();
            }
        }
        else
        {
            if (textoResultado != null)
            {
                textoResultado.text = "El orden no es correcto. Intenta de nuevo.";
            }
        }
       
    }

    public void Limpiar()
    {
        if (resuelto) return;

        plato1Letra = "";
        plato2Letra = "";
        plato3Letra = "";

        if (semillaG != null) semillaG.Reiniciar();
        if (semillaC != null) semillaC.Reiniciar();
        if (semillaU != null) semillaU.Reiniciar();
        if (semillaI != null) semillaI.Reiniciar();

        if (textoResultado != null)
        {
            textoResultado.text = "";
        }
    }
}