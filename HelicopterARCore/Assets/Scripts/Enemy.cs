using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject EnemyExplosion;

    public int maxHealth = 1; // D��man�n maksimum sa�l�k de�eri
    private int currentHealth; // D��man�n g�ncel sa�l�k de�eri

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
        // D��man�n �l�m�yle ilgili i�lemleri burada ger�ekle�tir
        Destroy(gameObject); // D��man objesini yok et
    }
}
