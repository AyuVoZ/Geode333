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
    public GameObject floatingText;
    private GameObject text = null;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player[0].transform.position) < distance)
        {
            if(text==null){
                Quaternion rot = Quaternion.Euler(70, 0, 0);
                Vector3 pos = transform.position + new Vector3(0f, 3f, 0f);
                text = Instantiate(floatingText, pos, rot);
                text.GetComponent<TextMesh>().text = "Press SPACE to get " + (wood ? "wood":"stone");
            }
            
            if (Input.GetKeyDown("space"))
                {
                    if(wood){
                        RessourceManager.GetComponent<RessourceManager>().AddWood();
                        audio.Play();
                    }
                    
                    if(stone){
                        RessourceManager.GetComponent<RessourceManager>().AddStone();
                        audio.Play();
                    }
                }
        } else {
            if(text)
                Destroy(text);
        }
    }
}
