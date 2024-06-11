using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBarSlider;
    public Color High;
    public Color Low;

    void Start()
    {
        //healthBarSlider.value = 100;
        //healthBarSlider.maxValue = 100;
        //healthBarSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, healthBarSlider.normalizedValue);//fill the slider
    }
    public void SetPlayerHealth(float health, float maxHealth)
    {
        //Debug.Log("ok");
        //healthBarSlider.gameObject.SetActive(health < maxHealth);
        healthBarSlider.value = health;
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, healthBarSlider.normalizedValue);//fill the slider
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
