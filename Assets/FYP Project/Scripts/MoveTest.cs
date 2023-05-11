using UnityEngine;

public class MoveTest : MonoBehaviour
{
    /*public float speed = .25f;*/

    public bool BlurCircle;
    public bool VerticalCircle;
    public bool HorizontalCircle;
    public bool CircleMovement;

    public GameObject ThreeCirclesIdealTransform;
    public GameObject parentObject;
    public GameObject BlurryCircle;
    public GameObject MiddleCircle;
    public GameObject LeftCircle;
    public GameObject TopCircle;

    public GameObject CircleGroupBlur;

    public float maxDistX = .2f;
    public float maxDistZ = .2f;
    public float maxDistY = .1f;

    public float maxValue = .2f;
    public float minValue = 0.075f;
    public float maxDistZScroll = .1f;
    // Define the starting position variable as a static variable
    private static Vector3 startingPos;
    private static Vector3 BlurStartingPos;
    private static Vector3 BlurStartingPosCircles;


    // Define the speed and maximum distance variables
    public float speed = .25f;

    private void Start()
    {
        startingPos = ThreeCirclesIdealTransform.transform.position;
        BlurStartingPos = BlurryCircle.transform.position;
        BlurStartingPosCircles = CircleGroupBlur.transform.position;
    }

    private void Update()
    {
        if (CircleMovement)
        {

            Vector3 moveDir = new Vector3(0, 0, 0);
            Vector3 moveDir2 = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.A))
            {
                moveDir.x = -1f;
                print(moveDir.x);
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveDir.x = 1f;
                print(moveDir.x);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                moveDir.y = -1f;
                print(moveDir.y);
            }

            if (Input.GetKey(KeyCode.E))
            {
                moveDir.y = 1f;
                print(moveDir.y);
            }

            /**
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 moveDirectionZ = new Vector3(0, 0, -1f);
                Vector3 targetPos = CircleGroupBlur.transform.position + moveDirectionZ * 0.001f;
                targetPos.z = Mathf.Clamp(targetPos.z, BlurStartingPosCircles.z - maxDistZ, BlurStartingPosCircles.z);
                CircleGroupBlur.transform.position = targetPos;
            }

            if (Input.GetKey(KeyCode.W))
            {
                Vector3 moveDirectionZ = new Vector3(0, 0, 1f);
                Vector3 targetPos = CircleGroupBlur.transform.position + moveDirectionZ * 0.001f;
                targetPos.z = Mathf.Clamp(targetPos.z, BlurStartingPosCircles.z, BlurStartingPosCircles.z + maxDistZ);
                CircleGroupBlur.transform.position = targetPos;
            }
            **/
            // Check if any of the movement keys are pressed
            if (moveDir != Vector3.zero)
            {
                Vector3 targetPos = transform.position + moveDir * speed * Time.deltaTime;
                targetPos = new Vector3(
                    Mathf.Clamp(targetPos.x, startingPos.x - maxDistX, startingPos.x + maxDistX),
                    Mathf.Clamp(targetPos.y, startingPos.y - maxDistY, startingPos.y + maxDistY),
                    Mathf.Clamp(targetPos.z, startingPos.z - maxDistZ, startingPos.z + maxDistZ)
                );

                transform.position = targetPos;
            }

