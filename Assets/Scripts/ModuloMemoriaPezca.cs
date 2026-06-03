using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ModuloMemoriaPesca : MonoBehaviour
{
    public CostaLevelManager levelManager;
    public Button[] cartas;
    public TMP_Text[] textosCartas;
    public TMP_Text textoPares;

    private string[] simbolos = new string[]
    {
        "Mar", "Pez", "Sol", "Luna",
        "Mar", "Pez", "Sol", "Luna"
    };

    private int primera = -1;
    private int segunda = -1;

    private int paresEncontrados = 0;
    private bool bloqueado = false;
    private bool resuelto = false;

    void Start()
    {
        for (int i = 0; i < textosCartas.Length; i++)
        {
            textosCartas[i].text = "?";
        }

        ActualizarPares();
    }

    public void SeleccionarCarta(int indice)
    {
        if (resuelto || bloqueado) return;

        if (textosCartas[indice].text != "?") return;

        textosCartas[indice].text = simbolos[indice];

        if (primera == -1)
        {
            primera = indice;
        }
        else
        {
            segunda = indice;
            StartCoroutine(VerificarPar());
        }
    }

    IEnumerator VerificarPar()
    {
        bloqueado = true;

        yield return new WaitForSeconds(0.6f);

        if (simbolos[primera] == simbolos[segunda])
        {
            paresEncontrados++;
            ActualizarPares();

            if (paresEncontrados >= 4)
            {
                resuelto = true;
                Debug.Log("Módulo Memoria resuelto.");

                if (levelManager != null)
                    levelManager.RegistrarModuloResuelto();
            }
        }
        else
        {
            textosCartas[primera].text = "?";
            textosCartas[segunda].text = "?";
        }

        primera = -1;
        segunda = -1;
        bloqueado = false;
    }

    void ActualizarPares()
    {
        if (textoPares != null)
            textoPares.text = "Pares encontrados: " + paresEncontrados + "/4";
    }
}