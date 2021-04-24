using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMngr : MonoBehaviour
{
    public static AudioClip barraCLlena, barraCUsada, danoEnemigo,
        danoJugador, desenfunde, dropWpn,
        enemyDead, playerDead;

    private static AudioSource audioSrc;

    void Start()
    {
        barraCLlena = Resources.Load<AudioClip>("BarraConcentracionLLena");
        barraCUsada = Resources.Load<AudioClip>("BarraConcentracionUsada");
        danoEnemigo = Resources.Load<AudioClip>("DanoEnemigo");
        danoJugador = Resources.Load<AudioClip>("DanoJugador");
        desenfunde = Resources.Load<AudioClip>("desenfundeArma");
        dropWpn = Resources.Load<AudioClip>("dropArma");
        enemyDead = Resources.Load<AudioClip>("MuerteEnemigo");
        playerDead = Resources.Load<AudioClip>("MuerteJugador");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void Play(string clip)
    {
        switch (clip)
        {
            case "barraCLlena":
                audioSrc.PlayOneShot(barraCLlena);
                break;
            case "barraCUsada":
                audioSrc.PlayOneShot(barraCUsada);
                break;
            case "danoEnemigo":
                audioSrc.PlayOneShot(danoEnemigo);
                break;
            case "danoPlayer":
                audioSrc.PlayOneShot(danoJugador);
                break;
            case "desenfundeArma":
                audioSrc.PlayOneShot(desenfunde);
                break;
            case "dropWpn":
                audioSrc.PlayOneShot(dropWpn);
                break;
            case "muerteEnemigo":
                audioSrc.PlayOneShot(enemyDead);
                break;
            case "muertePlayer":
                audioSrc.PlayOneShot(playerDead);
                break;
            default:
                Debug.Log("No se ha encontrado un audio!");
                break;
        }
    }
}
