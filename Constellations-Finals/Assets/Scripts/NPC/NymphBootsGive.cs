using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NymphBootsGive : MonoBehaviour
{
    public DialogueBoxElements convoStart, reConvo;
    bool hasBoots = false;
    bool dialogueAndSoundCheck = false;
    public PlayerController player;
    public DialogueManager manager;
    public AudioSource itemDiscover;

    public void TriggerDialogue()
    {
        if(hasBoots == false && manager.hasInteracted == false)
        {
            manager.StartDialogue(convoStart);
            dialogueAndSoundCheck = true;
            hasBoots = true;
            dialogueAndSoundCheck = true;
            player.Boots = true;
            player.inventoryText.text = "\n - Running Shoes";
        }
        else if(hasBoots == true && manager.hasInteracted == false)
        {
            manager.StartDialogue(reConvo);
        }
    }

    public void Update()
    {
        if(dialogueAndSoundCheck == true && manager.isDone == true)
        {
            itemDiscover.Play();
            dialogueAndSoundCheck = false;
        }
    }
}
