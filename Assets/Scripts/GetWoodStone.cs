using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWoodStone : MonoBehaviour
{
    public GameObject RessourceManager;
    public GameObject Player;
    public float distance;
    public bool wood;
    public bool stone;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (Vector3.Distance(this.transform.position, Player.transform.position) < distance)
        {
            if(wood){
                RessourceManager.GetComponent<RessourceManager>().AddWood();
            }
            
            if(stone){
                RessourceManager.GetComponent<RessourceManager>().AddStone();
            }
        }
        
    }
}
