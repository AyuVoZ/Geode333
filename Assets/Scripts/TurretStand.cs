using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretStand : MonoBehaviour
{

    public GameObject turret;
    public float range;
    public Transform spawn;
    public GameObject ressourceManager;
    public GameObject floatingText;
    private GameObject text = null;

    private GameObject[] player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player[0].transform.position,transform.position);
        if(distance < range){
            if(text==null){
                Quaternion rot = Quaternion.Euler(70, 0, 0);
                Vector3 pos = transform.position + new Vector3(0f, 3f, 0f);
                text = Instantiate(floatingText, pos, rot);
                text.GetComponent<TextMesh>().text = "Press SPACE to build !";
            }
                    

            if (Input.GetKeyDown("space"))
            {
                if ((ressourceManager.GetComponent<RessourceManager>().wood >= 10) && (ressourceManager.GetComponent<RessourceManager>().stone >= 10))
                {
                    BuildTurret();
                    if(text)
                        Destroy(text);
                    ressourceManager.GetComponent<RessourceManager>().PayStone(10);
                    ressourceManager.GetComponent<RessourceManager>().PayWood(10);
                }
            }
            
        } else {
            if(text)
                Destroy(text);
        }
    }

    void BuildTurret(){
        Instantiate(turret,spawn.position, spawn.rotation);
        Destroy(gameObject);
    }
}
