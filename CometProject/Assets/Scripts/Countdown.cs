﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    private TMPro.TextMeshProUGUI countText;
    private int countInt = 3;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Player").GetComponent<Controller>().enabled = false;
        countText = GameObject.Find("CountdownText").GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine("Count");
        Time.timeScale = 1f;
        GameObject.Find("PauseButton").GetComponent<Button>().enabled = false;
    }

    IEnumerator Count()
    {
        while (countInt > -1)
        {
            yield return new WaitForSeconds(1);
            countText.text = ("" + countInt);
            countInt--;
        }
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<Controller>().enabled = true;
        countText.text = "GO!";
        yield return new WaitForSeconds(1);
        GameObject.Find("PauseButton").GetComponent<Button>().enabled = true;
        countText.enabled = false;
    }
}
