using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject btnCyferkaPrefab;
    [SerializeField] Transform kontenernaCyferki;
    [SerializeField] Text txtLiczbaDocelowa;
    [SerializeField] Text txtLiczbaPkt;
    [SerializeField] Text txtLicznikCzasu;
    int liczbaDocelowa = 21;
    int liczbaPkt = 0;
    float licznikPoczatkowy = 30f;
    float licznik;
    void Start()
    {
        StartCoroutine(TworzNowaCyferke());
        txtLiczbaDocelowa.text = liczbaDocelowa.ToString();
        licznik = licznikPoczatkowy;
    }

    public int PobierzIlePktZostalo()
    {
        return liczbaDocelowa - liczbaPkt;
    }

    IEnumerator TworzNowaCyferke()
    {
        GameObject nowaCyferka = Instantiate(btnCyferkaPrefab, kontenernaCyferki);
        int losowaPozycjaX = Random.Range(-140,141);
        nowaCyferka.GetComponent<RectTransform>().anchoredPosition = new Vector2(losowaPozycjaX, 400f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(TworzNowaCyferke());
    }

    void AktualizujElementyUI()
    {
        txtLiczbaPkt.text = liczbaPkt.ToString();
    }

    public void DodajPkt(int punkty)
    {
        liczbaPkt += punkty;
    }

    void OdliczajCzas()
    {
        if(licznik > 0)
        {
            licznik -= Time.deltaTime;
            txtLicznikCzasu.text = licznik.ToString("f2");
            ZmienKolorLicznika();
        }
        else
        {
            GameOver();
        }
    }

    public void SprawdzStatusGry()
    {
        if(licznik > 0)
        {
            if(liczbaPkt == liczbaDocelowa)
            {
                WinGame();
            }
            else if(liczbaPkt > liczbaDocelowa)
            {
                GameOver();
            }
        }
        else
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    void WinGame()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void ZmienKolorLicznika() 
    {
        if(licznik <= 5)
        {
            txtLicznikCzasu.color = Color.red;
        }
        else if(licznik <= 10)
        {
            txtLicznikCzasu.color = Color.yellow;
        }
    }

    void Update()
    {
        AktualizujElementyUI();
        OdliczajCzas();
        SprawdzStatusGry();
    }
}
