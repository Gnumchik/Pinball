using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallsSpawn : MonoBehaviour
{
    [SerializeField] private int chet = 0;
    [SerializeField] private int hp = 3;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI textHp;

    [SerializeField] private LayerMask trigerrZoneDed;
    [SerializeField] private LayerMask bonuse;
    [SerializeField] private LayerMask obstcle;


    private int _trigerrZoneDed;
    private int _bonuse;
    private int _obstcle;


    private Vector3 startPosition;

    void Start()
    {
        text.text = "Money: " + chet.ToString();
        startPosition = transform.position;

        _trigerrZoneDed = (int)Mathf.Log(trigerrZoneDed.value, 2);
        _bonuse = (int)Mathf.Log(bonuse.value, 2);
        _obstcle = (int)Mathf.Log(obstcle.value, 2);
    }

    void Update()
    {
        if(hp < 1)
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _trigerrZoneDed)
        {
            transform.position = startPosition;
            hp--;
            textHp.text = "Balls: " + hp.ToString();
        }
        if (other.gameObject.layer == _bonuse)
        {
            other.gameObject.SetActive(false);
            chet += 1000;
            text.text = "Money: " + chet.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _obstcle)
        {
            ObstleChetScore(collision);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == _obstcle)
        {
            Reset(collision);
        }
    }

    private void Reset(Collision collision)
    {
        //TryGetComponent
        CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
        sphereCollider.material.bounceCombine = PhysicMaterialCombine.Minimum;
    }

    private void ObstleChetScore(Collision collision)
    {
        CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
        sphereCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;
        chet += collision.gameObject.GetComponent<Obstacle>().GetChet();
        text.text = "Money: " + chet.ToString();
    }
}



