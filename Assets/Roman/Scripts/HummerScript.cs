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
    public bool coolDown { get; private set; }
    private Coroutine coolDownCoroutine;
    public Camera mainCamera;
    public Player Player;
    private AudioSource AudioSource;
    public AudioClip AttackAudioClip;
    [SerializeField] private GameObject MenuUI;

    private Animator hummerAnimator;
    void Start()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();

        characterData = new SavedData.CharacterData();
        characterData = characterData.Load();
        characterDamage = characterData.Property.Damage;

        coolDown = false;
        isReload = false;

        hummerAnimator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Player.IsDead || MenuUI.activeInHierarchy)
            return;

        Attack();
        PlayWalkAnimation();
    }

    private void OnDisable()
    {
        if (coolDownCoroutine != null)
        {
            StopCoroutine(coolDownCoroutine);
            coolDown = false;
        }
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

    private IEnumerator CooldownCoroutine()
    {
        coolDown = true;
        yield return new WaitForSeconds(0.5f);
        coolDown = false;
    }

    private void Attack()
    {
        if (Input.GetKeyDown(InputData.Shoot))
        {
            if (!coolDown)
            {
                AttackLogic();
                hummerAnimator.SetTrigger("isAttack");
                AudioSource.PlayOneShot(AttackAudioClip);
                coolDownCoroutine = StartCoroutine(CooldownCoroutine());
            }
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
                if (!Player.Controller.isGrounded)
                {
                    enemy.TakeDamage(30 * 2 * characterDamage);
                }
                else
                {
                    enemy.TakeDamage(30 * characterDamage);
                }
            }
        }
    }
}
