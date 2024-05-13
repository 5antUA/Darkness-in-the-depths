using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AttackControl : MonoBehaviour
{
    public float CorutineTime = 1;
    public float attackDistanse = 10;
    private GameObject mob;
    private GameObject player;
    private float distance;
    private void Awake()
    {
        mob = gameObject;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(mob.transform.position, player.transform.position);
        if (distance < attackDistanse)
        {
            StartCoroutine(routine: AttackControll());
            mob.transform.LookAt(new Vector3 (player.transform.position.x, mob.transform.position.y, player.transform.position.z));
            Debug.Log("weeee");
        }
    }

    private IEnumerator AttackControll() {
        yield return new WaitForSeconds(CorutineTime);
        while (distance < attackDistanse)
        {
            mob.GetComponent<Animator>().SetBool("Attack",true);
            yield return new WaitForSeconds(CorutineTime);
        }
        mob.GetComponent<Animator>().SetBool("Attack", false);
    }
}
