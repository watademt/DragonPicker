using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnergyShield : MonoBehaviour
{
    public TMP_Text scoreGT;
    public AudioSource audioSource;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TMP_Text>();
        scoreGT.text = "0";
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision coll)
    {
        GameObject Collided = coll.gameObject;
        if (Collided.tag == "DragonGoodEgg")
        {
            int score = int.Parse(scoreGT.text);
            score += 1;
            scoreGT.text = score.ToString();
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            Destroy(Collided);

        }
        else if(Collided.tag == "DragonBadEgg")
        {
            int score = int.Parse(scoreGT.text);
            score -= 1;
            scoreGT.text = score.ToString();
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            Destroy(Collided);
        }
    }


}
