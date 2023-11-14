using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Coins, VictoryCondition;
    [SerializeField] GameObject victoryCondition;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    private static UIManager instance;

    public static UIManager MyInstance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }
    }

    public void UpdateCoinUI(int _coins, int _victoryCondition)
    {
        Coins.text = "Coins : " + _coins + " / " + _victoryCondition;
    }
} 
