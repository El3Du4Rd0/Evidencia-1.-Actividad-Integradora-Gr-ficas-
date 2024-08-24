using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private BulletManager bm;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public int numGuns = 0;
    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        bm = FindObjectOfType<BulletManager>();
        StartCoroutine(shoot());
    }

    private void OnEnable()
    {
       TimeManager.OnHalfHourChanged += UpdateTime;
    }


    void UpdateTime()
    {
        if (numGuns < 6 && flag)
        {
            numGuns += 1;
        }
        else if (numGuns > 0 && !flag)
        {
            numGuns -= 1;
        }
        else
        {
            if (numGuns == 6)
            {
                numGuns -= 1;
            }
            else if (numGuns == 0)
            {
                numGuns += 1;
            }
            flag = !flag;
        }
    }

    IEnumerator shoot()
    {
        while(true)
        {
            if (numGuns == 1)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
            }
            else if (numGuns == 2)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 90, 0));
            }
            else if (numGuns == 3)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 60, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 120, 0));
            }
            else if (numGuns == 4)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 45, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 90, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 135, 0));
            }
            else if (numGuns == 5)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 36, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 72, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 108, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 144, 0));
            }
            else if (numGuns == 6)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 30, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 60, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 90, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 120, 0));
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 150, 0));
            }
            bm.bulletCount += numGuns;

            yield return new WaitForSeconds(fireRate);
        }
    }
}
