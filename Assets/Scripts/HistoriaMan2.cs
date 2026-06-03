using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniHistoriaManager : MonoBehaviour
{
    [Header("Elementos UI de historia")]
    public TMP_Text textoHistoria;
    public TMP_Text textoContinuar;
    public Image imagenHistoria;

    [Header("Imágenes de la mini historia")]
    public Sprite[] imagenesPaso;

    [Header("Botón de avanzar historia")]
    public GameObject botonAvanzarHistoria;

    [Header("Drag and Drop de Kora")]
    public GameObject koraDrag;
    public GameObject slotKora;
    public TMP_Text textoDrag;

    [Header("Animación de Kora")]
    public GameObject animacionKora;

    [Header("Resultado final")]
    public GameObject panelActivacionKora;
    public GameObject botonIrNiveles;

    private int pasoActual = 0;
    private bool esperandoDrag = false;
    private bool historiaTerminada = false;

    private string[] dialogos = new string[]
    {
        "El artefacto emite un pulso de luz. Las ruedas han reconocido el vuelo del colibrí.",
        "Carla: Excelente trabajo. Has demostrado tu habilidad para comprender este tipo de mecanismos.",
        "Carla: Empiezas desde ahora. En el panel de niveles, puedes completar tus próximas tareas.",
        "Me pregunto para qué necesitan mi ayuda descifrando estos artefactos.",
        "Carla: Es pura investigación, con el tiempo lo irás comprendiendo mejor... Ahora viajamos a la Costa, prepárate.",
        "Carla: Este es Kora, la mascota de la empresa. Es un búho que te ayudará con tus tareas, experto en historia y símbolos. No dudes en consultarle cualquier duda sobre los artefactos o las misiones."
    };

    void Start()
    {
        pasoActual = 0;
        esperandoDrag = false;
        historiaTerminada = false;

        OcultarDragKora();
        OcultarResultadoFinal();

        if (animacionKora != null)
        {
            animacionKora.SetActive(false);
        }

        MostrarPaso();
    }

    public void SiguientePaso()
    {
        if (historiaTerminada || esperandoDrag)
        {
            return;
        }

        if (pasoActual < dialogos.Length - 1)
        {
            pasoActual++;
            MostrarPaso();
        }
        else
        {
            MostrarDragKora();
        }
    }

    void MostrarPaso()
    {
        if (textoHistoria != null)
        {
            textoHistoria.text = dialogos[pasoActual];
        }

        if (textoContinuar != null)
        {
            if (pasoActual == dialogos.Length - 1)
            {
                textoContinuar.text = "Haz clic para recibir a Kora";
            }
            else
            {
                textoContinuar.text = "Haz clic para continuar";
            }
        }

        if (imagenHistoria != null && imagenesPaso != null && pasoActual < imagenesPaso.Length)
        {
            if (imagenesPaso[pasoActual] != null)
            {
                imagenHistoria.sprite = imagenesPaso[pasoActual];
            }
        }
    }

    void MostrarDragKora()
    {
        esperandoDrag = true;

        if (botonAvanzarHistoria != null)
        {
            botonAvanzarHistoria.SetActive(false);
        }

        if (textoContinuar != null)
        {
            textoContinuar.gameObject.SetActive(false);
        }

        if (textoHistoria != null)
        {
            textoHistoria.text = "Arrastra a Kora hacia el módulo de guía para activar su asistencia.";
        }

        if (koraDrag != null)
        {
            koraDrag.SetActive(true);
        }

        if (slotKora != null)
        {
            slotKora.SetActive(true);
        }

        if (textoDrag != null)
        {
            textoDrag.gameObject.SetActive(true);
        }

        if (animacionKora != null)
        {
            animacionKora.SetActive(false);
        }
    }

    public void ActivarKoraCompletado()
    {
        esperandoDrag = false;
        historiaTerminada = true;

        if (textoDrag != null)
        {
            textoDrag.gameObject.SetActive(false);
        }

        if (koraDrag != null)
        {
            koraDrag.SetActive(false);
        }

        if (slotKora != null)
        {
            slotKora.SetActive(false);
        }

        if (textoHistoria != null)
        {
            textoHistoria.text = "Kora ha sido sincronizado con tu equipo. El panel de niveles está disponible.";
        }

        if (animacionKora != null)
        {
            animacionKora.SetActive(true);
        }

        if (panelActivacionKora != null)
        {
            panelActivacionKora.SetActive(true);
        }

        if (botonIrNiveles != null)
        {
            botonIrNiveles.SetActive(true);
        }
    }

    void OcultarDragKora()
    {
        if (koraDrag != null)
        {
            koraDrag.SetActive(false);
        }

        if (slotKora != null)
        {
            slotKora.SetActive(false);
        }

        if (textoDrag != null)
        {
            textoDrag.gameObject.SetActive(false);
        }
    }

    void OcultarResultadoFinal()
    {
        if (panelActivacionKora != null)
        {
            panelActivacionKora.SetActive(false);
        }

        if (botonIrNiveles != null)
        {
            botonIrNiveles.SetActive(false);
        }
    }
}