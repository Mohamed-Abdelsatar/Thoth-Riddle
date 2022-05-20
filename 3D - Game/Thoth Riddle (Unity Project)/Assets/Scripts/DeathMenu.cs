using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CollactableControll.CoinCount = 0;
    }


    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score + "m" ).ToString();

    }


    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");       
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
