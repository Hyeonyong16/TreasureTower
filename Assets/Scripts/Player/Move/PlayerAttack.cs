using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject stoneBulletEffect;
    public GameObject woodBulletEffect;
    public GameObject enemyBulletEffect;

    ParticleSystem bulletParticleSystem;

    PlayerStat playerStat;
    ReloadProgressBar reloadProgressBar;

    private IEnumerator stoneCo;
    private IEnumerator woodCo;
    private IEnumerator enemyCo;

    // Start is called before the first frame update
    void Start()
    {
        playerStat = GetComponent<PlayerStat>();
        reloadProgressBar = GameObject.Find("Bullet UI").gameObject.GetComponent<ReloadProgressBar>();
    }

    // Update is called once per frame
    void Update()
    {
        //사격
        if(Input.GetMouseButton(0))     //일단 확인용 눌렀을때만 적용   ->   나중에 바꿔야됨 
        {
            if (playerStat.shotCheck && playerStat.CurrentAmmo > 0 && playerStat.ReloadCheck == false)
            {
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                int layerMask = (1 << LayerMask.NameToLayer("Wall"));
                RaycastHit hit = new RaycastHit();

                StartCoroutine(ShotRateCheck());
                
                if (Physics.Raycast(ray, out hit, layerMask))
                {
                    Debug.Log("hit: " + hit.transform.name);
                    if (hit.collider.tag == "Stone")
                    {
                        stoneBulletEffect.SetActive(true);

                        if(stoneCo != null)
                            StopCoroutine(stoneCo);

                        stoneCo = InActiveBulletEffect(stoneBulletEffect);
                        StartCoroutine(stoneCo);

                        bulletParticleSystem = stoneBulletEffect.GetComponent<ParticleSystem>();
                        Debug.Log("Stone hit");

                        stoneBulletEffect.transform.position = hit.point;
                        stoneBulletEffect.transform.forward = hit.normal;
                        bulletParticleSystem.Play();
                    }

                    if (hit.collider.tag == "Wood")
                    {
                        woodBulletEffect.SetActive(true);

                        if (woodCo != null)
                            StopCoroutine(woodCo);

                        woodCo = InActiveBulletEffect(woodBulletEffect);
                        StartCoroutine(woodCo);

                        bulletParticleSystem = woodBulletEffect.GetComponent<ParticleSystem>();
                        Debug.Log("Wood hit");

                        woodBulletEffect.transform.position = hit.point;
                        woodBulletEffect.transform.forward = hit.normal;
                        bulletParticleSystem.Play();
                    }

                    if(hit.collider.tag == "Enemy")
                    {
                        enemyBulletEffect.SetActive(true);

                        if (enemyCo != null)
                            StopCoroutine(enemyCo);

                        enemyCo = InActiveBulletEffect(enemyBulletEffect);
                        StartCoroutine(enemyCo);

                        bulletParticleSystem = enemyBulletEffect.GetComponent<ParticleSystem>();
                        Debug.Log("Enemy hit");

                        enemyBulletEffect.transform.position = hit.point;
                        enemyBulletEffect.transform.forward = hit.normal;
                        bulletParticleSystem.Play();

                        GameObject enemy = GameObject.Find(hit.transform.name);
                        enemy.GetComponent<EnemyGetDamaged>().GetDamage(playerStat.playerDamage);
                    }
                }
            }
        }

        //재장전
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (!playerStat.ReloadCheck)
            {
                StartCoroutine(ReloadRate());
            }
        }
    }

    IEnumerator ShotRateCheck()
    {
        playerStat.CurrentAmmo--;
        playerStat.shotCheck = false;

        yield return new WaitForSeconds(playerStat.shotRate);

        playerStat.shotCheck = true;
    }

    IEnumerator ReloadRate()
    {
        playerStat.ReloadCheck = true;
        reloadProgressBar.reloadUI.SetActive(true);
        reloadProgressBar.timerStart();

        yield return new WaitForSeconds(playerStat.ReloadTime);

        reloadProgressBar.timerReset();
        playerStat.CurrentAmmo = 30;
        reloadProgressBar.reloadUI.SetActive(false);

        playerStat.ReloadCheck = false;
    }

    IEnumerator InActiveBulletEffect(GameObject bulletEffect)
    {
        yield return new WaitForSeconds(5.0f);
        bulletEffect.SetActive(false);
    }
}
