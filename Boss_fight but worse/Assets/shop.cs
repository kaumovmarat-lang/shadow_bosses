using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public Text text;
    public int vibor = 1;
    
    
    public void Upgrade1()
    {
        vibor = 1;
        text.text = "+5 к Атаке, теперь ты будешь сражаться немного лучше, чем раньше.";
    }
    public void Upgrade2()
    {
        vibor = 2;
        text.text = "+20 к твоему макс. здоровью, Врагам будет немного сложнее тебя убить.";
    }
    public void Upgrade3()
    {
        vibor = 3;
        text.text = "Доспехи. Ты будешь получать на -10% урона меньше  от врага.";
    }
   public void Upgrade4()
    {
        vibor = 4;
        text.text = "Возрождение. В случае поражения, ты верншься к тому моменту боя, где умер.";
    }
    public void Buy()
    {
        if (vibor == 0)
        {
            text.text = "Ты ничего еще не выбрал!";
        }
        else if (vibor == 1)
        {
            GameObject.FindGameObjectWithTag("rbd").GetComponent<dontdestroy>().AddAttack(5);
        }
        else if (vibor == 2)
        {
            GameObject.FindGameObjectWithTag("rbd").GetComponent<dontdestroy>().AddHP(20);
        }
        else if (vibor == 3)
        {
            GameObject.FindGameObjectWithTag("rbd").GetComponent<dontdestroy>().AddBronya();
        }
        else if (vibor == 4)
        {
            //GameObject.FindGameObjectWithTag("rbd").GetComponent<dontdestroy>().AddHP(50);
        }
        text.text = "Спасибо за покупку!\nПриходи еще!";
        StartCoroutine(waiter(3));
    }
    IEnumerator waiter(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
