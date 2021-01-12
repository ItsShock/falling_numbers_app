using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject btnCyferkaPrefab;
    [SerializeField] Transform kontenernaCyferki;
    void Start()
    {
        StartCoroutine(TworzNowaCyferke());
    }

    IEnumerator TworzNowaCyferke()
    {
        GameObject nowaCyferka = Instantiate(btnCyferkaPrefab, kontenernaCyferki);
        int losowaPozycjaX = Random.Range(-140,141);
        nowaCyferka.GetComponent<RectTransform>().anchoredPosition = new Vector2(losowaPozycjaX, 400f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(TworzNowaCyferke());
    }
    void Update()
    {
        
    }
}
