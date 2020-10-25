using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject activate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.currentState = States.PLAY;
            if (activate != null)
            {
                activate.SetActive(true);
                Fade.instance.Darken();
            }
        }
        SceneManager.LoadScene(1);
    }
}
