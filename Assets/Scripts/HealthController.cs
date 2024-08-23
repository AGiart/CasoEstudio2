using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth;

    [SerializeField]
    Slider slider;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;

        slider.maxValue = maxHealth;
        slider.value = _currentHealth;
    }

    private float GetHealth(float value, bool percentage, float factor)
    {
        if (percentage)
        {
            return (maxHealth * Mathf.Abs(value) / 100.0F) * factor;
        }
        else
        {
            return Mathf.Abs(value) * factor;
        }
    }

    private void UpdateSlider()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0.0F, maxHealth);
        slider.value = _currentHealth;

        if (_currentHealth == 0.0F)
        {
            // Die
        }
    }

    public void DecreaseHealth(float value, bool percentage = false)
    {
        _currentHealth += GetHealth(value, percentage, -1);
        UpdateSlider();
    }

    public void IncreaseHealth(float value, bool percentage = false)
    {
        _currentHealth += GetHealth(value, percentage, 1);
        UpdateSlider();
    }
}
