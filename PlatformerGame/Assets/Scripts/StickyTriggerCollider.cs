using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTriggerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.parent == null) other.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.transform.parent == transform) other.transform.SetParent(null);
    }
}
