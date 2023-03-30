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

    void Start()
    {
        text.text = chet.ToString();
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
            transform.position = new Vector3(3.126f, -0.046f, -2.145f);
            hp--;
        }
        if (other.gameObject.tag == "Bonuse")
        {
            Destroy(other.gameObject);
            chet += 1000;
            text.text = chet.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstcle")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;
            chet += 10;
            text.text = chet.ToString();
        }
        
        if (collision.gameObject.tag == "obstcleBig")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;
            chet += 100;
            text.text = chet.ToString();
        }
        if (collision.gameObject.tag == "obsteclBigBig")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;
            chet += 500;
            text.text = chet.ToString();
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



