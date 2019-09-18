using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillTarget : MonoBehaviour
{

    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;
    public Transform camera;
    public Text scoreText;

    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        countDown = timeToSelect;
        hitEffect.enableEmission = false;
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            if(countDown > 0.0f)
            {
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                hitEffect.enableEmission = true;
            } else
            {
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                scoreText.text = "Score: " + score;
                countDown = timeToSelect;
                SetRandomPosition();
            }
        } else
        {
            countDown = timeToSelect;
            hitEffect.enableEmission = false;
        }
    }

    private void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
    }
}
