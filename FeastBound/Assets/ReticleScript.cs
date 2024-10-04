using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScript : MonoBehaviour
{
    private Vector3 mousePosition;

    void Start()
    {
        
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        gameObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, -5);
    }
}
