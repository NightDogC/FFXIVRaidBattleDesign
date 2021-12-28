using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCAoEhit : AoEhit
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Boss"))
        {
            collider.GetComponent<BossAI>().AddElectrochargeBuff();
        }
    }
}
