using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject target;
    void LateUpdate()
    {
        transform.position = transform.position - 1 / 100 * (transform.position - target.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
