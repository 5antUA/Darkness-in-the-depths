using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletLife = 2;
    private SavedData.CharacterData characterData;
    private float characterDamage;

    private void Awake()
    {
        characterData = new SavedData.CharacterData();
        characterData = characterData.Load();

        characterDamage = characterData.Property.Damage;

        Destroy(gameObject, bulletLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(20 * characterDamage);
                Debug.Log("Enemy health: " + enemy.Health);
                if (enemy.IsDead)
                    Debug.Log("Dead");
            }
        }
    }
}
