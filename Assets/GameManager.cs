using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timer;

    Transform player;

    [HideInInspector]
    public int gemsCollected;

    int totalGems;


    public TextMeshProUGUI scoreText, timeText, winText;

    public static GameManager GM;



    // Start is called before the first frame update
    void Start()
    {
        if (GM == null)
            GM = this;

        winText.enabled = false;
        timer = 0f;
        gemsCollected = 0;
        totalGems = FindObjectsOfType<Collectible>().Length; //# of objects w/ collectible script

        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Gems Collected: " + gemsCollected.ToString() + "/" + totalGems.ToString();


        timer += Time.deltaTime; //add time ellapsed last frame

        int minutes = (int)timer / 60;
        float seconds = timer - minutes * 60f;
        timeText.text = "Time " + minutes.ToString("D2") +  ":" + seconds.ToString("0#.#0"); 

        if(gemsCollected >= totalGems)
        {
            winText.enabled = true;

        }

        if (player.position.y < -5f)
            Restart();

    }


    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
