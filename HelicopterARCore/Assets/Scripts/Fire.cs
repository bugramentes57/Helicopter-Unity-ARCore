using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public Transform AtesNoktasi;
    public float AtesHizi;
    public float Sayac;

    public Button button;

    private bool canShoot = true; // Bir sonraki mermiyi atmak için izin

    public int maxHealth = 1; // Düþmanýn maksimum saðlýk deðeri
    private int currentHealth;

    private void Start()
    {
       
        // Button component'ini bul
        Button button = GameObject.Find("Fire_Button").GetComponent<Button>();

        // Button'a týklama event'ini ekle
        button.onClick.AddListener(Shoot);

        
    }

    private void Update()
    {
       // Ýsterseniz Sayac kontrolü de ekleyebilirsiniz, belirli bir süre geçtikten sonra tekrar ateþ edebilir.

        //her bir saniyede bir ateþ edebilir:
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

            canShoot = false; // Bir sonraki ateþe izin verme

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
        // Düþmanýn ölümüyle ilgili iþlemleri burada gerçekleþtir
        Destroy(gameObject); // Düþman objesini yok et
    }*/
}
