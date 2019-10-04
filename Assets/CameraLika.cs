using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLika : MonoBehaviour
{
    private GameObject Igrac;    
    private float minY = 0;
    private float maxY = 20;


    // Start is called before the first frame update
    void Start()
    {
        Igrac = GameObject.FindGameObjectWithTag("Igrac");

    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(Igrac.transform.position.x, -0.43f, Character.desnoOgranicenje-1.8f);
        float y = Mathf.Clamp(Igrac.transform.position.y, minY, maxY);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
