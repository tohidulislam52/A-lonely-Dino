using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scroeText;
    [SerializeField] private TextMeshProUGUI _HighScroeText;
    [SerializeField] private TextMeshProUGUI _MassageText;
    [SerializeField] private GameObject _GameOverPanel;
    private PlayerMovement _playerMovement;
     private string[] _massages = 
    {
        "stupid you are dead!!",
        "You can never finish it Ha Ha",
        "Ha ha you're dead!!",
        "Go and eat Milk is not a child's game",
        "A so noob player like you will not be able to finish this game",
        "You are really stupid fool, like you can't finish this game",
        "A fool like you can't finish this game :(",
        "Ha Ha Ha You Noob :)"
    };

    private int _score,_HighScore;

    void Awake()
    {
       
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _HighScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScore();
        _GameOverPanel.SetActive(false);

    }
    void Start()
    {
        _MassageText.text = _massages[Random.Range(0,_massages.Length)];
    }
    void Update()
    {
        if(!_playerMovement._PlayerMove)
        {
            _GameOverPanel.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (_playerMovement._PlayerMove)
        {
            _score = Mathf.RoundToInt(_playerMovement.transform.position.x/2);
            Score();
            if(_score> _HighScore)
            {
                _HighScore = _score;
                PlayerPrefs.SetInt("HighScore",_HighScore);
                HighScore();
            }
        }
    }



    private void Score()
    {
        if (_score < 100)
            _scroeText.text = "S 000" + _score.ToString();
        else if (1000 > _score)
            _scroeText.text = "S 00" + _score.ToString();
        else if (10000 > _score)
            _scroeText.text = "S 0" + _score.ToString();
        else 
            _scroeText.text = "S " + _score.ToString();
       
    }
    private void HighScore()
    {
        if (_HighScore < 100)
            _HighScroeText.text = "Hi 000" + _HighScore.ToString();
        else if (1000 > _HighScore)
            _HighScroeText.text = "Hi 00" + _HighScore.ToString();
        else if (10000 > _HighScore)
            _HighScroeText.text = "Hi 0" + _HighScore.ToString();
        else
            _HighScroeText.text = "Hi " + _HighScore.ToString();
        
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void home()
    {
        SceneManager.LoadScene(0);
    }
}
