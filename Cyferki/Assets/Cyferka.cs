using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cyferka : MonoBehaviour
{
    RectTransform rt;
    GameObject txtCyferka;
    float predkoscOpadania = 100f;
    GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        txtCyferka = gameObject.transform.GetChild(0).gameObject;
        PrzypiszWartoscTxt();
        rt = GetComponent<RectTransform>();
    }

    void PrzypiszWartoscTxt()
    {
        int LosowaLiczba = Random.Range(1, 7);
        txtCyferka.GetComponent<Text>().text = LosowaLiczba.ToString();
    }

    public void PobierzWartosczPolaTxt()
    {
        int wybranaLiczba = System.Int32.Parse(txtCyferka.GetComponent<Text>().text);
        gm.DodajPkt(wybranaLiczba);
    }

    void SpadajwDol()
    {
        rt.anchoredPosition -= new Vector2(0f, 1f) * predkoscOpadania * Time.deltaTime;
    }

    void UsunCyferke()
    {
        Destroy(gameObject);
    }
    
    void Update()
    {
        SpadajwDol();
        if(rt.anchoredPosition.y < -400)
        {
            UsunCyferke();
        }
    }
}
