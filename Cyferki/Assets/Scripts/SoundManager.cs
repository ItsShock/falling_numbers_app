using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audios;
    [SerializeField] AudioClip[] plikiDzwiekowe;
    private void Awake()
    {
        GameObject[] sm = GameObject.FindGameObjectsWithTag("SoundManager");
        if(sm.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audios  =GetComponent<AudioSource>();
    }

    public void OdtworzDzwiek(int numerKlipu)
    {
        audios.clip = plikiDzwiekowe[numerKlipu];
        audios.Play();
    }
}
