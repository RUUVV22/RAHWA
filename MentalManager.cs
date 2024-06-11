using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MentalManager : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitPoints = 100f;
    public MentalBar mentalBar;
    float timecount = 60f;
    //game over 
    public GameObject gameover;
    void Start()
    {
        HitPoints = MaxHitPoints;
        mentalBar.SetPlayerHealth(HitPoints,MaxHitPoints);
        Time.timeScale = 1;
    }

    void Update()
    {
        timecount -=Time.deltaTime;
        if (timecount <=0f)
        {
            if(HitPoints>0)
            {
                TakeDamage(50);
                Debug.Log("take");
            }
            
            timecount = 60f;
        }
        if (HitPoints == 0)
        {
            gameover.SetActive(true);
            Time.timeScale = 0;
        }
        if (Player2.isHeal&&HitPoints<100)
        {
            TakeDamage2(50);
            Player2.isHeal=false;
            Debug.Log(HitPoints);
        }
        mentalBar.SetPlayerHealth(HitPoints, MaxHitPoints);
    }
    public void TakeDamage(float damage)
    {
        HitPoints -= damage;
    }
    public void TakeDamage2(float damage)
    {
        HitPoints += damage;
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
