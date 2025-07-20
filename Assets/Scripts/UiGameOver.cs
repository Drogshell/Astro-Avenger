using TMPro;
using UnityEngine;

public class UiGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper _scoreKeeper;
    
    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    private void Start()
    {
        scoreText.text = $"You scored:\n{_scoreKeeper.GetScore()}";
    }
}
