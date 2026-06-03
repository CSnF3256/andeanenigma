using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AmazoniaLevelManager : MonoBehaviour
{
    [Header("UI principal")]
    public TMP_Text textoTiempo;
    public TMP_Text textoProgreso;
    public TMP_Text textoResultado;
    public Image barraTiempo;
    public Button botonDesactivar;
    public GameObject botonVolverNiveles;

    [Header("Configuración")]
    public float tiempoInicial = 1200f;
    public int totalModulos = 4;
    public GameObject piedraAmazonica;
    public Animator animPiedra;
    private float tiempoActual;
    private int modulosResueltos = 0;
    private bool nivelTerminado = false;

    [Header("Botón reiniciar")]
    public GameObject botonReiniciarNivel;

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

        if (piedraAmazonica != null)
            piedraAmazonica.SetActive(false);

        if (botonReiniciarNivel != null)
        {
            botonReiniciarNivel.SetActive(false);
        }

        ActualizarUI();
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

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RegistrarModuloResuelto()
    {
        if (nivelTerminado) return;

        modulosResueltos++;

        if (textoResultado != null)
            textoResultado.text = "Módulo resuelto. Progreso: " + modulosResueltos + "/" + totalModulos;

        if (modulosResueltos >= totalModulos)
        {
            if (textoResultado != null)
                textoResultado.text = "Todos los módulos están resueltos. Puedes desactivar el artefacto.";

            if (botonDesactivar != null)
                botonDesactivar.interactable = true;
        }

        ActualizarUI();
    }

    public void DesactivarArtefacto()
    {
        if (nivelTerminado) return;
        if (modulosResueltos < totalModulos) return;

        nivelTerminado = true;

        if (textoResultado != null)
            textoResultado.text = "Artefacto amazónico desactivado. Nivel completado. Ve a Galapagos";

        if (piedraAmazonica != null)
            piedraAmazonica.SetActive(true);

        if (animPiedra != null)
            animPiedra.Play("PiedraAparece");

        if (botonVolverNiveles != null)
            botonVolverNiveles.SetActive(true);
        // Detener música de fondo del nivel
        if (musicaNivel != null)
        {
            musicaNivel.Stop();
        }

        // Reproducir sonido de victoria
        if (sonidoVictoria != null)
        {
            sonidoVictoria.Play();
        }
    }

    public void MostrarPistaQuipu()
    {
        if (textoResultado != null)
        {
            textoResultado.text = "Kora: Las semillas revelaron la clave del quipu. Guacamayo = 5, Anaconda = 3, Jaguar = 7 .";
        }
    }

    void PerderNivel()
    {
        nivelTerminado = true;

        if (textoResultado != null)
            textoResultado.text = "Fallo: la temperatura del artefacto activó la señal.";

        if (botonDesactivar != null)
            botonDesactivar.interactable = false;

        if (botonReiniciarNivel != null)
        {
            botonReiniciarNivel.SetActive(true);
        }
    }

    public void MostrarPistaYaku()
    {
        if (textoResultado  != null)
        {
            textoResultado.text =
                "Kora: El río Yaku sigue estos puntos:\n" +
                "(1,4) → (2,4) → (3,4) → (3,3) → (2,3) → (2,2) → (2,1) → (3,1).\n" +
                "X son columnas y Y son filas desde abajo.";
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