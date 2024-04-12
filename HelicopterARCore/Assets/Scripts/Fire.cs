using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public Transform AtesNoktasi;
    public float AtesHizi;
    public float Sayac;

    public Button button;

    private bool canShoot = true; // Bir sonraki mermiyi atmak i�in izin

    public int maxHealth = 1; // D��man�n maksimum sa�l�k de�eri
    private int currentHealth;

    private void Start()
    {
       
        // Button component'ini bul
        Button button = GameObject.Find("Fire_Button").GetComponent<Button>();

        // Button'a t�klama event'ini ekle
        button.onClick.AddListener(Shoot);

        
    }

    private void Update()
    {
       // �sterseniz Sayac kontrol� de ekleyebilirsiniz, belirli bir s�re ge�tikten sonra tekrar ate� edebilir.

        //her bir saniyede bir ate� edebilir:
        Sayac += Time.deltaTime;
        if (Sayac >= 1f)
        {
            canShoot = true;
            Sayac = 0f;
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            GameObject bullet = Instantiate(Bullet, AtesNoktasi.position, AtesNoktasi.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = AtesNoktasi.forward * AtesHizi;

            canShoot = false; // Bir sonraki ate�e izin verme

            Destroy(bullet, 1f);
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                Die();
            }

        }
    }
    private void Die()
    {
        // D��man�n �l�m�yle ilgili i�lemleri burada ger�ekle�tir
        Destroy(gameObject); // D��man objesini yok et
    }*/
}
