using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AreaNextLevel : MonoBehaviour
{
    
    PlayerInput input;
    public PlayableDirector dialogueDirector;
    public GameObject levelLoader;
    public bool isEnding = false;
    private int enter = 1;
    public Animator cualliAnim;

    [Header("Save variables")]
    Player player;
    characterMovement classCharacter;
    ItemPicker classItem;
    EnergySystem classEnergy;
    SuperCacaoPicker classSuperCacao;
    SceneCounter classSceneCounter;
    private void Awake()
    {
        input = new PlayerInput();
        player = GameObject.FindObjectOfType<Player>();
        classCharacter = GameObject.FindObjectOfType<characterMovement>();
        classItem = GameObject.FindObjectOfType<ItemPicker>();
        classEnergy = GameObject.FindObjectOfType<EnergySystem>();
        classSuperCacao = GameObject.FindObjectOfType<SuperCacaoPicker>();
        classSceneCounter = GameObject.FindObjectOfType<SceneCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChangeScene")
        {
            isEnding = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        //Debug.Log(other.name);
        if (other.tag == "ChangeScene")
        {
            cualliAnim.SetBool("IsWalking", false);
            cualliAnim.SetBool("IsRunning", false);

            if (enter == 1)
                {
                dialogueDirector.Play();
                    enter++;

                // process all the int saves
                //player.SavePlayer();
                classCharacter.SaveHealthData();
                classItem.SaveCocoaData();
                classEnergy.SaveEnergyData();
                classSuperCacao.SaveSuperCacaoData();
                classSceneCounter.SaveSceneData();
                }
            if (isEnding)

                levelLoader.GetComponent<LevelLoader>().LoadIndexLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //public void PlayCinematicAgain()
    //{
    //    dialogueDirector.Play();
    //    if(isEnding)
    //       levelLoader.GetComponent<LevelLoader>().LoadIndexLevel(2);
    //}

    private void ChangeLevel(InputAction.CallbackContext obj)
    {
        isEnding = true;
        
    }

    private void OnEnable()
    {
        input.CharacterController.Jump.Enable();
        input.CharacterController.Jump.performed += ChangeLevel;
    }

    private void OnDisable()
    {
        input.CharacterController.Jump.Disable();
    }

}
