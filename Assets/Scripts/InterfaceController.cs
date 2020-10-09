using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Text scoreText, moneyText;
    public static int moneyCount, scoreCount;
    public static int towerValue01 = 25, towerValue02 = 50, towerValue03 = 75, towerValue04 = 100;

    void Start()
    {
        scoreCount = 0;
        moneyCount = 100;
    }

    void Update()
    {
        scoreText.text = scoreCount.ToString();
        moneyText.text = moneyCount.ToString();
    }
}
