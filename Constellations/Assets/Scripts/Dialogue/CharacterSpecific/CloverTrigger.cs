using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloverTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        player.GetComponent<PlayerController>().CloverLeaf =+ 1;
        gameObject.SetActive(false);
    }
}
