using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _dinoSound1;
    [SerializeField] private AudioClip _dinoSound2;
    [SerializeField] private AudioClip _dinoSound3;
    [SerializeField] private AudioClip[] _dinoSounds; 
    [SerializeField] private AudioClip _Jump;
    [SerializeField] private AudioClip _death;
    [SerializeField] private AudioClip _GameOver;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Dino());
        
    }
    void Update()
    {
    }

    IEnumerator Dino()
    {
        yield return new WaitForSeconds(Random.Range(15,30));
        audioSource.PlayOneShot(_dinoSounds[Random.Range(0,_dinoSounds.Length)],.1f);
        Debug.Log("sound");

        StartCoroutine(Dino());

    }
    
    public void Dinosounds()
    {
        audioSource.PlayOneShot(_dinoSounds[Random.Range(0,_dinoSounds.Length)],.01f);
        Debug.Log("sound");
    }
    public void jupm()
    {
        audioSource.PlayOneShot(_Jump,.5f);
        
    }
    public void Death()
    {
        audioSource.PlayOneShot(_death,.4f);
        audioSource.PlayOneShot(_GameOver,.5f);
    }

    public void Dinosound1()
    {
        audioSource.PlayOneShot(_dinoSound1);
    }
    public void Dinosound2()
    {
        audioSource.PlayOneShot(_dinoSound2);
    }
    public void Dinosound3()
    {
        audioSource.PlayOneShot(_dinoSound3);
    }

}
