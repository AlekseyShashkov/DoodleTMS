using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI _scoreText = null;
    [SerializeField] private TextMeshProUGUI _startText = null;
    private int _score = 0;

    public static UIManager Instance = null;

    void Awake() => Instance = this;

    void Start()
    {
        SetScore(0);
    }

    public void SetScore(int score)
    {
        _scoreText.text = $"Score: {_score += score}";
    }

    public void StartText(bool isStarted)
    {
        _startText.gameObject.SetActive(isStarted);
    }
}
