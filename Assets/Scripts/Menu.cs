using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void IniciarJuego()
    {
        //System.Threading.Thread.Sleep(5000);
        SceneManager.LoadScene(1);
        Debug.Log("Escena");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SalirDelJuego(){
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
