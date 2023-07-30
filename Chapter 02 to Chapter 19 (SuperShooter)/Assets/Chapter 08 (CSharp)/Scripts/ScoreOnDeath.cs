﻿using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;

    void Awake()
    {
        var life = GetComponent<Life_Chapter8>();
        life.onDeath.AddListener(GivePoints);
    }

    void GivePoints()
    {
        ScoreManager.instance.amount += amount;
    }
}