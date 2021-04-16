using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicController : MonoBehaviour
{
    public GameObject target;
    public GameObject explosion;
    public bool addScore = false;


    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Target");
         
    }

    // Update is called once per frame
    void Update() {
    }

    public void OnCollisionEnter(Collision target) {

        Debug.Log("target hit");
        addScore = true;
        explosion.SetActive(true);

        Destroy(this.gameObject, 1.0f);
        Destroy(target.gameObject, 0.5f);
        Invoke("temporary", 0.5f);

    }

    public void temporary() {
        addScore = false;
    }


}
