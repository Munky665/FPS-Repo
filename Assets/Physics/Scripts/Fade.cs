using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public float fadeTime;
    public static Fade instance;

    // Start is called before the first frame update
    void Start()
    {
        Lighten();

    }

    // Update is called once per frame
    void Update()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        if (this.GetComponent<Image>().color.a == 1)
        {
            GetComponent<Image>().CrossFadeAlpha(0, fadeTime, true);
        }

    }


    public void Darken()
    {
        GetComponent<Image>().CrossFadeAlpha(1, 0, true);
    }

    public void Lighten()
    {
        GetComponent<Image>().CrossFadeAlpha(0, fadeTime, true);
    }

    
}
