using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator ani;
    private DragonController dragonController;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        dragonController = GetComponent<DragonController>();
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKey(KeyCode.F)  && cooldownTimer > attackCooldown && dragonController.canAttack())
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        ani.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<FireController>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
