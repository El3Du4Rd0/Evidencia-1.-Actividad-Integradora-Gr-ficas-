using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletManager bm;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        bm = FindObjectOfType<BulletManager>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.Rotate(bm.rotation * Time.deltaTime);
    }

    void OnDestroy()
    {
        bm.bulletCount--;
    }
}
