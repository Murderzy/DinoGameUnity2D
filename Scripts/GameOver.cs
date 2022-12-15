using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverMenu;
    [SerializeField]
    private TMPro.TextMeshProUGUI MessageUGUI;

    private GameStat gameStat;

    // Start is called before the first frame update
    void Start()
    {
        gameStat = GameObject.Find("GameStat").GetComponent<GameStat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEndOfGame(bool mood,string message="")
    {
        if (mood)
        {
            GameOverMenu.SetActive(false);   //  скрываем контейнер меню
            Time.timeScale = 1;
            GameObject[] cactus ;
            cactus = GameObject.FindGameObjectsWithTag("Cactus");

            //spawn.SetActive(false);
            foreach (var c in cactus)
            {
                Destroy(c);
            }
            //MessageUGUI.text = "Score: " + gameStat.GameScore + "\n HighScore: "+ PlayerPrefs.GetInt("HighScore").ToString();
            //gameStat.UpdateUIHighScore();
            gameStat.GameScore = 0;
        }
        else
        {
            GameOverMenu.SetActive(true);  //  отображаем контейнер меню
            gameStat.UpdateUIHighScore();
            MessageUGUI.text = "Score: " + gameStat.GameScore + "\n HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
            
            Time.timeScale = 0;  //  останавливаем физическое время
        }

        
    }

    public void AgainClick()
    {
        ShowEndOfGame(true,"score");
    }
}
