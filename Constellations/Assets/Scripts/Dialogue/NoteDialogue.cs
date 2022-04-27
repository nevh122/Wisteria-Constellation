using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteDialogue : MonoBehaviour
{
    public Text maintxt;
    [SerializeField]GameObject ContButton, CloseButton, RigelDP;
    public GameObject player;
    [SerializeField] int CaseCode = 0;

    void Update()
    {
        switch (CaseCode)
        {
            case 0:
                maintxt.text = "Theres a note on the desk....";
                break;
            case 1:
                ContButton.SetActive(false);
                RigelDP.SetActive(false);
                maintxt.text = "The Tree can't tell shapes nor feel things;\nonly she can see colors she wants to have.";
                break;
            default:
                break;
        }
    }
    public void ContinueButton()
    {
        CaseCode = CaseCode+1;
    }
    public void ExitButton()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }
}
