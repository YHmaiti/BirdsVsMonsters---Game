using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{

    Vector3 initialPlace;
    private bool launched = false;
    private float timeWithNoMVT = 0;

    // using a serialize field here will make this variable accessible through 
    // unity and it will be modifiable through it directly without having to 
    // access the code and modify the value in the code itself.
    [SerializeField] private float _launchForce = 300;


    private void Awake() {
        initialPlace = transform.position;
    }

    private void Update() {

        GetComponent<LineRenderer>().SetPosition(1, initialPlace);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        Vector3 temp = transform.position;

        if(launched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.5) 
            timeWithNoMVT += Time.deltaTime;

        if(temp.y > 30 || temp.x > 30 || temp.x < -40 || temp.y < -20 || (launched && timeWithNoMVT > 3)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnMouseDown(){
        GetComponent<SpriteRenderer>().color = Color.red;

        // I am adding this as backup cuz otherwise it crashes after the first play and the 
        // lane for the trajectory doesn't work so it needs to be re-enabled :/ 
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp(){
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 reverseDir = initialPlace - transform.position;
        GetComponent<Rigidbody2D>().AddForce(reverseDir * _launchForce);
        launched = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
