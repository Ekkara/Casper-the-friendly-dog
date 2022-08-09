using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    [SerializeField] float horisontalSpeed, 
        jumpForce, 
        fallSpeedgMultiplier, 
        shortJmpMultiplier;

    Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    Vector2 direction;
    [SerializeField] Vector2 jumpRayOffset;
    [SerializeField] float rayLength;
    bool canJump;
    // Update is called once per frame
    void Update() {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) {
            direction -= Vector2.right;
        }
        if (Input.GetKey(KeyCode.D)) {
            direction += Vector2.right;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            RB.velocity = new Vector2(RB.velocity.x, jumpForce);
            canJump = false;
        }
        //inproved falling
        if (RB.velocity.y < 0) {
            RB.velocity += new Vector2(0, Physics2D.gravity.y * fallSpeedgMultiplier * Time.deltaTime);
        } 
        else if(RB.velocity.y > 0) {
            if (!Input.GetKey(KeyCode.Space)) {
                RB.velocity += new Vector2(0, Physics2D.gravity.y * shortJmpMultiplier * Time.deltaTime);
            }
        }
        else {//falling is 0
         
        }
        // check if can jump
        RaycastHit2D leftHit, rightHit;
        rightHit = Physics2D.Raycast(transform.position + new Vector3(jumpRayOffset.x, jumpRayOffset.y), Vector3.down, rayLength);
        leftHit = Physics2D.Raycast(transform.position + new Vector3(-jumpRayOffset.x, jumpRayOffset.y), Vector3.down, rayLength);
        canJump = (rightHit.collider != null) || (leftHit.collider != null);
        Debug.Log(rightHit.normal);
    }

    private void FixedUpdate() {
        if (!direction.Equals(0)) {
            RB.AddForce(direction * horisontalSpeed);
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position + new Vector3(-jumpRayOffset.x, jumpRayOffset.y), transform.position + new Vector3(-jumpRayOffset.x, jumpRayOffset.y - rayLength));
        Gizmos.DrawLine(transform.position + new Vector3(jumpRayOffset.x, jumpRayOffset.y), transform.position + new Vector3(jumpRayOffset.x, jumpRayOffset.y - rayLength));

    }
}
