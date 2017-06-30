using UnityEngine;

public class CamControllerImpl : CamController{
    private int transSpd;
    private Transform camTrans;

    public CamControllerImpl()
    {
        transSpd = 10;
    }

    public void translate(Direction dir)
    {
        if (camTrans ==null)
             camTrans = Camera.main.transform;

        switch (dir)
        {
            case Direction.UP:
                camTrans.Translate(Vector3.up * (Time.deltaTime * transSpd));
               //camTrans.Translate(Vector3.forward * (Time.deltaTime * transSpd));
                break;
            case Direction.DOWN:
                camTrans.Translate(Vector3.down * (Time.deltaTime * transSpd));
               // camTrans.Translate(Vector3.back * (Time.deltaTime * transSpd));
                break;
            case Direction.RIGHT:
                camTrans.Translate(Vector3.right * (Time.deltaTime * transSpd));
                break;
            case Direction.LEFT:
                camTrans.Translate(Vector3.left * (Time.deltaTime * transSpd));
                break;
            default:
                break;
        }
    }

}
