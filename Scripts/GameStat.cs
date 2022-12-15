using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI score;

    private int _gameScore;
    private int _highScore ;

    public int GameScore
    {
        get => _gameScore;
        set
        {
            _gameScore = value;
            UpdateUIScore();
        }
    }

    public int HighScore
    {
        get => _highScore;
        set
        {
            _highScore = value;
            UpdateUIHighScore();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameScore = 0;
        _highScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUIScore()
    {
        //GameScore += 1;
        score.text = GameScore.ToString();
    }

    public void UpdateUIHighScore()
    {
        Debug.Log(PlayerPrefs.GetInt("HighScore"));
        if(_gameScore > _highScore)
        {
            _highScore = _gameScore;
            PlayerPrefs.SetInt("HighScore", _highScore );
            PlayerPrefs.Save();
        }
    }
}
