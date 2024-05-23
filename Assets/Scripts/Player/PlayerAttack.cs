using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject Gun;
    [SerializeField] private ParticleSystem VFXMelee;

    private double attackAngle;

    public int choosedWeapon;

    [SerializeField] private bool facingRight = true;
    private Vector2 pos;


    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attacableLayer;
    [SerializeField] private float damageAmount = 1f;
    private RaycastHit2D[] hits;

    public static bool ShouldBeDamageing { get; private set; } = false;

    private Animator animator;

    [SerializeField] private GameObject weapon;
    [SerializeField] private Sprite fork;
    [SerializeField] private Sprite sword;
    [SerializeField] private Sprite gun;

    [SerializeField] private float timeBtwMelee = 1f;
    private float meleeTimer;
    [SerializeField] private float timeBtwDistance = 1.5f;
    private float distanceTimer;
    private bool canlook;
    public bool ShouldBeDamaging { get; private set; } = false;
    private List<IDamageable> iDamageables = new List<IDamageable>();

    private float defaultWeaponRotation;


    void Start()
    {
        VFXMelee = VFXMelee.GetComponent<ParticleSystem>();
        VFXMelee.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackAngle = 0;
        choosedWeapon = 1;
        meleeTimer = timeBtwMelee;
        distanceTimer = timeBtwDistance;
        weapon.GetComponent<SpriteRenderer>().sprite = fork;

        defaultWeaponRotation = Gun.GetComponent<Transform>().localEulerAngles.z;
    }

    void Update()
    {
        if (GamePause.IsPaused || Time.timeScale == 0)
            return;

        pos = Camera.main.WorldToScreenPoint(transform.localPosition);

        attackAngle = FindAngle(pos, Input.mousePosition);
        if (facingRight)
            attackAngle = 360 - attackAngle;


        if (Input.GetKeyDown(KeyCode.Q))
        {
            weapon.GetComponent<SpriteRenderer>().sprite = gun;
            choosedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            weapon.GetComponent<SpriteRenderer>().sprite = fork;
            Gun.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, defaultWeaponRotation);
            choosedWeapon = 1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (choosedWeapon == 0)
            {
                if (distanceTimer > timeBtwDistance)
                {
                    distanceTimer = 0;
                    animator.SetTrigger("AttackDistance");
                    //DistanceAttack();
                }
            }
            else
            {
                if (meleeTimer > timeBtwMelee)
                {
                    meleeTimer = 0;
                    animator.SetTrigger("AttackMelee");
                }
            }
        }
        meleeTimer += Time.deltaTime;
        distanceTimer += Time.deltaTime;

        canlook = meleeTimer > timeBtwMelee && distanceTimer > timeBtwDistance;

        if (choosedWeapon == 0)
            RotateGun(attackAngle);
        if (canlook)
            LookAtCursor();
    }

    void LookAtCursor()
    {
        if (Input.mousePosition.x < pos.x && facingRight) Flip();
        else if (Input.mousePosition.x > pos.x && !facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        var vec = transform.localScale;
        transform.localScale = new Vector2(-vec.x, vec.y);
    }

    private double FindAngle(Vector2 a, Vector2 b)
    {
        var angle = Mathf.Acos((b.y - a.y) / Mathf.Sqrt((b - a).x * (b - a).x + (b - a).y * (b - a).y)) * 180 /
                    Mathf.PI;
        return angle;
    }

    public IEnumerator MeleeAttack()
    {
        ShouldBeDamagingToTrue();

        while (ShouldBeDamageing)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attacableLayer);

            for (var i = 0; i < hits.Length; i++)
            {
                var iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

                if (iDamageable != null && !iDamageable.HasTakenDamage)
                {
                    iDamageable.Damage(damageAmount);
                    iDamageables.Add(iDamageable);
                }
            }
            yield return null;
        }

        ReturnAttackablesToDamageable();
    }

    private void ReturnAttackablesToDamageable()
    {
        foreach (var thing in iDamageables)
        {
            thing.HasTakenDamage = false;
        }
    }

    void DistanceAttack()
    {
        GetComponentInChildren<Arbalest>().Shoot();
    }

    void RotateGun(double angle)
    {
        Gun.transform.rotation = Quaternion.Euler(0, 0, (float)attackAngle);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

    #region Animation Triggers

    public void ShouldBeDamagingToTrue()
    {
        ShouldBeDamageing = true;
        VFXMelee.Play();
    }

    public void ShouldBeDamagingToFalse()
    {
        ShouldBeDamageing = false;
        VFXMelee.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    #endregion

    public void ChangeGun(Sprite newGun)
    {
        gun = newGun;
        if (choosedWeapon == 0)
            weapon.GetComponent<SpriteRenderer>().sprite = gun;
    }
}