using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletManager : MonoBehaviour
{
    public TextMeshProUGUI bulletText;
    public int bulletCount = 0;
    public Vector3 rotation = new Vector3(0, 0, 0);
    public Vector3 rotationMod = new Vector3(0, 0, 0);
    private bool leftToRight = true;
    public GameObject bulletPrefab;

    private void OnEnable()
    {
       TimeManager.OnHalfHourChanged += UpdateTime;
    }

    private void OnDisable()
    {
        TimeManager.OnHalfHourChanged -= UpdateTime;
    }

    private void DestroyAllBullets()
    {
        // Encuentra todos los objetos del tipo Bullet en la escena
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        // Destruye cada bala
        foreach (Bullet bullet in bullets)
        {
            Destroy(bullet.gameObject);
        }
    }

    private void UpdateTime()
    {
        leftToRight = !leftToRight;
        DestroyAllBullets();
    }

    void Update()
    {
        if (leftToRight == true && rotation != new Vector3(0, 35, 0))
        {
            rotation = new Vector3(-rotation.x, -rotation.y, -rotation.z);
        }

        if (leftToRight == false && rotation != new Vector3(0, -35, 0))
        {
            rotation = new Vector3(-rotation.x, -rotation.y, -rotation.z);
        }

        bulletText.text = "Bullets: " + bulletCount;
    }
}