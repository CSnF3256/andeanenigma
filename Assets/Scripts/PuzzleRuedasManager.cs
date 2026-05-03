using UnityEngine;
using TMPro;

public class PuzzleRuedasManager : MonoBehaviour
{
    public AnilloRotador[] anillos;

    [Header("UI")]
    public TMP_Text textoResultado;
    public GameObject panelAcierto;

    [Header("Solución")]
    public TipoSimbolo simboloObjetivo = TipoSimbolo.Colibri;

    private bool puzzleResuelto = false;

    void Start()
    {
        puzzleResuelto = false;

        if (textoResultado != null)
            textoResultado.text = "";

        if (panelAcierto != null)
            panelAcierto.SetActive(false);
    }

    public void VerificarPuzzle()
    {
        if (puzzleResuelto) return;

        if (anillos == null || anillos.Length == 0) return;

        for (int i = 0; i < anillos.Length; i++)
        {
            if (anillos[i].ObtenerSimboloFrente() != simboloObjetivo)
            {
                if (textoResultado != null)
                    textoResultado.text = "Cuando las alas del guardián de la Sierra miren hacia el mismo destino, el artefacto revelará su camino.";
                return;
            }
        }

        ResolverPuzzle();
    }

    void ResolverPuzzle()
    {
        puzzleResuelto = true;

        if (textoResultado != null)
            textoResultado.text = "¡Correcto!";

        if (panelAcierto != null)
            panelAcierto.SetActive(true);
    }
}