using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {

    float food = 100;
    float happiness = 100;
    float money = 1000;
    float Score = 0;

    float cd;

    public Slider happyBar;
    public Slider foodBar;
    public Text moneyText;
    public Text scoreText;
    public GameObject panel;

    guy player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("guy").GetComponent<guy>();
	}

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
        UpdateUI();
		if(player.inHouse)
        {
            if (player.house.name == "home")
            {
                IncreaseHappiness(0.1f);
                DecreaseFood(0.1f);
                GainScore();
            }
            else if(player.house.name == "store")
            {
                if(DecreaseMoney(1f))
                IncreaseFood(0.1f);
            }
            else if(player.house.name == "work")
            {
                IncreaseMoney(2f);
                DecreaseFood(0.05f);
                DecreaseHappiness(0.05f);
            }
            else if(player.house.name == "bar")
            {
                if(DecreaseMoney(5f))
                IncreaseHappiness(0.5f);
            }
        }
        else
        {
            DecreaseHappiness(0.05f);
            DecreaseFood(0.02f);
        }
	}

    void IncreaseHappiness(float f)
    {
        if(happiness<100)
        {
            happiness += f;
        }
    }

    void IncreaseMoney(float f)
    {
        money += f;
    }

    void IncreaseFood(float f)
    {
        if (food < 100)
        {
            food += f;
        }
    }

    void DecreaseHappiness(float f)
    {
        happiness -= f;
        if(happiness <0)
        {
            LoseGame();
        }
    }

    void DecreaseFood(float f)
    {
        food -= f;
        if (food < 0)
        {
            LoseGame();
        }
    }

    bool DecreaseMoney(float f)
    {
        if (money -f > 0)
        {
            money -= f;
            return true;
        }
        return false;

    }

    void UpdateUI()
    {
        if (Input.GetKey(KeyCode.Escape))
            LoadMainMenu();
        happyBar.value = happiness / 100;
        foodBar.value = food / 100;
        moneyText.text = money+" V";
        scoreText.text = Score + "";
    }

    void GainScore()
    {
        if(Time.time > cd +1)
        {
            cd = Time.time;
            float temp = Random.Range(1, 10000);
            Score += temp;
        }

    }

    void LoseGame()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

}
