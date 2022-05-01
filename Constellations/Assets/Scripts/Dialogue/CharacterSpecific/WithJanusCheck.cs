using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithJanusCheck : MonoBehaviour
{
    public Dialogue noJanus;
    public PlayerController player;
    public GameObject door;

    public void Update()
    {
        if(player.withJanus == 1)
        {
            door.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.SetActive(false);
        }
    }
    public void TriggerDialogue()
    {
        switch (player.withJanus)
        {
            case 0:
                FindObjectOfType<DialogueManager>().StartDialogue(noJanus);
                break;
            default:
                break;
        }

    }
}
