using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public float speed_move;
    // Use this for initialization
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed_move;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * speed_move;
        transform.Translate(h, v, 0);
    }
}