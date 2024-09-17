using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]

    public int score = 0;

    private TextMeshProUGUI uiText;

    // Start is called before the first frame update
    void Start()
    {
        //uiText = GetComponent<Text>();
        uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //this 0 is a zero!
        uiText.text = score.ToString("#,0");
    }
}
