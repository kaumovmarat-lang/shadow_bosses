using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class dialog : MonoBehaviour
{
    public GameObject Dialog;
    public int i = 0;
    public GameObject text1PH;
    public Text text1;
    public GameObject text2PH;
    public Text text2;
    public GameObject text3PH;
    public Text text3;
    public GameObject subaru;
    public GameObject goku;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int deathboss = PlayerPrefs.GetInt("deathboss", 0);
        switch (deathboss) {
            case 0:
                text1.text = "Ты посмел прийти ко мне, \r\nубить моих людей и главное\r\nДЕЛАЕШЬ ЭТО БЕЗ УВАЖЕНИЯ!";
                text2.text = "Ты заплатишь за все, что ты \r\nсделал с моей деревней\r\nи семьей! ТЕБЕ НЕ ЖИТЬ!";
                text3.text = "Ты ничтожество по сравнению\r\nс моей мощью! Покажи же\r\nна что ты способен!";
                break;
            case 1:
                text1.text = "Что с лицом? Выглядишь так,\r\nбудто только что помер!\r\nЯ ведь прав?";
                text2.text = "Что ты сказал? \r\nНе может быть...\r\n\r\n";
                text3.text = "Не думай, что в этот раз\r\nты легко обойдешься!";
                break;
            case 2:
                text1.text = "Похоже кто-то дважды помер\r\nи продолжает возвращаться.";
                text2.text = "Неважно сколько попыток\r\nзаймет эта битва, \r\nты проиграешь!\r\n\r\n";
                text3.text = "Какие пламенные речи\r\nи ради чего все это?\r\nради еще одной смерти!";
                break;
            case 3:
                text1.text = "Снова ты? \r\nМне начинает это надоедать";
                text2.text = "В этот раз ты проиграешь!\r\nЯ отомщу за свою семью!";
                text3.text = "Я могу побеждать тебя вечно!";
                break;
            default:
                text1.text = "Ты готов?";
                text2.text = "Слова больше не имеют значения!\r\nВ этот раз тебе конец!";
                text3.text = "Валяй!";
                break;
        }
    }

    // Update is called once per frame
    public void message()
    {
        switch (i) {
            case 0:
                goku.SetActive(false);
                text1PH.SetActive(false);
                subaru.SetActive(true);
                text2PH.SetActive(true);
                i++;
                break; 
            
        case 1:
            goku.SetActive(true);
            text2PH.SetActive(false);
            subaru.SetActive(false);
            text3PH.SetActive(true);
            i++;
            break;  
        
        case 2:
            goku.SetActive(false);
            text3PH.SetActive(false);
            Dialog.SetActive(false);
            break;
        default:
            break;
        }
        
    }
    
}
