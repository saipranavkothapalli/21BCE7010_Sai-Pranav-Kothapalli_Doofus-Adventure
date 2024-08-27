using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Doofus_Controller : MonoBehaviour
{
    Camera_Controller cameraController;
    Quaternion targetRotation;
    [SerializeField] float Doofus_speed = 3f;
    [SerializeField] float RotationSpeed = 500f;
    public Text Score_UI;
    private int Score = 0;
    private void Awake()
    {
        cameraController = Camera.main.GetComponent<Camera_Controller>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float MoveAmount =Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        var move = (new Vector3(horizontal, 0, vertical)).normalized;
        var moveDir = cameraController.PlanarRotation * move;
        if (MoveAmount > 0)
        {
            transform.position += move * Doofus_speed * Time.deltaTime;
            targetRotation = Quaternion.LookRotation(moveDir);
        }
        transform.rotation= Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed*Time.deltaTime);
        if (gameObject.transform.position.y < -2)
        {
            StartCoroutine(PlayerDied());
        }
    }
    void OnCollisionEnter(Collision target)
    {
        print("Collision Detected");
        if (target.gameObject.tag == "Ground")
        {
            Score++;
            Score_UI.text = "Score: " + Score;
        }
    }
    IEnumerator PlayerDied()
    {
        yield return new WaitForSecondsRealtime(2f);
        Score_UI.text = "Game Over";
        SceneManager.LoadScene("SampleScene");
    }
}
