using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FylingDino : MonoBehaviour
{
    private Transform _PlayerTranform;
    void Start()
    {
        _PlayerTranform = GameObject.FindWithTag("Dino").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(_PlayerTranform.position,transform.position) < 55)
        {
            transform.Translate(Vector3.forward*13*Time.fixedDeltaTime);
        }
    }
}
