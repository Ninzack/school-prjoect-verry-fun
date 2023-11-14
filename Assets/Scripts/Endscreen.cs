using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Endscreen : MonoBehaviour
{

    private TextMeshProUGUI text;
    [SerializeField] private Canvas canvas;

    public CoinCounter coincountobj;
    
    // Start is called before the first frame update
    void Start()
    {
        coincountobj = FindObjectOfType<CoinCounter>();
        if (coincountobj == null)
        {
            Destroy(coincountobj.gameObject);
        }
        Destroy(coincountobj.gameObject);
        text = canvas.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Destroy(text);
    }
}
