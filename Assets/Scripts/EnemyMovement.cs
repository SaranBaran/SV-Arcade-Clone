using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float targetVelocity = 10.0f;
    public int numberOfRays = 17;
    public float angle = 90;

    public float rayRange = 2;

    void Update()
    {

       var deltaPosition = Vector3.zero;
      for (int i = 0; i < numberOfRays; ++i)
        {
        var rotation = this.transform.rotation;
        var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
        var direction = rotation * rotationMod * Vector3.forward;

        var ray = new Ray(this.transform.position, direction);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, rayRange))
        {
            deltaPosition -= (1.0f / numberOfRays) * targetVelocity * direction; 
        }
        else
        {
            deltaPosition += (1.0f / numberOfRays) * targetVelocity * direction;

        }
        }

        this.transform.position += deltaPosition * Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < numberOfRays; ++i)
        {
            var rotation = this.transform.rotation;
            var rotationMod = Quaternion.AngleAxis((i/((float)numberOfRays-1))*angle*2-angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward;
            Gizmos.DrawRay(this.transform.position, direction);
        }
    }

}
