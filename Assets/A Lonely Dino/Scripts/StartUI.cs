using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip[] _dinoSounds; 
    [SerializeField] private GameObject _AboutPanel;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(DinoAnimation());
        StartCoroutine(Dino());
    }


    IEnumerator DinoAnimation()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("ha");
        yield return new WaitForSeconds(1.8f);
        animator.SetTrigger("ha");
        yield return new WaitForSeconds(7);
        animator.SetTrigger("ground");
        yield return new WaitForSeconds(2.1f);
        animator.SetTrigger("ground");
        yield return new WaitForSeconds(8);
        animator.SetTrigger("haaaa");
        yield return new WaitForSeconds(1);
        animator.SetTrigger("haaaa");
        yield return new WaitForSeconds(9);
        animator.SetTrigger("haa");
        yield return new WaitForSeconds(1);
        animator.SetTrigger("haa");
        yield return new WaitForSeconds(7);
        StartCoroutine(DinoAnimation());

        
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator Dino()
    {
        yield return new WaitForSeconds(Random.Range(10,20));
        audioSource.PlayOneShot(_dinoSounds[Random.Range(0,_dinoSounds.Length)],.1f);
        Debug.Log("sound");

        StartCoroutine(Dino());

    }

    public void AboutPaenlON()
    {
        _AboutPanel.SetActive(true);
    }
    public void AboutPaenlOff()
    {
        _AboutPanel.SetActive(false);
    }
}
