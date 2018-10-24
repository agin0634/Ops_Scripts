using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class AdmodManager : MonoBehaviour {
    
    private BannerView bannerView;

    public static AdmodManager ins;
    public bool bIsMainMenu = false;
    
    //[SerializeField] private string appID = "ca-app-pub-2870518963336798~7167379783";
    [SerializeField] private string bannerID = "ca-app-pub-2870518963336798/2754202498";

    void Awake()
    {
        if (ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (ins != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        this.RequestBanner();
        ShowBanner();
    }
    
    private void RequestBanner()
    {
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    public void ShowBanner()
    {
        if (this.bannerView != null)
        {
            this.bannerView.Show();
        }
    }

    public void HideBanner()
    {
        if (this.bannerView != null)
        {
            this.bannerView.Hide();
        }
    }

}
