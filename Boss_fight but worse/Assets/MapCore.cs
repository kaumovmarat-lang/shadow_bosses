using UnityEngine;
using UnityEngine.SceneManagement;

public class MapCore : MonoBehaviour
{
    public GameObject boss;
    public GameObject sp;
    public GameObject tut;
    public dontdestroy main;

    private void Start()
    {
        main = GameObject.FindGameObjectWithTag("rbd").GetComponent<dontdestroy>();
    }

    public void bosses()
    {
        close();
        boss.SetActive(true);
    }

    public void spirit()
    {
        close();
        sp.SetActive(true);
    }

    public void tutor()
    {
        close();
        tut.SetActive(true);
    }
    void close()
    {
        boss.SetActive(false);
        sp.SetActive(false);
        tut.SetActive(false);
    }
    public void connecx(int a)
    {
        if (a == -1) 
        {
            int i = main.scene;
            if (i == 0)
            { SceneManager.LoadScene(1); }
            else 
            {
                SceneManager.LoadScene(i);
            }
            
        }
        else
        {
            SceneManager.LoadScene(a);
        }
    }

}
