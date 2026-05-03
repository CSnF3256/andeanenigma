using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistoriaManager : MonoBehaviour
{
    public TMP_Text textoHistoria;
    public TMP_Text textoContinuar;

    public Image imagenHistoria;
    public Sprite[] imagenesPaso;

    public Button botonPantalla;
    public GameObject artefacto;

    private int pasoActual = 0;

    private string[] dialogos = new string[]
    {
        "Como investigador entras en una sala sobria, iluminada apenas por una pantalla azulada. Frente a él, una representante de la empresa YachayTech Expeditions revisa tu expediente sin levantar demasiado la mirada.",
        "Carla: Su perfil es interesante. Experiencia en campo, análisis de símbolos y resistencia bajo presión. Pero en esta empresa no contratamos solo por currículum.",
        "Carla: Esta es su oportunidad.",
        "Carla: Antes de ofrecerle el puesto, deberá resolver una prueba sencilla. Observe con cuidado. En las ruinas, un error pequeño puede cerrar una puerta… o despertar algo peor.",
        "Ante tus ojos ves un pequeño artefacto que comienza a brillar. Tócalo para iniciar el primer desafío."
    };

    void Start()
    {
        pasoActual = 0;

        if (artefacto != null)
        {
            artefacto.SetActive(false);
        }

        MostrarPaso();
    }

    public void SiguientePaso()
    {
        if (pasoActual < dialogos.Length - 1)
        {
            pasoActual++;
            MostrarPaso();
        }
    }

    void MostrarPaso()
    {
        if (textoHistoria != null)
        {
            textoHistoria.text = dialogos[pasoActual];
        }

        if (imagenHistoria != null && imagenesPaso != null && pasoActual < imagenesPaso.Length)
        {
            if (imagenesPaso[pasoActual] != null)
            {
                imagenHistoria.sprite = imagenesPaso[pasoActual];
            }
        }

        if (pasoActual == dialogos.Length - 1)
        {
            MostrarArtefactoFinal();
        }
        else
        {
            OcultarArtefacto();
        }
    }

    void MostrarArtefactoFinal()
    {
        if (artefacto != null)
        {
            artefacto.SetActive(true);

            // Hace que el artefacto se dibuje encima de los demás elementos del Canvas
            artefacto.transform.SetAsLastSibling();
        }

        if (textoContinuar != null)
        {
            textoContinuar.gameObject.SetActive(false);
        }

        if (botonPantalla != null)
        {
            botonPantalla.gameObject.SetActive(false);
        }
    }

    void OcultarArtefacto()
    {
        if (artefacto != null)
        {
            artefacto.SetActive(false);
        }

        if (textoContinuar != null)
        {
            textoContinuar.gameObject.SetActive(true);
        }

        if (botonPantalla != null)
        {
            botonPantalla.gameObject.SetActive(true);
        }
    }
}