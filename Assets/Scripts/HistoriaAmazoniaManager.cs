using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistoriaNivelAmazoniaManager : MonoBehaviour
{
    [Header("Elementos UI")]
    public TMP_Text textoHistoria;
    public TMP_Text textoContinuar;
    public Image imagenHistoria;

    [Header("Imágenes de la historia")]
    public Sprite[] imagenesPaso;

    [Header("Botones")]
    public GameObject botonAvanzarHistoria;
    public GameObject botonIniciarNivel;

    private int pasoActual = 0;

    private string[] dialogos = new string[]
    {
        "Kora: Hemos llegado a la cuenca del Río Napo. La selva parece tranquila, pero el artefacto está alterando las señales del entorno.",
        "Kora: Este mecanismo no responde a fuerza bruta. Aquí todo está conectado: el río, las semillas, los animales guía y los caminos ocultos.",
        "Kora: Para estabilizarlo tendrás que reconstruir el mapa de Yaku, activar las luces de la selva, ordenar las semillas sagradas y descifrar el quipu amazónico.",
        "Kora: Observa bien cada símbolo. El jaguar, la anaconda y el guacamayo no son decoración; son claves del sistema.",
        "Kora: Cuando todos los módulos estén resueltos, podrás colocar la piedra amazónica en el núcleo del artefacto y desactivarlo."
    };

    void Start()
    {
        pasoActual = 0;

        if (botonIniciarNivel != null)
            botonIniciarNivel.SetActive(false);

        if (botonAvanzarHistoria != null)
            botonAvanzarHistoria.SetActive(true);

        MostrarPaso();
    }

    public void SiguientePaso()
    {
        pasoActual++;

        if (pasoActual < dialogos.Length)
        {
            MostrarPaso();
        }
        else
        {
            TerminarHistoria();
        }
    }

    void MostrarPaso()
    {
        if (textoHistoria != null)
            textoHistoria.text = dialogos[pasoActual];

        if (textoContinuar != null)
            textoContinuar.text = "Haz clic para continuar";

        if (imagenHistoria != null && imagenesPaso != null && pasoActual < imagenesPaso.Length)
        {
            if (imagenesPaso[pasoActual] != null)
                imagenHistoria.sprite = imagenesPaso[pasoActual];
        }
    }

    void TerminarHistoria()
    {
        if (textoHistoria != null)
            textoHistoria.text = "Kora: El artefacto está listo. Inicia el protocolo de estabilización.";

        if (textoContinuar != null)
            textoContinuar.gameObject.SetActive(false);

        if (botonAvanzarHistoria != null)
            botonAvanzarHistoria.SetActive(false);

        if (botonIniciarNivel != null)
            botonIniciarNivel.SetActive(true);
    }
}