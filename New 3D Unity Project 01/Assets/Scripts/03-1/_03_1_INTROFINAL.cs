using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _03_1_INTROFINAL : MonoBehaviour {
    public Transform animal;
    public PCCtrl pc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("AnimalLeave", 2f);
            pc.enabled = false;
            pc.gameObject.GetComponent<Animator>().SetBool("isWalking", false);

        }
    }

    void AnimalLeave()
    {
        animal.gameObject.GetComponent<Animator>().SetTrigger("AnimalLeave");
        Invoke("AfterLeave", 1.5f);
    }
    void AfterLeave()
    {
        pc.enabled = true;
        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
    }
}
