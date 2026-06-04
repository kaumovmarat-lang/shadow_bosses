using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialCore : MonoBehaviour
{
    public int scene = 12;
    public int count = 0;
    public Text text;
    public GameObject Light;
    public GameObject Heavy;
    public GameObject Defense;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MessageTutorial()       
    {
        switch (count) {
            case 0:
                count++;
                text.text = "Существуют три вида атаки:\nБыстрая Атака\nТяжелая Атака\nКонтратака";
                ShowMoves(true);
                break;
            case 1:
                count++;
                text.text = "Быстрая атака разрубает Тяжелую.\nМолниеносный удар прерывает ожидания врага.";
                ShowMoves(false);
                Light.SetActive(true);
                break;
            case 2:
                count++;
                text.text = "Тяжелая атака сокрушает Контратаку.\nУдар всей силы ломает любую защиту.";
                ShowMoves(false);
                Heavy.SetActive(true);
                break;
            case 3:
                count++;
                text.text = "Контратака перехватывает Быструю.\nТерпение ловит глупую спешку.";
                ShowMoves(false);
                Defense.SetActive(true);
                break;
            case 4:
                count++;
                text.text = "А теперь перейдем к твоей основной способности\r\nБлагодаря проклятью ведьмы, после смерти\r\nты вернешься к началу битвы\r\n";
                ShowMoves(false);
                break;
            case 5:
                count++;
                text.text = "В твоем бою не будет случайностей.\r\nНе думай, запоминай действия и читай противника.";
                ShowMoves(false);
                break;
            case 6:
                count++;
                text.text = "Теперь покажи чего ты стоишь!";
                ShowMoves(false);         
                break;
            case 7:
                SceneManager.LoadScene(scene);
                break;
        }
    }
    void ShowMoves(bool v)
    {
        if (v) 
        {
            Light.SetActive(true);
            Heavy.SetActive(true);
            Defense.SetActive(true);
        }
        else
        {
            Light.SetActive(false);
            Heavy.SetActive(false);
            Defense.SetActive(false);
        }
    }
}
