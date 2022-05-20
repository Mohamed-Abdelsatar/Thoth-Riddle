using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 30;

    private bool isDead = false;

    public DeathMenu deathMenu;

    public Text scoreText;


    // Update is called once per frame
    void Update()
    {

        if (isDead)
            return;

        if (score >= scoreToNextLevel)
            LevelUp ();

        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score + "m").ToString();
    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerModel>().SetSpeed(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);
        scoreText.gameObject.SetActive(false);
    }

}
