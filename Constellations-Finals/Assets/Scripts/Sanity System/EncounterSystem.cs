using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterSystem : MonoBehaviour
{
    public PlayerController playerController;

    public Camera mainCam;
    public Camera encounterCam;

    public Image transitionImage;
    public Animator transitionAnim;
 
    public bool inEncounter = false;
    public GameObject Player;

    public GameObject encounterPlayer;
    public GameObject EPSpawn;

    public GameObject Enemy1, Enemy2;
    public GameObject Espawn1, Espawn2;

    public void Update()
    {
        if(playerController.anxietyLevel == 1 && inEncounter == false)
        {
            inEncounter = true;
            StartCoroutine(StartEncounter());
        }
    }

    IEnumerator StartEncounter()
    {
        Player.gameObject.GetComponent<PlayerController>().enabled = false;
        Player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        Player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        transitionAnim.SetBool("Transition", true);
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        mainCam.enabled = false;
        encounterPlayer.SetActive(true);
        Enemy1.transform.position = Espawn1.transform.position;
        Enemy2.transform.position = Espawn2.transform.position;
        encounterPlayer.transform.position = EPSpawn.transform.position;
        encounterCam.enabled = true;
        transitionAnim.SetBool("Transition", false);
        encounterPlayer.GetComponent<PlayerMovement>().enabled = true;
        encounterPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    }


}
