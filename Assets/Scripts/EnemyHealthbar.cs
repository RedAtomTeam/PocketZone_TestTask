using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthbar : MonoBehaviour
{
    public SpriteRenderer foreground;
    public SpriteRenderer background;

    public Enemy enemy;

    [SerializeField] float healtbarWidth;

    void Start()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float healthPercentage = (float)(enemy.healthPoints) / enemy.healthPointsMax;
        foreground.transform.localScale = new Vector3(healthPercentage * healtbarWidth, foreground.transform.localScale.y, foreground.transform.localScale.z);
    }
}
