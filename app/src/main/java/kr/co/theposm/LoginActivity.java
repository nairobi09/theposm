package kr.co.theposm;


import static kr.co.theposm.myGlobal.okHttpClient;

import android.Manifest;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.os.Message;
import android.provider.Settings;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;


import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.text.SimpleDateFormat;
import java.util.Base64;
import java.util.Date;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.FormBody;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;


public class LoginActivity extends Activity {

    myGlobal mGlobal = (myGlobal) getApplication();

    Intent intentMain;

    EditText etID;
    EditText etPW;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        intentMain = new Intent(this, MainActivity.class);

        setContentView(R.layout.activity_login);

        findViewById(R.id.btn_login).setOnClickListener(mLoginListener);
        findViewById(R.id.btn_req_pos).setOnClickListener(mReqPosListener);

        etID = (EditText) findViewById(R.id.etID);
        etPW = (EditText) findViewById(R.id.etPassword);
    }


    Button.OnClickListener mLoginListener = new View.OnClickListener() {
        public void onClick(View v) {

            // 개발자 로그인
            if (etID.getText().toString().equals("1120") & etPW.getText().toString().equals("4089"))
            {
                final Dialog dialog = new Dialog(LoginActivity.this);
                dialog.setContentView(R.layout.dialog_login_dev);
                dialog.setCancelable(false);
                dialog.setTitle("개발자로그인");

                EditText etDevSiteID = (EditText) dialog.findViewById(R.id.etDevSiteId);
                EditText etDevPosNo = (EditText) dialog.findViewById(R.id.etDevPosNo);
                CheckBox cbDevTest = (CheckBox) dialog.findViewById(R.id.cbDevTest);


                //
                dialog.findViewById(R.id.btn_dev_login).setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {

                        if (cbDevTest.isChecked() == true)
                        {
                            mGlobal.mUri = mGlobal.uri_test;
                        }
                        else
                        {
                            mGlobal.mUri = mGlobal.uri_real;
                        }


                        MediaType JSON = MediaType.parse("application/json; charset=utf-8");

                        JSONObject jsonObject = new JSONObject();
                        try {
                            jsonObject.put("siteId", etDevSiteID.getText().toString());
                            jsonObject.put("posNo", etDevPosNo.getText().toString());
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }


                        RequestBody requestBody = RequestBody.create(JSON, jsonObject.toString());

                        Request request = new Request.Builder().url(mGlobal.mUri + "loginDev").post(requestBody).build();


                        Thread thread = new Thread(new Runnable() {

                            public void run()
                            {
                                try
                                {

                                    Response response = okHttpClient.newCall(request).execute();
                                    JSONObject json = new JSONObject(response.body().string());

                                    String rc = json.getString("resultCode");
                                    String resultMsg = json.getString("resultMsg");

                                    if (rc.equals("200"))
                                    {
                                        mGlobal.mSiteId = json.getString("siteId");
                                        mGlobal.mPosNo = json.getString("posNo");

                                        mGlobal.mSiteName = "";
                                        mGlobal.mShopCode = "";
                                        mGlobal.mShopName = "";


                                        //
                                        String stat = get_biz_date();

                                        if (stat.equals("A"))
                                        {
                                            //
                                            startActivity(intentMain);
                                            finish();
                                        }
                                        else
                                        {
                                            runOnUiThread(new Runnable() {
                                                @Override
                                                public void run()
                                                {
                                                    AlertDialog.Builder builder = new AlertDialog.Builder(LoginActivity.this);
                                                    builder.setMessage("영업중이 아닙니다. \r\n관리자의 엽업개시 후 로그인할 수 있습니다.")
                                                            .setTitle("영업개시전")
                                                            .setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                                                public void onClick(DialogInterface dialog, int id) {

                                                                }
                                                            });
                                                    AlertDialog alert = builder.create();
                                                    alert.show();
                                                }
                                            });
                                        }

                                    }
                                    else
                                    {
                                        runOnUiThread(new Runnable() {
                                            @Override
                                            public void run()
                                            {
                                                AlertDialog.Builder builder = new AlertDialog.Builder(LoginActivity.this);
                                                builder.setMessage(resultMsg)
                                                        .setTitle("오류")
                                                        .setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                                            public void onClick(DialogInterface dialog, int id) {

                                                            }
                                                        });
                                                AlertDialog alert = builder.create();
                                                alert.show();
                                            }
                                        });
                                    }
                                } catch (Exception e) {
                                    e.printStackTrace();
                                }
                            }
                        });
                        thread.start();

                    }
                });

                dialog.findViewById(R.id.btn_dev_close).setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        dialog.dismiss();
                    }
                });

                dialog.setCanceledOnTouchOutside(false);
                dialog.show();

            }
            else  // 일반로그인
            {
                JSONObject jsonObject = new JSONObject();

                String mMAC = Settings.Secure.getString(getApplicationContext().getContentResolver(), Settings.Secure.ANDROID_ID);

                MediaType JSON = MediaType.parse("application/json; charset=utf-8");

                try {

                    String pswd = etPW.getText().toString();

                    byte[] data = pswd.getBytes(StandardCharsets.US_ASCII);

                    MessageDigest sha = MessageDigest.getInstance("SHA-1");

                    byte[] result = sha.digest(data);
                    String pw2 = Base64.getEncoder().encodeToString(result);



                    jsonObject.put("userId", etID.getText().toString());
                    jsonObject.put("userPw", pw2);
                    jsonObject.put("macAddr", mMAC);
                }
                catch (Exception e) {
                    e.printStackTrace();
                }


                mGlobal.mUri = mGlobal.uri_test;
                //mGlobal.mUri = mGlobal.uri_real;    // 일반 로그인은 리얼서버로 고정.


                RequestBody requestBody = RequestBody.create(JSON, jsonObject.toString());

                Request request = new Request.Builder().url(mGlobal.mUri + "login").post(requestBody).build();


                Thread thread = new Thread(new Runnable() {

                    public void run()
                    {
                        try
                        {

                            Response response = okHttpClient.newCall(request).execute();
                            JSONObject json = new JSONObject(response.body().string());

                            String rc = json.getString("resultCode");
                            String resultMsg = json.getString("resultMsg");

                            if (rc.equals("200"))
                            {
                                mGlobal.mSiteId = json.getString("siteId");
                                mGlobal.mPosNo = json.getString("posNo");

                                mGlobal.mSiteName = "";
                                mGlobal.mShopCode = "";
                                mGlobal.mShopName = "";


                                //
                                String stat = get_biz_date();

                                if (stat.equals("A"))
                                {
                                    //
                                    startActivity(intentMain);
                                    finish();
                                }
                                else
                                {
                                    runOnUiThread(new Runnable() {
                                        @Override
                                        public void run()
                                        {
                                            AlertDialog.Builder builder = new AlertDialog.Builder(LoginActivity.this);
                                            builder.setMessage("영업중이 아닙니다. \r\n관리자의 엽업개시 후 로그인할 수 있습니다.")
                                                    .setTitle("영업개시전")
                                                    .setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                                        public void onClick(DialogInterface dialog, int id) {

                                                        }
                                                    });
                                            AlertDialog alert = builder.create();
                                            alert.show();
                                        }
                                    });
                                }



                            }
                            else
                            {
                                runOnUiThread(new Runnable() {
                                    @Override
                                    public void run()
                                    {
                                        AlertDialog.Builder builder = new AlertDialog.Builder(LoginActivity.this);
                                        builder.setMessage(resultMsg)
                                                .setTitle("오류")
                                                .setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                                    public void onClick(DialogInterface dialog, int id) {

                                                    }
                                                });
                                        AlertDialog alert = builder.create();
                                        alert.show();
                                    }
                                });
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });
                thread.start();



            }

        }
    };


    private String get_biz_date()
    {

        String biz_status = "";

        try
        {
            Request request = new Request.Builder().url(mGlobal.mUri + "bizDateLast?siteId=" + mGlobal.mSiteId).build();
            Response response = okHttpClient.newCall(request).execute();
            JSONObject json = new JSONObject(response.body().string());

            String rc = json.getString("resultCode");
            String resultMsg = json.getString("resultMsg");

            if (rc.equals("200")) {
                String cnt = json.getString("bizDateCnt");

                if (cnt == "0")
                {
                    mGlobal.mBizDt = "";
                    biz_status = "X";
                }
                else
                {
                    String data = json.getString("bizDate");

                    mGlobal.mBizDt = json.getJSONArray("bizDate").getJSONObject(0).getString("bizDt");
                    biz_status = json.getJSONArray("bizDate").getJSONObject(0).getString("bizStatus");
                }
            }
        }
        catch(Exception e)
        {
            biz_status = "X";
        }

        return biz_status;
    }



    Button.OnClickListener mReqPosListener = new View.OnClickListener() {
        public void onClick(View v) {

            final Dialog dialog = new Dialog(LoginActivity.this);
            dialog.setContentView(R.layout.dialog_req_pos);
            dialog.setCancelable(false);
            dialog.setTitle("기기등록");

            EditText etReqSiteID = (EditText) dialog.findViewById(R.id.etReqSiteId);
            EditText etReqPosNo = (EditText) dialog.findViewById(R.id.etReqPosNo);
            EditText etReqShopCode = (EditText) dialog.findViewById(R.id.etReqShopCode);

            dialog.findViewById(R.id.btn_req_pos).setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {


                    String mMAC = Settings.Secure.getString(getApplicationContext().getContentResolver(), Settings.Secure.ANDROID_ID);


                    // 구부방법 필요
                    //mGlobal.mUri = mGlobal.uri_real;
                    mGlobal.mUri = mGlobal.uri_test;


                    MediaType JSON = MediaType.parse("application/json; charset=utf-8");

                    JSONObject jsonObject = new JSONObject();
                    try {
                        jsonObject.put("siteId", etReqSiteID.getText().toString());
                        jsonObject.put("posNo", etReqPosNo.getText().toString());
                        jsonObject.put("macAddr", mMAC);
                        jsonObject.put("shopCode", etReqShopCode.getText().toString());
                        jsonObject.put("posStatus", "0");

                        SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddhhmmss");
                        String init_dt = sdf.format(new Date()).toString();

                        jsonObject.put("initDt", init_dt);



                    } catch (JSONException e) {
                        e.printStackTrace();
                    }


                    RequestBody requestBody = RequestBody.create(JSON, jsonObject.toString());

                    Request request = new Request.Builder().url(mGlobal.mUri + "pos").post(requestBody).build();


                    Thread thread = new Thread(new Runnable() {

                        public void run()
                        {
                            try
                            {

                                Response response = okHttpClient.newCall(request).execute();
                                JSONObject json = new JSONObject(response.body().string());

                                String rc = json.getString("resultCode");
                                String resultMsg = json.getString("resultMsg");

                                if (rc.equals("200"))
                                {
                                    mGlobal.mSiteId = json.getString("siteId");
                                    mGlobal.mPosNo = json.getString("posNo");
                                    //mGlobal.mShopCode = json.getString("shopCode");

                                    //
                                    runOnUiThread(new Runnable() {
                                        @Override
                                        public void run()
                                        {
                                            AlertDialog.Builder builder = new AlertDialog.Builder(LoginActivity.this);
                                            builder.setMessage("기기등록 완료.\r\n관리자의 인증후 사용가능합니다.")
                                                    .setTitle("성공")
                                                    .setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                                        public void onClick(DialogInterface dialog, int id) { dialog.dismiss(); }
                                                    });
                                            AlertDialog alert = builder.create();
                                            alert.show();
                                        }
                                    });
                                }
                                else
                                {
                                    runOnUiThread(new Runnable() {
                                        @Override
                                        public void run()
                                        {
                                            AlertDialog.Builder builder = new AlertDialog.Builder(LoginActivity.this);
                                            builder.setMessage(resultMsg)
                                                    .setTitle("오류")
                                                    .setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                                        public void onClick(DialogInterface dialog, int id) {

                                                        }
                                                    });
                                            AlertDialog alert = builder.create();
                                            alert.show();
                                        }
                                    });
                                }
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    });
                    thread.start();



                }
            });

            dialog.findViewById(R.id.btn_close).setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    dialog.dismiss();
                }
            });



            dialog.setCanceledOnTouchOutside(false);
            dialog.show();


        }
    };




    public void onBackPressed()
    {
        moveTaskToBack(true);
        finish();
        android.os.Process.killProcess(android.os.Process.myPid());
    }



}
