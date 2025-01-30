using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSystem : MonoBehaviour
{
    public SpriteRenderer foreground;
    public SpriteRenderer background;

    public PlayerController playerController;

    [SerializeField] float healtbarWidth;

    void Start()
    {
        UpdateHealthBar();       
    }


    public void UpdateHealthBar()
    {
        float healthPercentage = (float)(playerController.healthPoints) / playerController.healthPointsMax;
        foreground.transform.localScale = new Vector3(healthPercentage * healtbarWidth, foreground.transform.localScale.y, foreground.transform.localScale.z);
    }
}
