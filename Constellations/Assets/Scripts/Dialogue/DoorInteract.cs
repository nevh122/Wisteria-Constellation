using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
    public Dialogue NoKey;
    public Dialogue YesKey;
    public PlayerController player;
    public DialogueManager manager;
    private bool Win;

    public void Update()
    {
        EndGame();
    }
    public void TriggerDialogue()
    {
        switch (player.StarKey)
        {
            case 0:
                FindObjectOfType<DialogueManager>().StartDialogue(NoKey);
                break;
            case 1:
                FindObjectOfType<DialogueManager>().StartDialogue(YesKey);
                Win = true;
              break;
        }
    }
    public void EndGame()
    {
        if(Win == true && manager.IsDone == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
