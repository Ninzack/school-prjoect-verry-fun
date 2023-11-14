using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{

    public CoinCounter coincount;

    public int index;
    public string levelName;
    public int coinsNeededToGoToNxtLvl = 50;

    void Start()
    {
        coincount = FindObjectOfType<CoinCounter>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && CoinCounter.currentCoins >= coinsNeededToGoToNxtLvl)
        {
            //load level with the build index


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            CoinCounter.currentCoins = 0;
            coincount.UpdateCoinsText();
        }


    }
}
