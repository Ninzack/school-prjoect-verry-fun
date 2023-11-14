using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KillPlayer : MonoBehaviour
{
    public int Respawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCounter.currentCoins = 0;
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                CoinCounter.Instance.coinText.text = "scrabs : " + CoinCounter.currentCoins.ToString();
            }
            SceneManager.LoadScene(Respawn);
            damage.Health = 3;


        }
    }
}
