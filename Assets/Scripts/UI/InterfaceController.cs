using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Text scoreText, moneyText;
    public static int moneyCount, scoreCount;

    void Start()
    {
        scoreCount = 0;
        moneyCount = 0;
    }

    void Update()
    {
        scoreText.text = scoreCount.ToString();
        moneyText.text = moneyCount.ToString();
    }
}
