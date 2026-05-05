using System;
using System.Collections;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoscript : MonoBehaviour
{
    public GameObject Return;
    public VideoPlayer player;
    public float sec = 10;
    public AudioSource audio1;
    public int scene = 0;

    private void Start()
    {
        audio1 = GameObject.FindGameObjectWithTag("rbd").GetComponent<AudioSource>();
    }
    public void ReturnByDeath()
    {
        Return.SetActive(true);
        player.Play();
        StartCoroutine(waiter(sec));
        
    }
    IEnumerator waiter(float sec)
    {

        yield return new WaitForSeconds(sec - 1.5f);
        audio1.Play();
        yield return new WaitForSeconds(1.5f);
        Return.SetActive(false);
        SceneManager.LoadScene(scene);
    }


}
