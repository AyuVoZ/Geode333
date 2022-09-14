using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretStand : MonoBehaviour
{

    public GameObject turret;
    public GameObject player;
    public float range;
    public Transform spawn;
    public int[] price = new int[3]; //wood stone gold
    public GameObject RessourceManager;
    public GameObject tip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position,transform.position);
        if(distance < range){
            if (Input.GetKeyDown("space"))
            {
                if ((RessourceManager.GetComponent<RessourceManager>().wood > 10) && (RessourceManager.GetComponent<RessourceManager>().stone > 10))
                {
                    BuildTurret();
                    RessourceManager.GetComponent<RessourceManager>().PayStone(10);
                    RessourceManager.GetComponent<RessourceManager>().PayWood(10);
                }
                
            }
            tip.SetActive(true);
        } else {
            tip.SetActive(false);
        }
    }

    void BuildTurret(){
        Instantiate(turret,spawn.position, spawn.rotation);
        Destroy(gameObject);
    }
}
