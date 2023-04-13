using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float rightBound; //change the bounds in the inspector or else schenanigans ensue
    [SerializeField] float leftBound;


    // Start is called before the first frame update
    private void Start()
    {
       flipEnemy();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time * speed, rightBound - leftBound)+rightBound, transform.position.y);
    }

    IEnumerator flipEnemy(){
        //yield return new WaitForSeconds(Time.time * speed / 2);
        yield return new WaitForSeconds(3);
        transform.Rotate(new Vector3(0,180,0)); //flips that bad boy 'round
        Debug.Log("flipped");
        flipEnemy();
    }
    
}
