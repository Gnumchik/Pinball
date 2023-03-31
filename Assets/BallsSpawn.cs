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
    private Vector3 startPosition;

    void Start()
    {
        text.text = "Money: " + chet.ToString();
        startPosition = transform.position;
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
        if (other.tag == "TrigerrZoneDed")
        {
            transform.position = startPosition;
            hp--;
            textHp.text = "Balls: " + hp.ToString();
        }
        if (other.gameObject.tag == "Bonuse")
        {
            Destroy(other.gameObject);
            chet += 1000;
            text.text = "Money: " + chet.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstcle")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;
            chet += 10;
            text.text = "Money: " + chet.ToString();
        }
        
        if (collision.gameObject.tag == "obstcleBig")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;
            chet += 100;
            text.text = "Money: " + chet.ToString();
        }
        if (collision.gameObject.tag == "obsteclBigBig")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;
            chet += 500;
            text.text = "Money: " + chet.ToString();
        }



    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "obstcle")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Minimum;
        }
        if (collision.gameObject.tag == "obstcleBig")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Minimum;
        }
        if (collision.gameObject.tag == "obsteclBigBig")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Minimum;
        }
    }

    
}



