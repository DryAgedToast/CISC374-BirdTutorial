using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int Score;
    public AudioSource pointSound;
    public Text scoreText;
    public GameObject gameOS;
    public GameObject gameSS;
    public Text highScoreT;
    public AudioSource startMusic;
    public AudioSource bgMusic;
    public AudioSource gameOverMusic;
    private static bool hasStarted = false;
    
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        if(gameOS.activeSelf == false){
            Score = Score + scoreToAdd;
            scoreText.text = Score.ToString();
            pointSound.Play();
        }
    }
    void Start()
    {
        if (hasStarted)
        {
            gameSS.SetActive(false);
            bgMusic.Play();
            Time.timeScale = 1f;
        }
        else
        {
            gameSS.SetActive(true);
            Time.timeScale = 0f;
            startMusic.Play();
        }
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame(){
        hasStarted = true;
        gameSS.SetActive(false);
        Time.timeScale = 1f;
        startMusic.Stop();
        bgMusic.Play();
    }

    public void gameOver(){
        if(Score > PlayerPrefs.GetInt("highScore", 0)){
            PlayerPrefs.SetInt("highScore", Score);
        }
        highScoreT.text = "High Score: " + PlayerPrefs.GetInt("highScore", Score);
        gameOS.SetActive(true);
        bgMusic.Stop();
        gameOverMusic.Play();
    }
}
