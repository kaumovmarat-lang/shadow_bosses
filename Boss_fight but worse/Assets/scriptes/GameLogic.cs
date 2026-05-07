using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
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
    int[] monster_hp = { 200, 250, 300, 350, 400}; // хп врагов всех поочередно
    public int monster = 0; // какой монстр счетчик
    
    public int[] player = {0, 0, 0, 0, 0 }; //действия игрока
    int[] first = { 2, 1, 3, 3, 2, 1, 2, 3, 1, 1, 3, 2, 2, 1, 3, 3, 2, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 1, 2, 3, 1, 3, 3, 2, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 1, 2, 3 }; //ходы монстров ↓
    int[] second = { 3, 1, 2, 3, 2, 1, 1, 3, 2, 2, 1, 3, 3, 2, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 1, 3, 2, 2, 1, 3, 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 2, 1 };
    int[] third = { 1, 2, 3, 2, 1, 3, 3, 2, 1, 1, 3, 2, 2, 1, 3, 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 2, 1, 2, 1, 3, 1, 3 };
    int[] fourth = { 2, 3, 1, 1, 2, 3, 2, 1, 3, 3, 1, 2, 2, 3, 1, 1, 3, 2, 3, 1, 2, 2, 1, 3, 1, 2, 3, 3, 2, 1, 1, 3, 3, 2, 1, 1, 2, 3, 3, 1, 2, 2, 3, 1, 1, 2, 3 };
    int[] fifth = { 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 2, 1, 2, 1, 3, 1, 3, 2, 2, 3, 1, 3, 1, 2, 2, 1, 3, 1, 2, 3, 3, 2, 1, 2, 3, 1, 1, 2, 3, 3, 2, 1, 2, 1, 3, 1, 2 };  //ходы монстров
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    // Update is called once per frame
    void Update()
    {
        
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
                    Instantiate(prefab1, pos1.transform.position, Quaternion.identity, trans);
                    break;
                case 1:
                    Instantiate(prefab1, pos2.transform.position, Quaternion.identity, trans);
                    break;
                case 2:
                    Instantiate(prefab1, pos3.transform.position, Quaternion.identity, trans);
                    break;
                case 3:
                    Instantiate(prefab1, pos4.transform.position, Quaternion.identity, trans);
                    break;
                case 4:
                    Instantiate(prefab1, pos5.transform.position, Quaternion.identity, trans);
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
                    Instantiate(prefab2, pos1.transform.position, Quaternion.identity, trans);
                    break;
                case 1:
                    Instantiate(prefab2, pos2.transform.position, Quaternion.identity, trans);
                    break;
                case 2:
                    Instantiate(prefab2, pos3.transform.position, Quaternion.identity, trans);
                    break;
                case 3:
                    Instantiate(prefab2, pos4.transform.position, Quaternion.identity, trans);
                    break;
                case 4:
                    Instantiate(prefab2, pos5.transform.position, Quaternion.identity, trans);
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
                    Instantiate(prefab3, pos1.transform.position, Quaternion.identity, trans);
                    break;
                case 1:
                    Instantiate(prefab3, pos2.transform.position, Quaternion.identity, trans);
                    break;
                case 2:
                    Instantiate(prefab3, pos3.transform.position, Quaternion.identity, trans);
                    break;
                case 3:
                    Instantiate(prefab3, pos4.transform.position, Quaternion.identity, trans);
                    break;
                case 4:
                    Instantiate(prefab3, pos5.transform.position, Quaternion.identity);
                    break;
            }
            vibor = 3;
            select.transform.position = scissors.transform.position;
            player[i] = vibor;
            i++;
        }
    }
    public void StartFight() {
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
            switch (result)
            {
                case 0:
                    if (bronya) {
                        HP -= 9;
                        monster_hp[monster] -= damage;
                        text.text = $"Ничья!\nВы нанесли {damage} урона и получили 9 урона!";
                    }
                    else {
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
                    if (bronya) {
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
                    Console.WriteLine("Ошибка?");
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
                    StartCoroutine(waiter_dead(3));
                }
                else
                {
                    second_chance_sound.Play();
                    HP = 1;
                    chance = false;
                    PlayerStats.Chance = false;

                    int deathTurn = PlayerPrefs.GetInt("deathTurn", -1);
                    Console.WriteLine("Сейчас ход " + hod + ", Подсказка в " + deathTurn);
                    if (hod == (deathTurn - 1))
                    {
                        if (monster == 0)
                        {
                            switch (first[hod])
                            {
                                case 1:
                                    hint.text = $"Враг использует Быструю атаку...";
                                    break;
                                case 2:
                                    hint.text = $"Враг использует Тяжелую атаку...";
                                    break;
                                case 3:
                                    hint.text = $"Враг использует Контратаку...";
                                    break;
                            }
                        }
                        else if (monster == 1)
                        {
                            switch (second[hod])
                            {
                                case 1:
                                    hint.text = $"Враг использует Быструю атаку...";
                                    break;
                                case 2:
                                    hint.text = $"Враг использует Тяжелую атаку...";
                                    break;
                                case 3:
                                    hint.text = $"Враг использует Контратаку...";
                                    break;
                            }

                        }
                        else if (monster == 2)
                        {
                            switch (third[hod])
                            {
                                case 1:
                                    hint.text = $"Враг использует Быструю атаку...";
                                    break;
                                case 2:
                                    hint.text = $"Враг использует Тяжелую атаку...";
                                    break;
                                case 3:
                                    hint.text = $"Враг использует Контратаку...";
                                    break;
                            }
                        }
                        else if (monster == 3)
                        {
                            switch (fourth[hod])
                            {
                                case 1:
                                    hint.text = $"Враг использует Быструю атаку...";
                                    break;
                                case 2:
                                    hint.text = $"Враг использует Тяжелую атаку...";
                                    break;
                                case 3:
                                    hint.text = $"Враг использует Контратаку...";
                                    break;
                            }
                        }
                        else
                        {
                            switch (fifth[hod])
                            {
                                case 1:
                                    hint.text = $"Враг использует Контратаку...";
                                    break;
                                case 2:
                                    hint.text = $"Враг использует Быструю атаку...";
                                    break;
                                case 3:
                                    hint.text = $"Враг использует Тяжелую атаку...";
                                    break;
                            }
                        }

                    }
                    else { hint.text = ""; }
                    for (int b = 0; b < player.Length; b++)
                    {
                        player[b] = 0;
                    }
                    i = 0;
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
                Console.WriteLine("Сейчас ход " + hod + ", Подсказка в " + deathTurn);
                if (hod == (deathTurn - 1))
                {
                    if (monster == 0)
                    {
                        switch (first[hod])
                        {
                            case 1:
                                hint.text = $"Враг использует Быструю атаку...";
                                break;
                            case 2:
                                hint.text = $"Враг использует Тяжелую атаку...";
                                break;
                            case 3:
                                hint.text = $"Враг использует Контратаку...";
                                break;
                        }
                    }
                    else if (monster == 1)
                    {
                        switch (second[hod])
                        {
                            case 1:
                                hint.text = $"Враг использует Быструю атаку...";
                                break;
                            case 2:
                                hint.text = $"Враг использует Тяжелую атаку...";
                                break;
                            case 3:
                                hint.text = $"Враг использует Контратаку...";
                                break;
                        }

                    }
                    else if (monster == 2)
                    {
                        switch (third[hod])
                        {
                            case 1:
                                hint.text = $"Враг использует Быструю атаку...";
                                break;
                            case 2:
                                hint.text = $"Враг использует Тяжелую атаку...";
                                break;
                            case 3:
                                hint.text = $"Враг использует Контратаку...";
                                break;
                        }
                    }
                    else if (monster == 3)
                    {
                        switch (fourth[hod])
                        {
                            case 1:
                                hint.text = $"Враг использует Быструю атаку...";
                                break;
                            case 2:
                                hint.text = $"Враг использует Тяжелую атаку...";
                                break;
                            case 3:
                                hint.text = $"Враг использует Контратаку...";
                                break;
                        }
                    }
                    else
                    {
                        switch (fifth[hod])
                        {
                            case 1:
                                hint.text = $"Враг использует Контратаку...";
                                break;
                            case 2:
                                hint.text = $"Враг использует Быструю атаку...";
                                break;
                            case 3:
                                hint.text = $"Враг использует Тяжелую атаку...";
                                break;
                        }
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
        Return.ReturnByDeath();
    }

    IEnumerator waiter_victory(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(scene+1);
    }
}
