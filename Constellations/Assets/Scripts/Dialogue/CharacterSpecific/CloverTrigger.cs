using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloverTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;
    public Text inventory;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        player.GetComponent<PlayerController>().CloverLeaf =+ 1;
        gameObject.SetActive(false);
        inventory.text = inventory.text + "\n- Clover Leaf";
    }
}
