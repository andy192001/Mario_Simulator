using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerScriptRender smallRender;
    public PlayerScriptRender bigRender;

    private DeathAnimation deathAnimation;

    public bool big => bigRender.enabled;
    public bool small => smallRender.enabled;
    public bool dead => deathAnimation.enabled;

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
    }

    public void Hit()
    {
        if (big)
        {
            Shrink();
        }
        else
        {
            Death();
        }
    }

    private void Death()
    {
        smallRender.enabled = false;
        bigRender.enabled = false;
        deathAnimation.enabled = true;

        GameManager.Instance.ResetLevel(3f);
    }

    private void Shrink()
    {
        
    }
}
