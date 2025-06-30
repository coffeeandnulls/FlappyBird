using UnityEngine;
using UnityEngine.UI;

public class gameManagerScript : MonoBehaviour
{
    private int score;
    public Text _scoreText;
    public Text _gameOverText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore()
    {
        score++;
        _scoreText.text="Score: "+score.ToString();
    }

 
}
