using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, enemiesText;
    public static LevelManager instance;
    [SerializeField] int plaque, score = 0;

    public void AddScore()
    {
        score++;
    }
    public void RemovePlaque()
    {
        plaque--;
        AddScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        plaque = FindObjectsOfType<Enemy>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        enemiesText.text = "Plaque Left: " + plaque;
    }
}
