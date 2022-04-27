using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterJanusStart : MonoBehaviour
{
    public Text maintxt, JanusName;
    [SerializeField]int CaseCode = 0;
    [SerializeField]GameObject ContButton, CloseButton, JanusDP, RigelDP, DetectionRadius;
    public GameObject player, Janus;
    void Update()
    {
        switch (CaseCode)
        {
            case 0:
                JanusName.text = "???";
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "Oh... there's something there in the ground.";
                break;
            case 1:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "An item...?";
                break;
            case 2:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "What the hell do you mean 'an item'?!";
                break;
            case 3:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "?!";
                break;
            case 4:
                JanusName.text = "Janus";
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "That's so rude! I'm not an 'item'! I'm Janus!";
                break;
            case 5:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "A-Ah... I-I see... S-Sorry Mr. Janus...";
                break;
            case 6:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "... you're too formal...";
                break;
            case 7:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "H-Huh...?";
                break;
            case 8:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "Stiff! Formal! Jeez, kid...";
                break;
            case 9:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "... S-Sorry...";
                break;
            case 10:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "Nevermind that. Who are you and what are you doing here?";
                break;
            case 11:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "I-I'm... l-lost...";
                break;
            case 12:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "Yeah captain obvious, of course you're lost.";
                break;
            case 13:
                maintxt.text = "I'm asking WHAT are you doing here.";
                break;
            case 14:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "I-I... d-don't know...";
                break;
            case 15:
                maintxt.text = "I... I just woke up... here...";
                break;
            case 16:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "Huhh...";
                break;
            case 17:
                maintxt.text = "Then kid you have to get out of here.";
                break;
            case 18:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "W-What?";
                break;
            case 19:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "It's not safe here. Best you go get out while you still can.";
                break;
            case 20:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "C-Can you...?";
                break;
            case 21:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "... Tsk.";
                break;
            case 22:
                maintxt.text = "Fine. I ain't helping you with the last key though.";
                break;
            case 23:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "H-Huh?!";
                break;
            case 24:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "You're doing all of that by yourself, I ain't helping.";
                break;
            case 25:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "U-Um... A-Are you sure...?";
                break;
            case 26:
                RigelDP.SetActive(false);
                JanusDP.SetActive(true);
                maintxt.text = "I'm sure. Lucky you that I already finished the others.";
                break;
            case 27:
                RigelDP.SetActive(true);
                JanusDP.SetActive(false);
                maintxt.text = "I... O-Okay...";
                break;
            case 28:
                RigelDP.SetActive(false);
                JanusDP.SetActive(false);
                maintxt.text = "*Janus joined the party*";
                ContButton.SetActive(false);
                CloseButton.SetActive(true);
                player.GetComponent<PlayerController>().enabled = true;
                break;
        }   
    }
    public void ContinueButton()
    {
        CaseCode++;
    }
    public void ExitButton()
    {
        player.GetComponent<PlayerController>().enabled = true;
        DetectionRadius.SetActive(false);
        Janus.GetComponent<FollowPlayer>().enabled = true;
        Janus.GetComponent<CircleCollider2D>().isTrigger = true;
    }

}
