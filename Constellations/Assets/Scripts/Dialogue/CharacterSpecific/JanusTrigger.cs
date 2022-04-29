using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanusTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager manager;

    public GameObject Janus;
    public GameObject JanusInteractZone;
    bool thisScript = false;

    public void TriggerDialogue()
    {
        manager.StartDialogue(dialogue);
        thisScript = true;
    }

    public void Update()
    {
        if(manager.IsDone == true && thisScript == true)
        {
            Janus.GetComponent<CircleCollider2D>().enabled = false;
            Janus.GetComponent<FollowPlayer>().enabled = true;
            JanusInteractZone.SetActive(false);

        }
    }
}
