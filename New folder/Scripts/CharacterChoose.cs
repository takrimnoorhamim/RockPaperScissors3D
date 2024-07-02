using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoose : MonoBehaviour
{
    //public GameObject player;
    public GameObject characterChoosePanel;

    public GameObject boyCharacter;
    public GameObject girlCharacter;

    public Animator boy_animator;
    public Animator girl_animator;

    public PlayerController playerController;

    private void Awake()
    {
        playerController.enabled = false;
    }

    public void onBoyCharacterChoose()
    {
        playerController.enabled = true;
        //player.SetActive(true);
        boyCharacter.SetActive(true);
        playerController.animator = boy_animator;
        characterChoosePanel.SetActive(false);
    }

    public void onGirlCharacterChoose()
    {
        playerController.enabled = true;
        //player.SetActive(true);
        girlCharacter.SetActive(true);
        playerController.animator = girl_animator;
        characterChoosePanel.SetActive(false);
    }


}
