using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance;

    public TMP_Text coinText;
    public static int currentCoins = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "scrabs : " + currentCoins.ToString();
    }

    public void IncreaseCoins(int V)
    {
        currentCoins += V;
        coinText.text = "scrabs : " + currentCoins.ToString();
    }

    public  void UpdateCoinsText()
    {
        coinText.text = "scrabs : " + currentCoins.ToString();
    }
}
