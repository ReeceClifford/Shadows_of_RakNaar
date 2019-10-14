using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectVoidEssence : MonoBehaviour {

    public int currencyToAdd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)
            return;
        currencyToAdd = Random.Range(1, 11);
        VoidEssenceManager.AddCurrency(currencyToAdd);
        Destroy(gameObject);

    }

}
