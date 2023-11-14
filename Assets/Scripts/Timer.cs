using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float WaitSec;
    private int WaitSecInt;
    public Text text;
    public int Respawn;


    private void FixedUpdate()
    {
        if(WaitSec > 0)
        {
            WaitSec -= Time.fixedDeltaTime;
            WaitSecInt = (int)WaitSec;
            text.text = WaitSecInt.ToString();
        }
        else
        {
            CoinCounter.currentCoins = 0;
            CoinCounter.Instance.coinText.text = "scrubs : " + CoinCounter.currentCoins.ToString();
            SceneManager.LoadScene(Respawn);
        }
    }
}
