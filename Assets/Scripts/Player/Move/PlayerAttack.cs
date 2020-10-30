using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject stoneBulletEffect;
    public GameObject woodBulletEffect;

    ParticleSystem bulletParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))     //일단 확인용 눌렀을때만 적용   ->   나중에 바꿔야됨 
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            int layerMask = (1 << LayerMask.NameToLayer("Wall"));
            RaycastHit hit = new RaycastHit();


            Debug.Log("mouse click");
            if (Physics.Raycast(ray, out hit, layerMask))
            {
                Debug.Log("hit: " + hit.transform.name);
                if (hit.collider.tag == "Stone")
                {
                    stoneBulletEffect.SetActive(true);

                    bulletParticleSystem = stoneBulletEffect.GetComponent<ParticleSystem>();
                    Debug.Log("Stone hit");

                    stoneBulletEffect.transform.position = hit.point;
                    stoneBulletEffect.transform.forward = hit.normal;
                    bulletParticleSystem.Play();
                }

                if (hit.collider.tag == "Wood")
                {
                    woodBulletEffect.SetActive(true);

                    bulletParticleSystem = woodBulletEffect.GetComponent<ParticleSystem>();
                    Debug.Log("Wood hit");

                    woodBulletEffect.transform.position = hit.point;
                    woodBulletEffect.transform.forward = hit.normal;
                    bulletParticleSystem.Play();
                }
            }
        }
    }
}
