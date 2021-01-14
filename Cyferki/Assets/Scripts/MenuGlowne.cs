using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGlowne : MonoBehaviour
{

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().OdtworzDzwiek(2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().OdtworzDzwiek(1);
        }
    }   
    public void ZacznijGre()
    {
        SceneManager.LoadScene(2);
    }

    public void ZamknijGre()
    {
        Application.Quit();
    }

    public void PrzejdDoMenu()
    {
        SceneManager.LoadScene(0);
   }
}
