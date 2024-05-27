using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private SavedData.CharacterData characterData;
    private float characterDamage;

    public float bulletLife = 2;


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
            Monster enemy = collision.gameObject.GetComponentInParent<Monster>();
            if (enemy != null)
            {
                enemy.TakeDamage(20 * characterDamage);

                if (enemy.IsDead)
                    Destroy(collision.gameObject);
            }
        }
    }
}
