using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthRenderer : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.HealthDecreased += OnHealthDecreased;
    }

    private void OnDisable()
    {
        _enemy.HealthDecreased -= OnHealthDecreased;
    }

    private void OnHealthDecreased(int damage)
    {
        _image.fillAmount -=(damage*0.2f);
    }
}
