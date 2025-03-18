package kr.co.theposm;

import android.app.Application;
import android.net.Uri;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Objects;

import okhttp3.Cookie;
import okhttp3.CookieJar;
import okhttp3.HttpUrl;
import okhttp3.OkHttpClient;

public class myGlobal extends Application {

    public static String uri_test = "http://211.42.156.219:8080/";
    public static String uri_real = "http://211.45.170.55:8080/";
    public static String mUri = "";

    public static String mSiteId = "";
    public static String mSiteName = "";

    public static String mShopCode = "";
    public static String mShopName = "";

    public static String mPosNo = "";

    public static String mBizDt = "";



    public static OkHttpClient okHttpClient = new OkHttpClient.Builder()
            .cookieJar(new CookieJar() {
                private final HashMap<HttpUrl, List<Cookie>> cookieStore = new HashMap<>();

                @Override
                public void saveFromResponse(HttpUrl url, List<Cookie> cookies) {

                    url = HttpUrl.parse(mUri);

                    cookieStore.put(url, cookies);
                }

                @Override
                public List<Cookie> loadForRequest(HttpUrl url) {
                    List<Cookie> cookies = cookieStore.get(HttpUrl.parse(mUri));
                    return cookies != null ? cookies : new ArrayList<Cookie>();
                }
            })
            .build();



}
