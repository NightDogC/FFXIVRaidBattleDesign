using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCloud : MonoBehaviour
{
    public int lastingTime;
    void Awake()
    {
        StartCoroutine("Destroyself");
    }
    private IEnumerator Destroyself()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForSeconds(lastingTime-0.2f);
        GetComponent<Animator>().SetTrigger("End");
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
