using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    public CameraMovement skriptReference;
    public Transform icon;

    float pomocnaZoom = 1;
    float realZoom = 1;
    public int zoomCount = 2;
    public float test;
    int pomocna = 2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //celé tohle dìlá jen to, aby obrázek byl poøád stejnì velký a na stejném místì
        //není to perfektní a kdyby šlo nìco jako dock tak by to bylo lepší
        test = (float)-3.5 * zoomCount - 1;
        realZoom = skriptReference.zoomNasobek;

        if (pomocnaZoom < realZoom && pomocna < 0)
        {
            icon.transform.localScale += new Vector3(0.19f, 0.19f, 0f);

            pomocnaZoom = skriptReference.zoomNasobek;
            zoomCount = zoomCount + 1;
        }
        else if (pomocnaZoom > realZoom && pomocna < 0)
        {
            icon.transform.localScale -= new Vector3(0.19f, 0.19f, 0f);

            pomocnaZoom = skriptReference.zoomNasobek;
            zoomCount = zoomCount - 1;
        }
        icon.transform.localPosition = new Vector3(icon.transform.localPosition.x, test, icon.transform.localPosition.z);
        pomocna--;
    }
}
