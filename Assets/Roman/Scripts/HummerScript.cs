using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class HummerScript : Weapon
{
    private SavedData.InputData InputData;
    private SavedData.CharacterData characterData;
    [Space]
    [Header("\t OTHER PROPERTIES")]
    private float characterDamage;
    public Camera mainCamera;
    public Player Player;
    [SerializeField] private GameObject MenuUI;

    private Animator hummerAnimator;
    void Start()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();

        characterData = new SavedData.CharacterData();
        characterData = characterData.Load();
        characterDamage = characterData.Property.Damage;

        hummerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Player.IsDead || MenuUI.activeInHierarchy)
            return;

        Attack();
        PlayWalkAnimation();
    }

    private void PlayWalkAnimation()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {

            hummerAnimator.SetBool("Walking", true);
        }
        else
        {
            hummerAnimator.SetBool("Walking", false);
        }

    }

    private void Attack()
    {
        if (Input.GetKeyDown(InputData.Shoot))
        {
            AttackLogic();
            hummerAnimator.SetTrigger("isAttack");
        }
    }

    private void AttackLogic()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, _distance))
        {
            Monster enemy = hit.collider.GetComponentInParent<Monster>();
            if (enemy != null)
            {
                enemy.TakeDamage(30 * characterDamage);
                Debug.Log("xixi xaxax");
            }
        }
    }
}
