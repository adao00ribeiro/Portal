using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Moviment moviment;
    // Start is called before the first frame update
    void Start()
    {
        moviment = GetComponent<Moviment>();
    }

    // Update is called once per frame
    void Update()
    {
        moviment.UpdateMoviment();
    }
}
