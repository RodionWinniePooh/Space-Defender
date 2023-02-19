using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ParalaxBackgroundMoving : MonoBehaviour
{
    public Transform mainCameraPosition;

    public float backgroundMoveSpeed;
    private float directionX;
    private float directionY;

    public float offsetByX = 13f;

    private void Update()
    {
        if (FindObjectOfType<CharacterMove>().isMobile==false)
            directionX = Input.GetAxis("Horizontal") * backgroundMoveSpeed * Time.deltaTime;
        else directionX = CrossPlatformInputManager.GetAxis("Horizontal") * backgroundMoveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + directionX,transform.position.y);

        if (transform.position.x - mainCameraPosition.position.x < -offsetByX)
            transform.position = new Vector2(mainCameraPosition.position.x + offsetByX, transform.position.y);

        else if (transform.position.x - mainCameraPosition.position.x > offsetByX)
            transform.position = new Vector2(mainCameraPosition.position.x - offsetByX, transform.position.y);
    }
}
