using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    [SerializeField]GameObject TransparentObject;
    SpriteRenderer ObjectRenderer;
    [SerializeField] float transparency;

    private void Start()
    {
        ObjectRenderer = TransparentObject.GetComponent<SpriteRenderer>();
    }

    //Changes gameobject to be transparent when player is behind it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObjectRenderer.color = new Color (1,1,1,transparency);
        }
    }

    //reverts back to normal color when player is outside the object
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObjectRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}
