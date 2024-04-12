using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject EnemyExplosion;

    public int maxHealth = 1; // Düþmanýn maksimum saðlýk deðeri
    private int currentHealth; // Düþmanýn güncel saðlýk deðeri

    private void Start()
    {
        currentHealth = maxHealth;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Die();
            }

        }
    }

    private void Die()
    {
        // Düþmanýn ölümüyle ilgili iþlemleri burada gerçekleþtir
        Destroy(gameObject); // Düþman objesini yok et
    }
}
