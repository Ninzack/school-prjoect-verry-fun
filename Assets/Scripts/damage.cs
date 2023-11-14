using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class damage : MonoBehaviour
{

    [SerializeField] public Image heart1;
    [SerializeField] public Image heart2;
    [SerializeField] public Image heart3;
    public static int Health = 3;

    public PlayerMovement PlayerMovement;

    public float flashDuration = 1.0f;
    public Material matSimpleFlash;
    private SpriteRenderer spRend;
    private Material spRendStartMat;
    private Coroutine startFlashCoroutine;
    
    private SpriteRenderer rend;
    public float DamageTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        heart1.enabled = true;

        spRend = this.GetComponent<SpriteRenderer>();
        spRendStartMat = spRend.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 2)
        {
            heart1.enabled = false;
        }

        if (Health <= 1)
        {
            heart2.enabled = false;
        }

        if (Health <= 0)
        {
            heart3.enabled = false;
        }

        if (Health <= 0)
        {
            die();
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            PlayerMovement.KBCounter = PlayerMovement.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x) 
            {
                PlayerMovement.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                PlayerMovement.KnockFromRight = false;
            }

            Health--;
            Debug.Log("you have " + Health + " lives left!");

            if(startFlashCoroutine != null)
            {
                StopCoroutine(startFlashCoroutine);
                startFlashCoroutine = null;
            }
            startFlashCoroutine = StartCoroutine(SimpleFlashCoroutine());
        }
    }

    IEnumerator SimpleFlashCoroutine()
    {
        spRend.material = matSimpleFlash;

        yield return new WaitForSeconds(flashDuration);

        spRend.material = spRendStartMat;
        startFlashCoroutine = null;
    }

    private void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Health = 3;
        CoinCounter.currentCoins = 0;
        CoinCounter.Instance.coinText.text = "scrabs : " + CoinCounter.currentCoins.ToString();
    }

}
