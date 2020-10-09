using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AdManager.instance.ShowBannerAd();
    }
}
