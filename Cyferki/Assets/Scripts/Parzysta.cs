using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parzysta : MonoBehaviour
{
    [SerializeField] Text txtParzysta;
    bool czyNastepnaCyfraMaBycParzysta;
    int KliknietaCyfra;
    bool czKliknietaCyfrajestParzysta;
    string wiadomosOPatrzystosci;
    void Start()
    {
        LosyjWarunek();
    }

    public void LosyjWarunek()
    {
        if(GetComponent<GameManager>().PobierzIlePktZostalo() == 1)
        {
            czyNastepnaCyfraMaBycParzysta = false;
            wiadomosOPatrzystosci = "Nieparzysta";
            txtParzysta.color = Color.blue;
        }
        else
        {
            int losowaliczba = Random.Range(0,2);
            if(losowaliczba == 0)
            {
            czyNastepnaCyfraMaBycParzysta = true;
            wiadomosOPatrzystosci = "Parzysta";
            txtParzysta.color = Color.red;
            }
            else
            {
            czyNastepnaCyfraMaBycParzysta = false;
            wiadomosOPatrzystosci = "Nieparzysta";
            txtParzysta.color = Color.blue;
            }
        }
        txtParzysta.text = wiadomosOPatrzystosci;
     }  
    public void PobierzKliknietaCyfre(int cyferka)
        {
            KliknietaCyfra = cyferka;
            SprawdzKlikniecie();
        }

    void SprawdzKlikniecie()
        {
            if(KliknietaCyfra % 2 == 0)
            {
                czKliknietaCyfrajestParzysta = true;
            }
            else
            {
                czKliknietaCyfrajestParzysta = false;
            }

            if(czKliknietaCyfrajestParzysta == czyNastepnaCyfraMaBycParzysta)
            {
                LosyjWarunek();
            }
            else
            {
                GetComponent<GameManager>().GameOver();
            }
        }
    

    
    void Update()
    {
        
    }
}
