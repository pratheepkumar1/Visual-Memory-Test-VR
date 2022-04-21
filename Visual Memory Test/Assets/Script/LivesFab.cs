using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesFab : MonoBehaviour
{

    public Material Active;
    public Material Inactive;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = Active;
    }


    public void KillLife()
    {
        gameObject.GetComponent<Renderer>().material = Inactive;
    }



}
