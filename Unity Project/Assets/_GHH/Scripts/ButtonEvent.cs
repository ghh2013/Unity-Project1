﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneMgr.Instance.LoadScene("GameScene");
    }

   public void OnMenuButtonClick()
    {
        SceneMgr.Instance.LoadScene("StartScene");
    }

    public void OnOptionButtonClick()
    {

    }
}
