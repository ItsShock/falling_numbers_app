using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGlowne : MonoBehaviour
{
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
