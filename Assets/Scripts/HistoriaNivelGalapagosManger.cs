using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistoriaNivelGalapagosManager : MonoBehaviour
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
        "Kora: Frente a nosotros están las islas Galápagos. El mar parece tranquilo, pero el artefacto ha empezado a alterar las corrientes que conectan el archipiélago.",
        "Kora: Fue encontrado incrustado en una formación volcánica, cubierto por sal, coral y marcas antiguas que no pertenecen a ninguna expedición conocida.",
        "Kora: Mira con atención. La tortuga, el pinzón y la iguana marina no son simples símbolos. Cada uno representa una clave del equilibrio de estas islas.",
        "Kora: El mecanismo está dividido en varios módulos: corrientes marinas, especies guía, placas volcánicas y una secuencia de adaptación.",
        "Kora: Cuando comprendas cómo se conectan las islas, podrás activar el núcleo insular y detener la señal del artefacto."
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
            textoHistoria.text = "Kora: El artefacto insular está listo. Inicia el protocolo de estabilización.";

        if (textoContinuar != null)
            textoContinuar.gameObject.SetActive(false);

        if (botonAvanzarHistoria != null)
            botonAvanzarHistoria.SetActive(false);

        if (botonIniciarNivel != null)
            botonIniciarNivel.SetActive(true);
    }
}