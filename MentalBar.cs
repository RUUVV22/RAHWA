using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentalBar : MonoBehaviour
{
    public Slider metalBarSlider;
    public Color High;
    public Color Low;

    void Start()
    {
        
    }
    public void SetPlayerHealth(float health, float maxHealth)
    {
        metalBarSlider.value = health;
        metalBarSlider.maxValue = maxHealth;
        metalBarSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, metalBarSlider.normalizedValue);//fill the slider
    }
    // Update is called once per frame
    void Update()
    {

    }
}
