using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MathExample : MonoBehaviour
{
    /*private float current;
    private float max = 10;
    private float speed = 2f;*/

    void Start()
    {
        // Mathf свойства
        /*Debug.Log("PI " + Mathf.PI);
        Debug.Log("Epsilon " + Mathf.Epsilon);
        Debug.Log("Rad2Deg " + Mathf.Rad2Deg * 1);
        Debug.Log("Deg2Rad " + Mathf.Deg2Rad * 30);
        Debug.Log("Infinity " + Mathf.Infinity);
        Debug.Log("NegativeInfinity " + Mathf.NegativeInfinity);*/
        
        // Mathf методы
        /*Debug.Log("Approximately " + Mathf.Approximately(2.0f, 8.0f/4.0f));
        Debug.Log("Round 1.2 " + Mathf.Round(1.2f) + " Round 1.8 " + Mathf.Round(1.8f));
        Debug.Log("Floor 1.9 " + Mathf.Floor(1.9f));
        Debug.Log("Ceil 1.1 " + Mathf.Ceil(1.1f));*/
        
        /*Debug.Log("Max " + Mathf.Max(4, -5, 3, 11, 19, 7));
        Debug.Log("Sign+ " + Mathf.Sign(1.4f));
        Debug.Log("Sign- " + Mathf.Sign(-7.4f));*/
        
        /*Debug.Log("Abs " + Mathf.Abs(-5));
        Debug.Log("Sqrt " + Mathf.Sqrt(121));
        Debug.Log("Pow " + Mathf.Pow(2, 5));
        Debug.Log("Pow2 " + Mathf.NextPowerOfTwo(27));*/
        
        // Вектора операции
        //v1v2 = v1 + v2;
        
        /*Debug.Log("Lenght " + Vector3.Magnitude(v1));
        Debug.Log("LenghtSqr " + Vector3.SqrMagnitude(v1));*/
        
        /*Debug.Log("Dot " + Vector3.Dot(v1, v2));
        Debug.Log("Angle " + Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(v1, v2) * Mathf.Deg2Rad));*/

        //v1v2 = Vector3.Cross(v1, v2);
        
        // Quaternion
        Debug.Log("Rotation Quaternion " + transform.rotation);
        Debug.Log("Rotation " + transform.rotation.eulerAngles);

        transform.rotation = Quaternion.Euler(0, 0, 90);
    }
    
    private Vector3 v1 = new Vector3(1, 7, -1);
    private Vector3 v2 = new Vector3(5, 2, 1);
    private Vector3 v1v2 = Vector3.zero;

    void Update()
    {
        Debug.DrawLine(Vector3.zero, v1, Color.blue);
        Debug.DrawLine(Vector3.zero, v2, Color.red);
        Debug.DrawLine(Vector3.zero, v1v2, Color.yellow);
        
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            float rnd = Random.Range(4.0f, 10.0f);
            Debug.Log("rnd " + rnd + " clamp " + Mathf.Clamp(rnd, 6.0f, 8.0f));
        }
        
        current = Mathf.MoveTowards(current, max, speed * Time.deltaTime);
        Debug.Log("Current " + current);*/
    }
}
