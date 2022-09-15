using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 100f;
    public GameObject particle;

    public void setTarget(Transform _target){
        target = _target;
    }

    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distTF = speed * Time.deltaTime;

        if(dir.magnitude<=distTF){
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distTF, Space.World);
    }

    void HitTarget(){
        Instantiate(particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    

}
