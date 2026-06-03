using UnityEngine;
using TMPro;

public class ModuloYakuRioNapo : MonoBehaviour
{
    public AmazoniaLevelManager levelManager;
    public TMP_Text[] textosPiezas;
    public TMP_Text textoCorrectas;

    private bool resuelto = false;

    private string[] opciones = new string[]
    {
        "·", "─", "│", "┌", "┐", "└", "┘", "V", "J"
    };

    private int[] seleccion = new int[16];

    private string[,] solucionVisual = new string[4, 4]
    {
        { "V", "─", "┐", "·" },
        { "·", "┌", "┘", "·" },
        { "·", "│", "·", "·" },
        { "·", "└", "J", "·" }
    };

    private string[] solucion = new string[16];

    void Awake()
    {
        int k = 0;

        // Conversión porque tus botones están ordenados por columnas:
        // 0,1,2,3 luego 4,5,6,7 luego 8,9,10,11 luego 12,13,14,15
        for (int col = 0; col < 4; col++)
        {
            for (int fila = 0; fila < 4; fila++)
            {
                solucion[k] = solucionVisual[fila, col];
                k++;
            }
        }
    }

    void Start()
    {
        for (int i = 0; i < seleccion.Length; i++)
        {
            seleccion[i] = 0;
        }

        // Fijar la V y la J desde el inicio
        seleccion[0] = BuscarIndiceOpcion("V");
        seleccion[11] = BuscarIndiceOpcion("J");

        ActualizarVisual();
    }

    public void CambiarPieza(int indice)
    {
        if (resuelto) return;

        // No permitir mover la V ni la J
        if (indice == 0 || indice == 11)
        {
            return;
        }

        seleccion[indice]++;

        if (seleccion[indice] >= opciones.Length)
        {
            seleccion[indice] = 0;
        }

        // Evitar que otras piezas se conviertan en V o J
        if (opciones[seleccion[indice]] == "V" || opciones[seleccion[indice]] == "J")
        {
            seleccion[indice] = 0;
        }

        ActualizarVisual();
    }

    public void Confirmar()
    {
        if (resuelto) return;

        int correctas = ContarCorrectas();

        if (correctas == solucion.Length)
        {
            resuelto = true;

            if (textoCorrectas != null)
            {
                textoCorrectas.text = "Piezas correctas: 16/16";
            }

            if (levelManager != null)
            {
                levelManager.RegistrarModuloResuelto();
            }
        }
        else
        {
            Debug.Log("Mapa Yaku incorrecto. Correctas: " + correctas + "/16");
        }
    }

    void ActualizarVisual()
    {
        for (int i = 0; i < textosPiezas.Length; i++)
        {
            textosPiezas[i].text = opciones[seleccion[i]];
        }

        if (textoCorrectas != null)
        {
            textoCorrectas.text = "Piezas correctas: " + ContarCorrectas() + "/16";
        }
    }

    int ContarCorrectas()
    {
        int correctas = 0;

        for (int i = 0; i < solucion.Length; i++)
        {
            if (opciones[seleccion[i]] == solucion[i])
            {
                correctas++;
            }
        }

        return correctas;
    }

    int BuscarIndiceOpcion(string simbolo)
    {
        for (int i = 0; i < opciones.Length; i++)
        {
            if (opciones[i] == simbolo)
            {
                return i;
            }
        }

        return 0;
    }
}