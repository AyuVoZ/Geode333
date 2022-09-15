using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target = null;
    public float range = 15f;

    public float turnSpeed = 10f;
    public float fireRate = 1f;

    private float fireCountdown = 0f;

    public GameObject bulletPf;
    public Transform firePoint;

    private int price = 10;

    private GameObject[] player;

    private GameObject[] RessourceManager;
    public GameObject tip;
    public float upgradeRange = 3f;

    public GameObject floatingText;

    private GameObject text = null;
    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);   
        player = GameObject.FindGameObjectsWithTag("Player");
        RessourceManager = GameObject.FindGameObjectsWithTag("RessourceManager");
    }

    void Update()
    {
        Upgrade();
        if(target == null) {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f,rotation.y,0f);

        if (fireCountdown <= 0f){
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearest = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance=distance;
                nearest = enemy;
            }
        }

        if(nearest != null && shortestDistance <= range) {
            target = nearest.transform;
        } else
        {
            target = null;
        }
    }

    void Shoot(){
        GameObject bulletGO = (GameObject)Instantiate(bulletPf, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
            bullet.setTarget(target);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Upgrade(){
        float distance = Vector3.Distance(player[0].transform.position,transform.position);

        if(distance < upgradeRange){

            if(text==null){
                Quaternion rot = Quaternion.Euler(70, 0, 0);
                Vector3 pos = transform.position + new Vector3(0f, 3f, 0f);
                text = Instantiate(floatingText, pos, rot);
                text.GetComponent<TextMesh>().text = "Price : " + price.ToString();
            }

            if (Input.GetKeyDown("space"))
            {
                if ((RessourceManager[0].GetComponent<RessourceManager>().wood >= price) && (RessourceManager[0].GetComponent<RessourceManager>().stone >= price) && (RessourceManager[0].GetComponent<RessourceManager>().gold >= price))
                {
                    if(text)
                        Destroy(text);
                    fireRate +=1f;
                    RessourceManager[0].GetComponent<RessourceManager>().PayStone(price);
                    RessourceManager[0].GetComponent<RessourceManager>().PayWood(price);
                    RessourceManager[0].GetComponent<RessourceManager>().PayGold(price);
                    price+=5;
                }
            }
            
        } else {
            if(text)
                Destroy(text);
        }

    }
}
