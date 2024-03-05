﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject winText;

    
    public static int level = 1;

    float totalTime = 20f;
    float time = 0;

    private void Start()
    {
        time = totalTime;
    }
    private void Update()
    {
        if (Player.Instance.isSpawned)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timeText.text = "TIME : " + time.ToString("F0");
            }
        }
        if (time <= 0)
        {
            StartCoroutine(Win());
        }
    }
    IEnumerator Win()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(2);
        winText.SetActive(false);

        time = totalTime;
        Player.Instance.isSpawned = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
