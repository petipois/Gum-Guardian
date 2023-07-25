using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f, lifeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Enemy newEnemy = collision.gameObject.GetComponent<Enemy>();
        if(newEnemy!=null)
        {
            newEnemy.DamageEnemy();

            LevelManager.instance.RemovePlaque();

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
