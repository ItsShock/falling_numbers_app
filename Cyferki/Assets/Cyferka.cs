using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cyferka : MonoBehaviour
{
    [SerializeField] Sprite spriteSplash;
    [SerializeField] Sprite[] spriteCyferki;
    RectTransform rt;
    float predkoscOpadania = 100f;
    GameManager gm;
    Animator anim;
    int wybranaLiczba;
    void Start()
    {
        anim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); 
        PrzypiszWartoscCyferki();
        rt = GetComponent<RectTransform>();
    }

    void PrzypiszWartoscCyferki()
    {
        int LosowaLiczba = Random.Range(1, 7);
        wybranaLiczba = LosowaLiczba;
        GetComponent<Image>().sprite = spriteCyferki[LosowaLiczba - 1];
        
    }

    public void AkcjapoKliknieciu()
    {
        gm.DodajPkt(wybranaLiczba);
        AktywujSplasha();
        anim.SetTrigger("Znikanie");
        ZmienKolorBtn();
        GetComponent<Button>().interactable = false;
        UsunCyferke(0.5f);
    }

    void AktywujSplasha()
    {
        GetComponent<Image>().sprite = spriteSplash;
    }

    void SpadajwDol()
    {
        rt.anchoredPosition -= new Vector2(0f, 1f) * predkoscOpadania * Time.deltaTime;
    }

    void UsunCyferke(float time)
    {
        Destroy(gameObject, time);
    }

    void ZmienKolorBtn()
    {
        ColorBlock blokKolorow = GetComponent<Button>().colors;
        switch (wybranaLiczba)
        {
            case 1: blokKolorow.disabledColor = Color.red;
                break;
            case 2:
                blokKolorow.disabledColor = new Color(0.80f, 0.94f, 0f, 1f);
                break;
            case 3:
                blokKolorow.disabledColor = Color.green;
                break;
            case 4:
                blokKolorow.disabledColor = new Color(0.73f, 0.21f, 0.66f, 1f);
                break;
            case 5:
                blokKolorow.disabledColor = Color.blue;
                break;
            case 6:
                blokKolorow.disabledColor = new Color(0.19f, 0.43f, 0.49f, 1f);
                break;
            default:
                blokKolorow.disabledColor = Color.black;
                break;

        }
        GetComponent<Button>().colors = blokKolorow;
    }
    
    void Update()
    {
        SpadajwDol();
        if(rt.anchoredPosition.y < -400)
        {
            UsunCyferke(0f);
        }
    }
}
