using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CostaLevelManager : MonoBehaviour
{
    [Header("UI principal")]
    public TMP_Text textoTiempo;
    public TMP_Text textoProgreso;
    public TMP_Text textoResultado;
    public Image barraTiempo;
    public Button botonDesactivar;
    public GameObject botonVolverNiveles;

    [Header("Configuración del nivel")]
    public float tiempoInicial = 75f;
    public int totalModulos = 4;

    private float tiempoActual;
    private int modulosResueltos = 0;
    private bool nivelTerminado = false;

    [Header("Botón reiniciar")]
    public GameObject botonReiniciarNivel;

    [Header("Animación final del nivel")]
    public GameObject animacionVictoriaCosta;
    public Animator animatorVictoriaCosta;
    public string nombreAnimacionVictoria = "VictoriaCosta";

    [Header("Audio")]
    public AudioSource musicaNivel;
    public AudioSource sonidoVictoria;

    void Start()
    {
        tiempoActual = tiempoInicial;
        modulosResueltos = 0;
        nivelTerminado = false;

        if (textoResultado != null)
            textoResultado.text = "";

        if (botonDesactivar != null)
            botonDesactivar.interactable = false;

        if (botonVolverNiveles != null)
            botonVolverNiveles.SetActive(false);

        if (botonReiniciarNivel != null)
        {
            botonReiniciarNivel.SetActive(false);
        }

        if (animacionVictoriaCosta != null)
        {
            animacionVictoriaCosta.SetActive(false);
        }

        ActualizarUI();
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        if (nivelTerminado) return;

        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {
            tiempoActual = 0;
            PerderNivel();
        }

        ActualizarUI();
    }

    public void RegistrarModuloResuelto()
    {
        if (nivelTerminado) return;

        modulosResueltos++;
        ActualizarUI();

        if (textoResultado != null)
            textoResultado.text = "Módulo resuelto. Progreso: " + modulosResueltos + "/" + totalModulos;

        if (modulosResueltos >= totalModulos)
        {
            if (textoResultado != null)
                textoResultado.text = "Todos los módulos están resueltos. Puedes desactivar el artefacto.";

            if (botonDesactivar != null)
                botonDesactivar.interactable = true;
        }
    }

    public void DesactivarArtefacto()
    {
        if (nivelTerminado) return;
        if (modulosResueltos < totalModulos) return;

        nivelTerminado = true;

        // Detener música del nivel
        if (musicaNivel != null)
        {
            musicaNivel.Stop();
        }

        // Reproducir sonido de victoria
        if (sonidoVictoria != null)
        {
            sonidoVictoria.Play();
        }

        if (textoResultado != null)
            textoResultado.text = "Artefacto desactivado. Nivel 2 completado. Ve a la Amazonía.";

        if (botonDesactivar != null)
            botonDesactivar.interactable = false;

        if (animacionVictoriaCosta != null)
        {
            animacionVictoriaCosta.SetActive(true);
            animacionVictoriaCosta.transform.SetAsLastSibling();
        }

        if (animatorVictoriaCosta != null)
        {
            animatorVictoriaCosta.Play(nombreAnimacionVictoria);
        }

        if (botonVolverNiveles != null)
        {
            botonVolverNiveles.SetActive(true);
            botonVolverNiveles.transform.SetAsLastSibling();
        }
    }
    public void MostrarPistaQuipu()
    {
        if (textoResultado != null)
        {
            textoResultado.text = "Kora: Las semillas revelaron la clave del quipu.PEZ = 5 , OLA = 3, CONCHA = 1.";
        }
    }

    void PerderNivel()
    {
        nivelTerminado = true;

        if (textoResultado != null)
            textoResultado.text = "Fallo: el artefacto emitió la señal.";

        if (botonDesactivar != null)
            botonDesactivar.interactable = false;
        if (botonReiniciarNivel != null)
        {
            botonReiniciarNivel.SetActive(true);
        }
    }
    public void MostrarPistaOlas()
    {
        if (textoResultado != null)
        {
            textoResultado.text =
                "Kora: Para estabilizar el patrón de olas, activa las celdas como una cruz diagonal X";
        }
    }

    public void MostrarPistaConexiones()
    {
        if (textoResultado != null)
        {
            textoResultado.text =
                "Kora: El artefacto responde al ritmo del litoral.\n" +
                "El mar permanece quieto, el pez da un salto, el sol marca dos pulsos y la luna completa tres.";
        }
    }
    void ActualizarUI()
    {
        if (textoTiempo != null)
            textoTiempo.text = Mathf.Ceil(tiempoActual).ToString("00");

        if (textoProgreso != null)
            textoProgreso.text = modulosResueltos + "/" + totalModulos;

        if (barraTiempo != null)
            barraTiempo.fillAmount = tiempoActual / tiempoInicial;
    }

    public void IrANiveles()
    {
        SceneManager.LoadScene("Niveles");
    }
}