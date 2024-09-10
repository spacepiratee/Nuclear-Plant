using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Parasite : MonoBehaviour
{
   [Header("Stats")]
   [SerializeField] private float moveSpeed;
   
   [Header("A*")]
   private AIPath _aiPath;
   private AIDestinationSetter _destinationSetter;
   
   [Header("Waypoints")]
   [SerializeField] private Transform[] waypoints;
   [SerializeField] private Transform currentWaypoints;
   [SerializeField] private int currentWaypointIndex;
   [SerializeField] private bool canSetNewWayPoints;
   
   [Header("Components")]
   private Animator _animator;
   private Rigidbody _rb;
   
   
   [SerializeField] private Vector3 offset;
   [SerializeField] private float size;
   [SerializeField] private LayerMask playerLayer;
   [SerializeField] private bool detected;

   private void Start()
   {
      _animator = GetComponent<Animator>();
      _aiPath = GetComponent<AIPath>();
      _destinationSetter = GetComponent<AIDestinationSetter>();
   }

   private void OnBecameVisible()
   {
      Debug.Log("see ");
   }

   private void OnBecameInvisible()
   {
      Debug.Log("unseen");
   }

   private void FixedUpdate()
   {
      detected = Physics.CheckSphere(transform.position + offset, size, playerLayer.value);
      
      
      
      
      if (detected)
      {
         Chase();
      }
      else
      {
         BackOnTrack();
      }
   }

   void Chase()
   {
      _animator.Play("Zombie Run");
      _aiPath.canMove = true;
      _destinationSetter.target = PlayerInventory.Instance.transform;
   }

   void Idle()
   {
      _animator.Play("Zombie Idle");
      _aiPath.canMove = false;
   }

   void BackOnTrack()
   {
      _animator.Play("Zombie Run");
      _aiPath.canMove = true;

      _destinationSetter.target = currentWaypoints;
   }


   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.name == "Current")
      {
         SetWaypoints();
      }
   }

   void SetWaypoints()
   {
      // if (!canSetNewWayPoints)
      // {
      //    return;
      // }
      if (currentWaypointIndex + 1 < waypoints.Length)
      {
         currentWaypointIndex += 1;
      }
      else
      {
         currentWaypointIndex = 0;
      }

      currentWaypoints.position = waypoints[currentWaypointIndex].position;
   }
   
   
   
   
   
   
   private void OnDrawGizmos()
   {
      Gizmos.DrawWireSphere(transform.position + offset, size);
      Gizmos.color = Color.red;
      ;
   }
}
