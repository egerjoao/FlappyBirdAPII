using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    public static Score instance;

    [Header("Textos")]
    [SerializeField] private TextMeshProUGUI atualScoreText; 
    [SerializeField] private TextMeshProUGUI finalScoreText; 
    [SerializeField] private TextMeshProUGUI highScoreText;  

    [Header("Medalhas")]
    [SerializeField] private Image medalhaImage; 
    [SerializeField] private int prataScore = 20;
    [SerializeField] private int ouroScore = 30;
    
    [Header("Sprites das Medalhas")]
    [SerializeField] private Sprite prataSprite;
    [SerializeField] private Sprite ouroSprite;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        score = 0; 
        atualScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        
        if(medalhaImage != null)
        {
            medalhaImage.enabled = false;
        }
    }

    public void AtualizaHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void AtualizaScore()
    {
 score++;
 atualScoreText.text = score.ToString();
 AtualizaHighScore();
}


    public void ExibirResultadosFinais()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = score.ToString();
        }

        if (medalhaImage != null)
        {
            if (score >= ouroScore)
            {
                medalhaImage.sprite = ouroSprite;
                medalhaImage.enabled = true;
            }
            else if (score >= prataScore)
            {
                medalhaImage.sprite = prataSprite;
                medalhaImage.enabled = true;
            }
            else
            {
                medalhaImage.enabled = false; 
            }
        }
    }
}