using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public static List<EnemyScript> allEnemies = new List<EnemyScript>();

    [HideInInspector] public Renderer rend;
    private Color originalColor;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        if(rend != null)
        {
            originalColor = rend.material.color;
        }
    }

    void OnEnable()
    {
        allEnemies.Add(this);
    }

    void OnDisable()
    {
        allEnemies.Remove(this);
    }

    public void ResetColor()
    {
        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }

    public void SetLockOnColor()
    {
        if (rend != null)
        {
            rend.material.color = Color.red;
        }
    }
}
