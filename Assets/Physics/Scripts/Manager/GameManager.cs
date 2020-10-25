using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum States
{
    PLAY,
    PAUSE,
    GAMEOVER,
    WIN
}

public class GameManager : MonoBehaviour
{
    public States currentState;
    public List<GameObject> menus;
    public GameObject crosshair;
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != this)
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        currentState = States.PLAY;
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case States.PLAY:
                Time.timeScale = 1;
                foreach(GameObject g in menus)
                {
                    if(g.activeSelf)
                    {
                        g.SetActive(false);
                    }
                }
                crosshair.SetActive(true);
                break;
            case States.WIN:
                menus[2].SetActive(true);
                crosshair.SetActive(false);
                Time.timeScale = 0;
                break;
            case States.PAUSE:
                menus[0].SetActive(true);
                crosshair.SetActive(false);
                Time.timeScale = 0;
                break;
            case States.GAMEOVER:
                menus[1].SetActive(true);
                crosshair.SetActive(false);
                Time.timeScale = 0;
                break;
            default:
                break;
        }
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {

            if (InputMan.instance.CheckKeyDown("Pause"))
            {
                if (currentState == States.PAUSE)
                {
                    currentState = States.PLAY;
                }
                else if (currentState == States.PLAY)
                {
                    currentState = States.PAUSE;
                }
            }
        }
        else
        {
            crosshair.SetActive(false);
        }
    }
}
