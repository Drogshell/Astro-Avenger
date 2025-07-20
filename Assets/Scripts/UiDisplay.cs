using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiDisplay : MonoBehaviour
{
    [Header("Health")] 
    [SerializeField] private Slider healthBar;
    
    [SerializeField] private Health health;
    
    [Header("Score")] 
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private ScoreKeeper _score;
    
    private void Awake()
    {
        _score = FindObjectOfType<ScoreKeeper>();
    }
    
    private void Start()
    {
        healthBar.maxValue = health.GetCurrentHealth();
    }
    
    private void Update()
    {
        healthBar.value = health.GetCurrentHealth();
        scoreText.text = _score.GetScore().ToString("000000");
    }
}
