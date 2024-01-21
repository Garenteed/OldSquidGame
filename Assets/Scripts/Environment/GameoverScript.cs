using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverScript : MonoBehaviour
{

    public event EventHandler GameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver?.Invoke(this, EventArgs.Empty);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver?.Invoke(this, EventArgs.Empty);

    }
}
 
