using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float maxHealth;
    [SerializeField] private float minHealth;
    private float health;
    private void Awake()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.minValue = minHealth;
        health = maxHealth;
        healthSlider.value = health;

    }
    private void Update()
    {
        healthSlider.direction = transform.localScale.x==1? Slider.Direction.LeftToRight: Slider.Direction.RightToLeft;
    }
    public float GetHealth()
    {
        return health;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetMinHealth()
    {
        return minHealth;
    }
    public void TruMau(float nHealth)
    {
        health -= nHealth;
        SetHealthBar(health);
    }
    private void SetHealthBar(float nHealth)
    {
        healthSlider.value = nHealth;
    }
}
