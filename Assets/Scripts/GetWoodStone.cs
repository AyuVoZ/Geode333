using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWoodStone : MonoBehaviour
{
    public GameObject RessourceManager;
    AudioSource audio;
    public float distance;
    public bool wood;
    public bool stone;
    private GameObject[] player;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            {
                print(Vector3.Distance(transform.position, player[0].transform.position));
                if (Vector3.Distance(transform.position, player[0].transform.position) < distance)
                    {
                        print("Harvest");
                        if(wood){
                            RessourceManager.GetComponent<RessourceManager>().AddWood();
                            audio.Play();
                        }
                        
                        if(stone){
                            RessourceManager.GetComponent<RessourceManager>().AddStone();
                            audio.Play();
                        }
                    }
            }
    }
}
