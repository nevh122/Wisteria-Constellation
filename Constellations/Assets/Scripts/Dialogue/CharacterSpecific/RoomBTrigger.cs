using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBTrigger : MonoBehaviour
{
    public Dialogue noKey;
    public Dialogue yesKey;
    public PlayerController player;
    public GameObject door;

    public void TriggerDialogue()
    {
        switch (player.StarKey)
        {
            case 0:
                FindObjectOfType<DialogueManager>().StartDialogue(noKey);
                break;
            case 1:
                FindObjectOfType<DialogueManager>().StartDialogue(yesKey);
                door.GetComponent<BoxCollider2D>().isTrigger = true;
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
        
    }
}
