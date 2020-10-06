using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [Header("The rotation speed")]
    [Range(5,100)]
    public float Rotation_Speed;
    [Header("The smaller the value, the more Friction there is")]
    public float Rotation_Friction; //The smaller the value, the more Friction there is. [Keep this at 1 unless you know what you are doing].
    [Header("adjusting this before anything else")]
    public float Rotation_Smoothness;

    private float Resulting_Value_from_Input;
    private Quaternion Quaternion_Rotate_From;
    private Quaternion Quaternion_Rotate_To;
     
    [Header("Required")]
    public Transform starCannon;

    private void Awake()
    {
        if(starCannon == null)
        {
            Debug.LogWarning("StarCannon reference missing from aim controller");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //if we are moving
        if (Input.GetAxis("Horizontal") !=0)
        {
            Resulting_Value_from_Input += -1f * Input.GetAxis("Horizontal") * Rotation_Speed * Rotation_Friction ;
            Quaternion_Rotate_From = starCannon.transform.rotation;
            Quaternion_Rotate_To = Quaternion.Euler(0, 0, Resulting_Value_from_Input);

            starCannon.transform.rotation = Quaternion.Lerp(Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * Rotation_Smoothness);
        }

    }

    public void IncreaseSpeed(float _ammount)
    {
        Rotation_Speed = _ammount;
    }

    public void UpgradeTracks() {
        Debug.Log("tracks");
    }
}