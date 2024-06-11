using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitPoints = 100f;
    public HealthBar healthBar;
    void Start()
    {
        HitPoints=MaxHitPoints;
        healthBar.SetPlayerHealth(HitPoints,MaxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetPlayerHealth(HitPoints, MaxHitPoints);
    }
    public void TakeDamage(float damage)
    {
        HitPoints -= damage;
        // Update health bar
        healthBar.SetPlayerHealth(HitPoints, MaxHitPoints);
    }
}
