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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);   
        player = GameObject.FindGameObjectsWithTag("Player");
        RessourceManager = GameObject.FindGameObjectsWithTag("RessourceManager");
    }

    // Update is called once per frame
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
        //Debug.Log(distance);
        //Debug.Log("SQUID");
        if(distance < upgradeRange){
            //tip.SetActive(true);
            Debug.Log("SQUIDGAME");
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("GAME");
                if ((RessourceManager[0].GetComponent<RessourceManager>().wood >= price) && (RessourceManager[0].GetComponent<RessourceManager>().stone >= price) && (RessourceManager[0].GetComponent<RessourceManager>().gold >= price))
                {
                    fireRate +=1f;
                    //tip.SetActive(false);
                    RessourceManager[0].GetComponent<RessourceManager>().PayStone(price);
                    RessourceManager[0].GetComponent<RessourceManager>().PayWood(price);
                    RessourceManager[0].GetComponent<RessourceManager>().PayGold(price);
                    price+=5;
                }
            }
            
        } else {
            //tip.SetActive(false);
        }

    }
}
