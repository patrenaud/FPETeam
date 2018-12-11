using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            if ((other.tag == "Player" || other.tag == "Enemy"))
            {
                DamageableEntity player;
                player = other.GetComponent<DamageableEntity>();
                player.ReceiveHit();
            }

            Destroy(gameObject);
        }
    }
}