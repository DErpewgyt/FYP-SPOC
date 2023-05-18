using UnityEngine;

public class MoveTest : MonoBehaviour
{
    //public float speed = .25f;/

    public bool BlurCircle;
    public bool VerticalCircle;
    public bool HorizontalCircle;
    public bool CircleMovement;

    public ObjectClicker objectClicker;

    public GameObject ThreeCirclesIdealTransform;
    public GameObject parentObject;
    public GameObject BlurryCircle;
    public GameObject BoxVolumeBlurryCircle;
    public GameObject MiddleCircle;
    public GameObject LeftCircle;
    public GameObject TopCircle;

    public GameObject CircleGroupBlur;
    public GameObject BoxVolumeCircleGroupBlur;

    public float maxDistX = .2f;
    public float maxDistZ = .2f;
    public float maxDistY = .1f;

    public float maxValueLeft = .2f;
    public float minValueLeft = 0.075f;
    public float maxValueTop = .2f;
    public float minValueTop = 0.075f;
    public float maxDistZScroll = .1f;

    private static Vector3 startingPos;
    private static Vector3 BlurStartingPos;
    private static Vector3 BlurStartingPosCircles;

    public float speed = .05f;
    public float CirlcesSpeed = .02f;

    private void Start()
    {
        startingPos = ThreeCirclesIdealTransform.transform.position;
        BlurStartingPos = BlurryCircle.transform.position;
        BlurStartingPosCircles = CircleGroupBlur.transform.position;
        BoxVolumeCircleGroupBlur.SetActive(false);
    }

    private void Update()
    {
        if (!objectClicker.zoomedIn)
        {
            BoxVolumeCircleGroupBlur.SetActive(false);
        }
        if (CircleMovement)
        {
            BoxVolumeBlurryCircle.SetActive(false);
            BoxVolumeCircleGroupBlur.SetActive(true);
            Vector3 moveDir = new Vector3(0, 0, 0);

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

            if (Input.GetKey(KeyCode.S))
            {
                moveDir.y = -1f;
                print(moveDir.y);
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveDir.y = 1f;
                print(moveDir.y);
            }

            // Check if any of the movement keys are pressed
            if (moveDir != Vector3.zero)
            {
                Vector3 targetPosxyz = transform.position + (moveDir * CirlcesSpeed * Time.deltaTime);
                targetPosxyz = new Vector3(
                    Mathf.Clamp(targetPosxyz.x, startingPos.x - maxDistX, startingPos.x + maxDistX),
                    Mathf.Clamp(targetPosxyz.y, startingPos.y - maxDistY, startingPos.y + maxDistY),
                    Mathf.Clamp(targetPosxyz.z, startingPos.z - maxDistZ, startingPos.z + maxDistZ)
                );

                transform.position = targetPosxyz;
            }

            Vector3 moveDirectionZ = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.Q))
            {
                moveDirectionZ.z = -1f;
                print(moveDirectionZ.z);
            }

            if (Input.GetKey(KeyCode.E))
            {
                moveDirectionZ.z = 1f;
                print(moveDirectionZ.z);
            }

            if (moveDirectionZ != Vector3.zero)
            {
                Vector3 targetPosxyz = CircleGroupBlur.transform.position + moveDirectionZ * 1f * Time.deltaTime;
                targetPosxyz.z = Mathf.Clamp(targetPosxyz.z, BlurStartingPosCircles.z - maxDistZ, BlurStartingPosCircles.z + maxDistZ);
                CircleGroupBlur.transform.position = targetPosxyz;
            }
        }




        float xDirection = Input.GetAxisRaw("Mouse ScrollWheel");
        if (HorizontalCircle && Mathf.Abs(xDirection) > 0.05f)
        {
            BoxVolumeBlurryCircle.SetActive(false);
            BoxVolumeCircleGroupBlur.SetActive(true);
            Vector3 moveDirectionX = new Vector3(xDirection, 0.0f, 0.0f);
            Vector3 targetPosx = LeftCircle.transform.position + (moveDirectionX * speed);

            // Clamps max and min distances
            targetPosx.x = Mathf.Clamp(targetPosx.x, MiddleCircle.transform.position.x - maxValueLeft, MiddleCircle.transform.position.x - minValueLeft);
            LeftCircle.transform.position = targetPosx;
        }

        float yDirection = Input.GetAxisRaw("Mouse ScrollWheel");
        if (VerticalCircle && Mathf.Abs(yDirection) > 0.05f)
        {
            BoxVolumeBlurryCircle.SetActive(false);
            BoxVolumeCircleGroupBlur.SetActive(true);
            Vector3 moveDirectionY = new Vector3(0.0f, yDirection, 0.0f);
            Vector3 targetPosy = TopCircle.transform.position + (moveDirectionY * speed);

            // Clamps max and min distances
            targetPosy.y = Mathf.Clamp(targetPosy.y, MiddleCircle.transform.position.y + minValueTop, MiddleCircle.transform.position.y + maxValueTop);
            TopCircle.transform.position = targetPosy;
        }

        float zDirection = Input.GetAxis("Mouse ScrollWheel");
        if (BlurCircle)
        {
            BoxVolumeBlurryCircle.SetActive(true);
            BoxVolumeCircleGroupBlur.SetActive(false);
            MiddleCircle.SetActive(false);
            TopCircle.SetActive(false);
            LeftCircle.SetActive(false);

            if (Mathf.Abs(zDirection) > 0.05f)
            {
                Vector3 moveDirectionZ = new Vector3(0.0f, 0.0f, zDirection);
                Vector3 targetPosz = BlurryCircle.transform.position + (moveDirectionZ * speed);

                // Clamps max and min distances
                targetPosz.z = Mathf.Clamp(targetPosz.z, BlurStartingPos.z - maxDistZScroll, BlurStartingPos.z + maxDistZScroll);
                BlurryCircle.transform.position = targetPosz;
            }
        }
        else
        {
            BoxVolumeBlurryCircle.SetActive(false);
            MiddleCircle.SetActive(true);
            TopCircle.SetActive(true);
            LeftCircle.SetActive(true);
        }


    }
}