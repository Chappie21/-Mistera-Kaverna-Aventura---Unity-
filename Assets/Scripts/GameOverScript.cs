using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject vistaGameOver;
    //public static bool jugadorMuerto;

    void Start(){
        vistaGameOver.SetActive(false);
    }

    void Update(){
        if(PlayerController.vidaActual<=0){
            vistaGameOver.SetActive(true);
            // Time.timeScale=0f;
        }
    }

    public void Continuar(){
        // Time.timeScale=1f;
        SceneManager.LoadScene("MenuScene");
    }
}
