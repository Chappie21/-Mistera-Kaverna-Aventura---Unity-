using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public AudioSource musicaFondo;
    public static bool juegoPausado;

    // Start is called before the first frame update
    void Start()
    {
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        menuPausa.SetActive(true);
        Time.timeScale=0f;
        juegoPausado=true;
        musicaFondo.Pause();
    }

    public void ReanudarJuego()
    {
        menuPausa.SetActive(false);
        Time.timeScale=1f;
        juegoPausado=false;
        musicaFondo.Play(0);

    }

    public void IrAlMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void SalirDelJuego()
    {
        Debug.Log("Salir del juego...");
        Application.Quit();
    }
}
