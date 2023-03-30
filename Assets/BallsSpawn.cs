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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TrigerrZoneDed")
        {
            transform.position = new Vector3(3.126f, -0.046f, -2.145f);
            hp--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstcle")
        {
            CapsuleCollider sphereCollider = collision.gameObject.GetComponent<CapsuleCollider>();
            sphereCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;
            chet++;
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

    }
}



