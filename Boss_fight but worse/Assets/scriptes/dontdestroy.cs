using UnityEngine;
using UnityEngine.SceneManagement;

public class dontdestroy : MonoBehaviour
{
    public int attack = 15;
    public int maxHP = 100;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void AddAttack(int value)
    {
        attack += value;
    }

    public void AddHP(int value)
    {
       maxHP += value;
    }
    }

