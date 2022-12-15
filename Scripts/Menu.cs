using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject UserMenu;
    [SerializeField]
    private TMPro.TextMeshProUGUI ButtonText;
    [SerializeField]
    private TMPro.TextMeshProUGUI MessageUGUI;

    private GameStat gameStat;
    // Start is called before the first frame update
    void Start()
    {
        gameStat = GameObject.Find("GameStat").GetComponent<GameStat>();
        if (UserMenu.activeInHierarchy)
        {

            ShowMenu(false, "Start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu(false, "Resume");
        }
    }

    public void ButtonClick()
    {
        ShowMenu(true);
    }

    public void ShowMenu(bool mood, string buttonText = "Resume", string message = "")
    {
        Debug.Log(PlayerPrefs.GetInt("HighScore"));
        message = "Score: " + gameStat.GameScore + "\n HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
        if (mood)
        {
            UserMenu.SetActive(false);   //  скрываем контейнер меню

            Time.timeScale = 1;

            //ResumeButtonText.text = buttonText;
        }
        else
        {
            UserMenu.SetActive(true);  //  отображаем контейнер меню
            ButtonText.text = buttonText;
            MessageUGUI.text = message;
            Time.timeScale = 0;  //  останавливаем физическое время
        }

        
    }
}
