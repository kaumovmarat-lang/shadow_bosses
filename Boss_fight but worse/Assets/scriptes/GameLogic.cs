using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;
    public Transform trans;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;
    public GameObject prefab1; //быстрая
    public GameObject prefab2; //тяжелая
    public GameObject prefab3; //контр
    public AudioSource second_chance_sound;
    public bool chance = false;
    public bool bronya = false; //броня вкл/выкл
    public Text makarov; //текст достигнут ли максимум действий
    public int i = 0; //счет действий
    public dontdestroy PlayerStats; //статы игрока (атака, хп, есть ли броня)
    public Text hint; //подсказка при предсмертной действии
    public AudioSource music; //музыка
    public GameObject text_background; //фон текста
    public Text hp; // текст хп игрорка
    public Text hp_Vrag; // текст хп врага
    public int scene = 0; // какая сцена
    public GameObject character_alive; // спрайты начало ↓
    public GameObject character_attack;
    public GameObject character_dead;
    public GameObject monster_alive;
    public GameObject monster_attack;
    public AudioSource victory;
    public AudioSource aud_fight;
    public videoscript Return;
    public GameObject rock;
    public GameObject paper;
    public GameObject scissors;
    public GameObject fightButton;
    public GameObject select;
    public Text text;                   //спрайты конец
    public int hod = 0; //какой ход
    public int vibor = 1; //какой выбор. !!!!По умолчанию всегда 1!!!!
    public double HP; // хп игрока
    public int damage; //атака игрока
    public double evildamage = 30; //атака врага (меняется в инспекторе)
    int[] monster_hp = { 200, 250, 300, 350, 400 }; // хп врагов всех поочередно
    public int monster = 0; // какой монстр счетчик

    public int[] player = { 0, 0, 0, 0, 0 }; //действия игрока
    int[] first = { 2, 1, 3, 3, 2, 1, 2, 3, 1, 1, 3, 2, 2, 1, 3, 3, 2, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 1, 2, 3, 1, 3, 3, 2, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 1, 2, 3 }; //ходы монстров ↓
    int[] second = { 3, 1, 2, 3, 2, 1, 1, 3, 2, 2, 1, 3, 3, 2, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 1, 3, 2, 2, 1, 3, 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 2, 1 };
    int[] third = { 1, 2, 3, 2, 1, 3, 3, 2, 1, 1, 3, 2, 2, 1, 3, 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 2, 1, 2, 1, 3, 1, 3 };
    int[] fourth = { 2, 3, 1, 1, 2, 3, 2, 1, 3, 3, 1, 2, 2, 3, 1, 1, 3, 2, 3, 1, 2, 2, 1, 3, 1, 2, 3, 3, 2, 1, 1, 3, 3, 2, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 1, 2, 3 };
    int[] fifth = { 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 2, 1, 2, 1, 3, 1, 3, 2, 2, 3, 1, 3, 1, 2, 2, 1, 3, 1, 2, 3, 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 2, 1, 2, 1, 3, 1, 2 };  //ходы монстров

    void Start()
    {
        PlayerStats = GameObject.FindGameObjectWithTag("rbd").GetComponent<dontdestroy>();
        HP = PlayerStats.maxHP;
        damage = PlayerStats.attack;
        bronya = PlayerStats.bron;
        hp.text = HP.ToString();
        hp_Vrag.text = monster_hp[monster].ToString();
        chance = PlayerStats.Chance;
    }

    
    private string GetHintForAction(int action)
    {
        switch (action)
        {
            case 1: return "Враг использует Быструю атаку...";
            case 2: return "Враг использует Тяжелую атаку...";
            case 3: return "Враг использует Контратаку...";
            default: return "";
        }
    }

    public void chooserock()
    {
        if (i >= player.Length)
        {
            makarov.text = "Максимум действий достигнут.";
        }
        else
        {
            switch (i)
            {
                case 0:

                    s1 = Instantiate(prefab1, pos1.transform.position, Quaternion.identity, trans);
                    break;
                case 1:
                    s2 = Instantiate(prefab1, pos2.transform.position, Quaternion.identity, trans);
                    break;
                case 2:
                    s3 = Instantiate(prefab1, pos3.transform.position, Quaternion.identity, trans);
                    break;
                case 3:
                    s4 = Instantiate(prefab1, pos4.transform.position, Quaternion.identity, trans);
                    break;
                case 4:
                    s5 = Instantiate(prefab1, pos5.transform.position, Quaternion.identity, trans);
                    break;
            }
            vibor = 1;
            select.transform.position = rock.transform.position;
            player[i] = vibor;
            i++;
        }
    }
    public void choosepaper()
    {
        if (i >= player.Length)
        {
            makarov.text = "Максимум действий достигнут.";
        }
        else
        {
            switch (i)
            {
                case 0:
                    s1 = Instantiate(prefab2, pos1.transform.position, Quaternion.identity, trans);
                    break;
                case 1:
                    s2 = Instantiate(prefab2, pos2.transform.position, Quaternion.identity, trans);
                    break;
                case 2:
                    s3 = Instantiate(prefab2, pos3.transform.position, Quaternion.identity, trans);
                    break;
                case 3:
                    s4 = Instantiate(prefab2, pos4.transform.position, Quaternion.identity, trans);
                    break;
                case 4:
                    s5 = Instantiate(prefab2, pos5.transform.position, Quaternion.identity, trans);
                    break;
            }
            vibor = 2;
            select.transform.position = paper.transform.position;
            player[i] = vibor;
            i++;
        }
    }
    public void choosescissors()
    {
        if (i >= player.Length)
        {
            makarov.text = "Максимум действий достигнут.";
        }
        else
        {
            switch (i)
            {
                case 0:
                    s1 = Instantiate(prefab3, pos1.transform.position, Quaternion.identity, trans);
                    break;
                case 1:
                    s2 = Instantiate(prefab3, pos2.transform.position, Quaternion.identity, trans);
                    break;
                case 2:
                    s3 = Instantiate(prefab3, pos3.transform.position, Quaternion.identity, trans);
                    break;
                case 3:
                    s4 = Instantiate(prefab3, pos4.transform.position, Quaternion.identity, trans);
                    break;
                case 4:
                    s5 = Instantiate(prefab3, pos5.transform.position, Quaternion.identity, trans);
                    break;
            }
            vibor = 3;
            select.transform.position = scissors.transform.position;
            player[i] = vibor;
            i++;
        }
    }
    public void StartFight()
    {
        if (i >= 5)
        {
            StartCoroutine(fight());
        }
        else { makarov.text = "Действий должно быть всего 5"; }
    }
    public IEnumerator fight()
    {


        makarov.text = "";
        text.text = "";
        aud_fight.Play();
        text_background.SetActive(false);
        character_alive.SetActive(false);
        character_attack.SetActive(true);
        monster_alive.SetActive(false);
        monster_attack.SetActive(true);
        rock.SetActive(false);
        paper.SetActive(false);
        scissors.SetActive(false);
        select.SetActive(false);
        fightButton.SetActive(false);
        int result = 0;
        for (int a = 0; a < player.Length; a++)
        {

            if (monster == 0)
            {
                result = game(player[a], first[hod]);
            }
            else if (monster == 1)
            {
                result = game(player[a], second[hod]);

            }
            else if (monster == 2)
            {
                result = game(player[a], third[hod]);
            }
            else if (monster == 3)
            {
                result = game(player[a], fourth[hod]);
            }
            else { result = game(player[a], fifth[hod]); }
            hod++;
            yield return new WaitForSeconds(3);
            switch (a)
            {
                case 0:
                    Destroy(s1);
                    s1 = null;
                    break;
                case 1:
                    Destroy(s2);
                    s2 = null;
                    break;
                case 2:
                    Destroy(s3);
                    s3 = null;
                    break;
                case 3:
                    Destroy(s4);
                    s4 = null;
                    break;
                case 4:
                    Destroy(s5);
                    s5 = null;
                    break;
            }
            switch (result)
            {
                case 0:
                    if (bronya)
                    {
                        HP -= 9;
                        monster_hp[monster] -= damage;
                        text.text = $"Ничья!\nВы нанесли {damage} урона и получили 9 урона!";
                    }
                    else
                    {
                        HP -= 10;
                        monster_hp[monster] -= damage;
                        text.text = $"Ничья!\nВы нанесли {damage} урона и получили 10 урона!";
                    }

                    break;
                case 1:
                    monster_hp[monster] -= damage * 2;
                    text.text = $"Чудесная Атака!\nВы нанесли {damage * 2} урона!";
                    break;
                case 2:
                    if (bronya)
                    {
                        HP -= evildamage * 0.9;
                        text.text = $"Плохая Атака...\nВы получили {evildamage * 0.9} урона!";
                    }
                    else
                    {
                        HP -= evildamage;
                        text.text = $"Плохая Атака...\nВы получили {evildamage} урона!";
                    }
                    break;
                case 4:
                    Debug.Log("Ошибка?");
                    break;
            }
            aud_fight.Stop();
            hp.text = HP.ToString();
            hp_Vrag.text = monster_hp[monster].ToString();
            text_background.SetActive(true);
            if (monster_hp[monster] <= 0)
            {
                music.volume = 0.1f;
                monster_attack.SetActive(false);
                monster_alive.SetActive(false);
                victory.Play();
                text.text = "ПОБЕДА!";
                hod = 0;
                StartCoroutine(waiter_victory(3));

            }
            else if (HP <= 0)
            {
                if (!chance)
                {
                    PlayerPrefs.SetInt("deathTurn", hod);
                    PlayerPrefs.Save();
                    
                    character_attack.SetActive(false);
                    character_alive.SetActive(false);
                    character_dead.SetActive(true);
                    text.text = "Вы проиграли..!";
                    music.volume = 0.1f;
                    hod = 0;
                    StartCoroutine(waiter_dead(3));
                }
                else
                {
                    second_chance_sound.Play();
                    HP = 1;
                    chance = false;
                    PlayerStats.Chance = false;
                    Destroy(s1);
                    Destroy(s2);
                    Destroy(s3);
                    Destroy(s4);
                    Destroy(s5);
                    s1 = null; s2 = null; s3 = null; s4 = null; s5 = null; 
                    hp.text = HP.ToString();
                    int deathTurn = PlayerPrefs.GetInt("deathTurn", -1);
                    Debug.Log("Сейчас ход " + hod + ", Подсказка в " + deathTurn);
                    if (hod == (deathTurn - 1))
                    {
                        if (monster == 0)
                        {
                            hint.text = GetHintForAction(first[hod]); 
                        }
                        else if (monster == 1)
                        {
                            hint.text = GetHintForAction(second[hod]); 
                        }
                        else if (monster == 2)
                        {
                            hint.text = GetHintForAction(third[hod]); 
                        }
                        else if (monster == 3)
                        {
                            hint.text = GetHintForAction(fourth[hod]); 
                        }
                        else
                        {
                            hint.text = GetHintForAction(fifth[hod]); 
                        }
                    }
                    else { hint.text = ""; }
                    for (int b = 0; b < player.Length; b++)
                    {
                        player[b] = 0;
                        yield return new WaitForSeconds(1);
                    }
                    i = 0;
                    hod = 0;
                    yield return new WaitForSeconds(2f);
                    monster_alive.SetActive(true);
                    monster_attack.SetActive(false);
                    character_alive.SetActive(true);
                    character_attack.SetActive(false);
                    character_dead.SetActive(false);
                    rock.SetActive(true);
                    paper.SetActive(true);
                    scissors.SetActive(true);
                    select.SetActive(true);
                    fightButton.SetActive(true);
                    text_background.SetActive(false);
                    text.text = "";
                    yield break;
                }

            }
            else
            {

                int deathTurn = PlayerPrefs.GetInt("deathTurn", -1);
                Debug.Log("Сейчас ход " + hod + ", Подсказка в " + deathTurn);
                if (hod == (deathTurn - 1))
                {
                    if (monster == 0)
                    {
                        hint.text = GetHintForAction(first[hod]);
                    }
                    else if (monster == 1)
                    {
                        hint.text = GetHintForAction(second[hod]); 
                    }
                    else if (monster == 2)
                    {
                        hint.text = GetHintForAction(third[hod]); 
                    }
                    else if (monster == 3)
                    {
                        hint.text = GetHintForAction(fourth[hod]); 
                    }
                    else
                    {
                        hint.text = GetHintForAction(fifth[hod]); 
                    }
                }
                else { hint.text = ""; }
            }
        }
        for (int a = 0; a < player.Length; a++)
        {
            player[a] = 0;
        }
        i = 0;
        hod = 0;
        yield return new WaitForSeconds(2f);
        monster_alive.SetActive(true);
        monster_attack.SetActive(false);
        character_alive.SetActive(true);
        character_attack.SetActive(false);
        rock.SetActive(true);
        paper.SetActive(true);
        scissors.SetActive(true);
        select.SetActive(true);
        fightButton.SetActive(true);
        text_background.SetActive(false);
        text.text = "";
    }
    public int game(int x, int y)
    {
        if (x == y) { return 0; } //ничья
        else if ((x == 1 && y == 2) || (x == 2 && y == 3) || (x == 3 && y == 1)) { return 1; } //поражение
        else if ((y == 1 && x == 2) || (y == 2 && x == 3) || (y == 3 && x == 1)) { return 2; } //победа
        else { return 4; }
    }
    IEnumerator waiter_dead(float sec)
    {
        yield return new WaitForSeconds(sec);
        music.volume = 0;
        if (scene == 7)
        {
            int bo = PlayerPrefs.GetInt("deathboss", 0);
            PlayerPrefs.SetInt("deathboss", bo + 1);
            PlayerPrefs.Save();
        }
        Return.ReturnByDeath();
    }

    IEnumerator waiter_victory(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(scene + 1);
    }
}