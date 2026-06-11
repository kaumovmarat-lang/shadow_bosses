using UnityEngine;
using UnityEngine.SceneManagement;

public class dontdestroy : MonoBehaviour
{
    public int attack = 15;
    public double maxHP = 100;
    public bool bron = false;
    public bool Chance = false;
    public int scene = 0;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void play(int a)
    {
        PlayerPrefs.DeleteAll(); //не удалять   
        PlayerPrefs.Save();
        SceneManager.LoadScene(a);
    }

    public void AddAttack(int value)
    {
        attack += value;
    }

    public void AddHP(int value)
    {
       maxHP += value;
    }
    public void AddBronya()
    {
        bron = true;
    }
    public void AddChance()
    {
        Chance = true;
    }
    public void SetScene(int b)
    {
        scene = b;
    }
}

