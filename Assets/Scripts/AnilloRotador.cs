using UnityEngine;

public enum TipoSimbolo
{
    Colibri,
    Tortuga,
    Jaguar
}

public class AnilloRotador : MonoBehaviour
{
    public RectTransform contenidoRueda;

    [Header("Configuración de giro")]
    public int totalPasos = 3;
    public int pasoActual = 0;
    public float anguloPorPaso = 120f;

    [Header("Símbolo visible en cada paso")]
    public TipoSimbolo[] simboloEnFrentePorPaso;

    [Header("Manager")]
    public PuzzleRuedasManager manager;

    void Start()
    {
        ActualizarVisual();
    }

    public void GirarPorClic()
    {
        pasoActual++;

        if (pasoActual >= totalPasos)
        {
            pasoActual = 0;
        }

        ActualizarVisual();

        if (manager != null)
        {
            manager.VerificarPuzzle();
        }
    }

    void ActualizarVisual()
    {
        if (contenidoRueda != null)
        {
            contenidoRueda.localRotation = Quaternion.Euler(0f, 0f, -pasoActual * anguloPorPaso);
            contenidoRueda.localScale = Vector3.one;
        }
    }

    public TipoSimbolo ObtenerSimboloFrente()
    {
        if (simboloEnFrentePorPaso == null || simboloEnFrentePorPaso.Length == 0)
        {
            return TipoSimbolo.Colibri;
        }

        return simboloEnFrentePorPaso[pasoActual];
    }
}