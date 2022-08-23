using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Moviment moviment;
    FirstPersonCamera Camera;
    // Start is called before the first frame update
    void Start()
    {
        moviment = GetComponent<Moviment>();
        Camera = GetComponentInChildren<FirstPersonCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        moviment.UpdateMoviment();
        Camera.UpdateCamera();
    }
}
