using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistoriaNivelCostaManager : MonoBehaviour
{
    public TMP_Text textoHistoria;
    public TMP_Text textoContinuar;
    public Image imagenHistoria;
    public Sprite[] imagenesPaso;

    public GameObject botonAvanzar;
    public GameObject botonIniciarNivel;

    private int pasoActual = 0;

    private string[] dialogos = new string[]
    {
        "El equipo de la Entidad Operativa encontró el segundo artefacto enterrado entre fragmentos de cerámica Valdivia de cinco mil años.",
        "Kora: Los pulsos electromagnéticos van en aumento. Si no lo neutralizamos en 75 segundos, borrará toda la evidencia digital.",
        "Investigador: Los Valdivia eran grandes navegantes y comerciantes del Pacífico. Este dispositivo funciona como sus redes: todo conectado, todo interdependiente.",
        "Kora: ¿Qué necesitas?",
        "Investigador: Silencio. El Arquitecto dejó pistas para alguien que supiera escuchar. Yo sé escuchar.",
        "Kora: Empezemos"
    };

    void Start()
    {
        pasoActual = 0;

        if (botonIniciarNivel != null)
            botonIniciarNivel.SetActive(false);

        MostrarPaso();
    }

    public void SiguientePaso()
    {
        if (pasoActual < dialogos.Length - 1)
        {
            pasoActual++;
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
        if (textoContinuar != null)
            textoContinuar.text = "Iniciar nivel 2 — La Costa";

        if (botonAvanzar != null)
            botonAvanzar.SetActive(false);

        if (botonIniciarNivel != null)
            botonIniciarNivel.SetActive(true);
    }
}