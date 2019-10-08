using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
   public float moveSpeed = 5f;
   public Rigidbody2D rb;
   public Animator animator;


   Vector2 Movement;
   Vector2 Idle;





   // Update is called once per frame
   void Update()
   {

      //Entrés

      Movement.x = Input.GetAxisRaw("Horizontal");
      Movement.y = Input.GetAxisRaw("Vertical");

      if (Movement != Vector2.zero)
         Idle = Movement;

      animator.SetFloat("Horizontal", Movement.x);
      animator.SetFloat("Vertical", Movement.y);
      animator.SetFloat("Speed", Movement.sqrMagnitude);


      animator.SetFloat("IdleH", Idle.x);
      animator.SetFloat("IdleV", Idle.y);




   }


   void FixedUpdate()
   {
      //Sorties
      rb.MovePosition(rb.position + Movement * moveSpeed * Time.fixedDeltaTime);

   }
}
