using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 1f;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    public GameObject impactEffect;

    public float impactForce = 30f;

    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    private float accuracyNum = 0f;

    private float accuracyDenom = 0f;

    private float damageDealt = 0f;

    [SerializeField] private AudioClip gunshot;

    public AudioSource _audioSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
            accuracyDenom = accuracyDenom + 1;
        }
    }

    //shoots gun
    void Shoot() {
        _audioSource.PlayOneShot(gunshot);
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) {
            accuracyNum = accuracyNum + 1;
            damageDealt = damageDealt + damage;
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect,hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
    public float accuracy(){
        return accuracyNum/accuracyDenom;
    }
    public float dmg(){
        return damageDealt;
    }
}
