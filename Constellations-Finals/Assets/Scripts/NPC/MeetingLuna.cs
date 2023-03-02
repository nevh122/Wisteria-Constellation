using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetingLuna : MonoBehaviour
{
    public DialogueBoxElements meetLunaWithKey, meetLunaWithoutKey, connectingDialogueWithKey, connectingDialogueNoKey;
    public DialogueManager manager;
    public PlayerController player;

    bool hasKey = false;
    bool hasinteracted = false;
    bool questDone = false;

    public AudioSource itemDiscovery;
    void Update()
    {
        if(questDone == true && manager.isDone == true)
        {
            gameObject.SetActive(false);
            itemDiscovery.Play();
        }

        if(player.LakeKey == true)
        {
            hasKey = true;
        }
    }

    public void TriggerDialogue()
    {
        if(manager.hasInteracted == false && hasKey == false && hasinteracted == false)
        {
            manager.StartDialogue(meetLunaWithoutKey);
            hasinteracted = true;
        }
        else if(manager.hasInteracted == false && hasKey == true && hasinteracted == false)
        {
            manager.StartDialogue(meetLunaWithKey);
            questDone = true;
            hasinteracted = true;
        }
        else if (manager.hasInteracted == false && hasKey == true && hasinteracted == true)
        {
            manager.StartDialogue(connectingDialogueWithKey);
            questDone = true;
        }
        else if (manager.hasInteracted == false && hasKey == false && hasinteracted == true)
        {
            manager.StartDialogue(connectingDialogueNoKey);
        }
    }
}
