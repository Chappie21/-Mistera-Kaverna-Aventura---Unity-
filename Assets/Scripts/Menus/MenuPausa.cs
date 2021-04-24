using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject vistaControles;
    public AudioSource musicaFondo;
    public AudioSource musicaMenupausa;
    public static bool juegoPausado;

    // Start is called before the first frame update
    void Start()
    {
        menuPausa.SetActive(false);
        vistaControles.SetActive(false);
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
        musicaMenupausa.Play();
    }

    public void ReanudarJuego()
    {
        menuPausa.SetActive(false);
        Time.timeScale=1f;
        juegoPausado=false;
        musicaFondo.Play(0);
        musicaMenupausa.Stop();

    }

    public void IrAlMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void VerControles(){
        vistaControles.SetActive(true);
    }

    public void SalirControles(){
        vistaControles.SetActive(false);
    }

    public void SalirDelJuego()
    {
        Debug.Log("Salir del juego...");
        Application.Quit();
    }
}
