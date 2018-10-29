using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanics : MonoBehaviour {

    public GameObject laserPrefab;
    public Transform laserSpawnPoint;
    public Rigidbody2D laserSpawnPointRB2D;
    public float laserSpeed = 40;
    public float laserLifeTime=4;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    // Use this for initialization
    void Start () {
		laserSpawnPointRB2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("FireLaser") == 1 && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
	}

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab);

        //Physics.IgnoreCollision(laser.GetComponent<Collider>(), laserSpawnPoint.parent.GetComponent<Collider>());

        //laser position and rotation
        laser.transform.position = laserSpawnPoint.position;
        Vector3 rotation = laser.transform.rotation.eulerAngles;
        laser.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, laserSpawnPoint.eulerAngles.z);

        //float shipRotation = laserSpawnPointRB2D.transform.rotation.z;
        //Vector2 shipVelocity = laserSpawnPointRB2D.velocity;
        //laser.GetComponent<Rigidbody2D>().velocity=(shipVelocity * laserSpawnPoint.up * laserSpeed * shipRotation);
        //laser.GetComponent<Rigidbody2D>().AddForce(laserSpawnPoint.up * laserSpeed + laserSpawnPointRB2D.transform.rotation.eulerAngles);
        //laser.GetComponent<Rigidbody2D>().AddForce(laserSpeed * laserSpawnPointRB2D.transform.rotation.eulerAngles * laserSpawnPointRB2D.velocity); 
        //float shipRotation = laserSpawnPointRB2D.transform.rotation.z;
        //laser.GetComponent<Rigidbody2D>().AddForce(laserSpeed * transform.up);
        laser.GetComponent<Rigidbody2D>().AddForce(laserSpawnPoint.up*laserSpeed, ForceMode2D.Impulse);



        StartCoroutine(DestroyProjectileAfterXTime(laser, laserLifeTime));

    }


    private IEnumerator DestroyProjectileAfterXTime(GameObject laser, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(laser);
    }
}