            Vector3 moveDirectionZ = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.S))
            {
                moveDirectionZ.z = -1f;
                print(moveDirectionZ.z);
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveDirectionZ.z = 1f;
                print(moveDirectionZ.z);
            }

            // Check if the Z movement keys are pressed
            if (moveDirectionZ != Vector3.zero)
            {
                Vector3 targetPos = CircleGroupBlur.transform.position + moveDirectionZ * 1f * Time.deltaTime;
                targetPos.z = Mathf.Clamp(targetPos.z, BlurStartingPosCircles.z - maxDistZ, BlurStartingPosCircles.z + maxDistZ);
                CircleGroupBlur.transform.position = targetPos;
            }
        }

        /**
                 if (HorizontalCircle)
        {
            float xDirection = Input.GetAxisRaw("Mouse ScrollWheel");

            // Only move the circle if the scroll wheel input exceeds a threshold value
            if (Mathf.Abs(xDirection) > 0.05f)
            {
                Vector3 moveDirectionX = new Vector3(xDirection, 0.0f, 0.0f);

                LeftCircle.transform.position += moveDirectionX * speed;
            }
        }
        else if (VerticalCircle)
        {
            float yDirection = Input.GetAxisRaw("Mouse ScrollWheel");

            // Only move the circle if the scroll wheel input exceeds a threshold value
            if (Mathf.Abs(yDirection) > 0.05f)
            {
                Vector3 moveDirectionY = new Vector3(0.0f, yDirection, 0.0f);

                TopCircle.transform.position += moveDirectionY * speed;
            }
        }        else if (BlurCircle)
        {
            float zDirection = Input.GetAxis("Mouse ScrollWheel");

            Vector3 moveDirectionZ = new Vector3(0.0f, 0.0f, zDirection);

            BlurryCircle.transform.position += moveDirectionZ * speed;
        }
        **/



        float xDirection = Input.GetAxisRaw("Mouse ScrollWheel");
        if (HorizontalCircle && Mathf.Abs(xDirection) > 0.05f)
        {
            Vector3 moveDirectionX = new Vector3(xDirection, 0.0f, 0.0f);

            // Calculate the target position
            Vector3 targetPosx = LeftCircle.transform.position + moveDirectionX * speed;

            // Clamp the target position within the maximum distance
            targetPosx.x = Mathf.Clamp(targetPosx.x, MiddleCircle.transform.position.x - maxValue, MiddleCircle.transform.position.x - minValue);

            // Move the circle to the target position
            LeftCircle.transform.position = targetPosx;
        }

        float yDirection = Input.GetAxisRaw("Mouse ScrollWheel");
        if (VerticalCircle && Mathf.Abs(yDirection) > 0.05f)
        {
            Vector3 moveDirectionY = new Vector3(0.0f, yDirection, 0.0f);

            // Calculate the target position
            Vector3 targetPosy = TopCircle.transform.position + moveDirectionY * speed;

            // Clamp the target position within the maximum distance
            targetPosy.y = Mathf.Clamp(targetPosy.y, MiddleCircle.transform.position.y + minValue, MiddleCircle.transform.position.y + maxValue);

            // Move the circle to the target position
            TopCircle.transform.position = targetPosy;
        }

        float zDirection = Input.GetAxis("Mouse ScrollWheel");
        if (BlurCircle)
        {
            MiddleCircle.SetActive(false);
            TopCircle.SetActive(false);
            LeftCircle.SetActive(false);
            CircleGroupBlur.SetActive(false);

            if (Mathf.Abs(zDirection) > 0.05f)
            {
                Vector3 moveDirectionZ = new Vector3(0.0f, 0.0f, zDirection);

                // Calculate the target position
                Vector3 targetPosz = BlurryCircle.transform.position + moveDirectionZ * speed;

                // Clamp the target position within the maximum distance
                targetPosz.z = Mathf.Clamp(targetPosz.z, BlurStartingPos.z - maxDistZScroll, BlurStartingPos.z + maxDistZScroll);

                // Move the circle to the target position
                BlurryCircle.transform.position = targetPosz;
            }
        } else
        {
            MiddleCircle.SetActive(true);
            TopCircle.SetActive(true);
            LeftCircle.SetActive(true);
            CircleGroupBlur.SetActive(true);
        }


        /**
         if (HorizontalCircle)
        {
            float xDirection = Input.GetAxisRaw("Mouse ScrollWheel");

            // Only move the circle if the scroll wheel input exceeds a threshold value
            if (Mathf.Abs(xDirection) > 0.05f)
            {
                Vector3 moveDirectionX = new Vector3(xDirection, 0.0f, 0.0f);

                LeftCircle.transform.position += moveDirectionX * speed;
            }
        }
        else if (VerticalCircle)
        {
            float yDirection = Input.GetAxisRaw("Mouse ScrollWheel");

            // Only move the circle if the scroll wheel input exceeds a threshold value
            if (Mathf.Abs(yDirection) > 0.05f)
            {
                Vector3 moveDirectionY = new Vector3(0.0f, yDirection, 0.0f);

                TopCircle.transform.position += moveDirectionY * speed;
            }
        }        else if (BlurCircle)
        {
            float zDirection = Input.GetAxis("Mouse ScrollWheel");

            Vector3 moveDirectionZ = new Vector3(0.0f, 0.0f, zDirection);

            BlurryCircle.transform.position += moveDirectionZ * speed;
        }
        **/
    }
}