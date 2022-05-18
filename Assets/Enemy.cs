using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _BoomPrefab;
  private void OnCollisionEnter2D(Collision2D collision) {
      if(collision.collider.GetComponent<Bird>() != null) {

            // I want  the explosiion to happen at the position of the enemy monster 
            // aso specify the position of that current enemy, yet this will also require 
            // specifying the type of movement of the prefab, so we set it to follow a Quaternion rotation
            Instantiate(_BoomPrefab, transform.position, Quaternion.identity);

            // then get that bastard destroyed
            Destroy(gameObject); 
            return;
      }
      if(collision.collider.GetComponent<Enemy>() != null) return;
      if(collision.contacts[0].normal.y < 0) 
      {
        Instantiate(_BoomPrefab, transform.position, Quaternion.identity);
          Destroy(gameObject); 
      }
  }
}
