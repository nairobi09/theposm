package kr.co.theposm;

import static kr.co.theposm.myGlobal.okHttpClient;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.graphics.Color;
import android.graphics.Paint;
import android.os.Bundle;
import android.provider.Settings;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.Base64;

import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;

import android.util.Log;
import com.google.firebase.messaging.FirebaseMessaging;



public class MainActivity extends Activity {

    myGlobal mGlobal = (myGlobal) getApplication();

    ListView mListViewShop;
    ArrayList<orderShop> mListOrderShop;
    ListViewAdapterShop mAdapterShop;

    ListView mListViewItem;
    ArrayList<orderItem> mListOrderItem;
    ListViewAdapterItem mAdapterItem;

    int mSelectedPosition = -1;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);

        //
        init_thepos_site();
        init_thepos_pos();      //init_thepos_shop(); 내부에 있음


        //
        mListOrderShop = new ArrayList<orderShop>();
        mListViewShop = (ListView) findViewById(R.id.lvOrderShop);
        mAdapterShop = new ListViewAdapterShop(this, R.layout.order_shop_view, mListOrderShop);
        mAdapterShop.notifyDataSetChanged();
        mListViewShop.setAdapter(mAdapterShop);
        mListViewShop.invalidateViews();
        mListViewShop.setOnItemClickListener(mListShopClickListener);

        //
        mListOrderItem = new ArrayList<orderItem>();
        mListViewItem = (ListView) findViewById(R.id.lvOrderItem);
        mAdapterItem = new ListViewAdapterItem(this, R.layout.order_item_view, mListOrderItem);
        mAdapterItem.notifyDataSetChanged();
        mListViewItem.setAdapter(mAdapterItem);
        mListViewItem.invalidateViews();

        //
        findViewById(R.id.btn_get).setOnClickListener(mGetListener);

        findViewById(R.id.btn_allim).setOnClickListener(mAllimListener);

        findViewById(R.id.btn_finish).setOnClickListener(mFinishListener);


        //
        //load_order_data();

        // Firebase 서비스에서 FCM 토큰 가져오기

        FirebaseTokenManager ftm = new FirebaseTokenManager();
        ftm.getFirebaseToken();

    }



    public class FirebaseTokenManager {
        public void getFirebaseToken() {
            FirebaseMessaging.getInstance().getToken()
                    .addOnCompleteListener(task -> {
                        if (!task.isSuccessful()) {
                            //Log.w("FCM", "FCM 토큰 가져오기 실패", task.getException());
                            return;
                        }

                        // 토큰 가져오기 성공
                        String token = task.getResult();
                        //Log.d("FCM", "FCM Token: " + token);

                        // Spring Boot 서버에 토큰 전송
                        sendTokenToServer(token);
                    });
        }

        private void sendTokenToServer(String token) {
            // Retrofit 또는 OkHttp를 사용하여 서버에 전송

            Thread thread = new Thread(new Runnable() {
                public void run() {
                    try {

                        MediaType JSON = MediaType.parse("application/json; charset=utf-8");
                        JSONObject jsonObject = new JSONObject();
                        jsonObject.put("siteId", mGlobal.mSiteId);
                        jsonObject.put("posNo", mGlobal.mPosNo);
                        jsonObject.put("pushToken", token);

                        RequestBody requestBody = RequestBody.create(JSON, jsonObject.toString());
                        Request request = new Request.Builder().url(mGlobal.mUri + "pos").patch(requestBody).build();
                        Response response = okHttpClient.newCall(request).execute();

                        JSONObject json = new JSONObject(response.body().string());
                        String rc = json.getString("resultCode");
                        String resultMsg = json.getString("resultMsg");

                        if (rc.equals("200"))
                        {

                        }
                        else
                        {
                            runOnUiThread(new Runnable() {
                                @Override
                                public void run()
                                {
                                    AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                    builder.setMessage("알림톡 메시지를 받을 수 없습니다. \r\n" + resultMsg).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) { }
                                    });
                                    AlertDialog alert = builder.create();
                                    alert.show();
                                }
                            });
                        }
                    }
                    catch(Exception e)
                    {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run()
                            {
                                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                builder.setMessage(e.getMessage()).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int id) { }
                                });
                                AlertDialog alert = builder.create();
                                alert.show();
                            }
                        });
                    }
                }
            });
            thread.start();

        }
    }



    public BroadcastReceiver myReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            String action = intent.getStringExtra("action");

            // UI 수정
            load_order_shop_data();
        }
    };

    @Override
    protected void onResume() {
        super.onResume();
        registerReceiver(myReceiver, new IntentFilter("INTENT_ORDER_SHOP"), Context.RECEIVER_EXPORTED);
    }

    @Override
    protected void onPause() {
        super.onPause();
        unregisterReceiver(myReceiver);
    }


    ListView.OnItemClickListener mListShopClickListener = new AdapterView.OnItemClickListener() {

        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

            mListOrderItem.clear();
            mListViewItem.invalidateViews();

            mSelectedPosition = position;


            // 알림버튼상테 세트
            String selected_allim_type = ((ImageView) view.findViewById(R.id.allim_type)).getTag().toString();
            // 완료버튼상테 세트
            String selected_flow_step = ((ImageView) view.findViewById(R.id.flow_step)).getTag().toString();
            //
            String selected_is_cancel = ((TextView) view.findViewById(R.id.is_cancel)).getTag().toString();


            // 알림전송버튼
            if (selected_allim_type.equals("AT"))
            {
                if (selected_flow_step.equals("0") | selected_flow_step.equals("1"))  // 접수, 발송
                {
                    if (selected_is_cancel.equals("Y"))  // 취소
                    {
                        ((Button)findViewById(R.id.btn_allim)).setEnabled(false);
                    }
                    else
                    {
                        ((Button)findViewById(R.id.btn_allim)).setEnabled(true);
                    }
                }
                else if (selected_flow_step.equals("2"))  // 완료
                {
                    ((Button)findViewById(R.id.btn_allim)).setEnabled(false);
                }
            }
            else
            {
                ((Button)findViewById(R.id.btn_allim)).setEnabled(false);
            }


            // 완료버튼
            if (selected_flow_step.equals("0") | selected_flow_step.equals("1"))  // 접수, 발송
            {
                ((Button)findViewById(R.id.btn_finish)).setEnabled(true);
            }
            else if (selected_flow_step.equals("2"))  // 완료
            {
                ((Button)findViewById(R.id.btn_finish)).setEnabled(false);
            }



            //
            Thread thread = new Thread(new Runnable() {
                public void run()
                {
                    try
                    {
                        String order_no = ((TextView)view.findViewById(R.id.order_no)).getText().toString();


                        Request request1 = new Request.Builder().url(mGlobal.mUri + "orderItem?siteId=" + mGlobal.mSiteId + "&bizDt=" + mGlobal.mBizDt + "&shopCode=" + mGlobal.mShopCode + "&shopOrderNo=" + order_no + "&tranType=A" + "&allim=Y").get().build();
                        Response response1 = okHttpClient.newCall(request1).execute();

                        JSONObject json1 = new JSONObject(response1.body().string());
                        String rc1 = json1.getString("resultCode");
                        String resultMsg1 = json1.getString("resultMsg");

                        if (rc1.equals("200"))
                        {
                            JSONArray arr1 = json1.getJSONArray("orderItems");

                            for (int i = 0; i < arr1.length(); i++)
                            {
                                String item_name = arr1.getJSONObject(i).getString("goodsName");
                                String item_value = arr1.getJSONObject(i).getString("cnt");
                                String option_no = arr1.getJSONObject(i).getString("optionNo");

                                mListOrderItem.add(new orderItem("Goods", item_name, item_value));


                                if (option_no.equals(""))
                                {
                                    continue;
                                }

                                // 옵션아이템
                                //
                                Request request2 = new Request.Builder().url(mGlobal.mUri + "orderOptionItem?siteId=" + mGlobal.mSiteId + "&bizDt=" + mGlobal.mBizDt + "&optionNo=" + option_no).get().build();
                                Response response2 = okHttpClient.newCall(request2).execute();

                                JSONObject json2 = new JSONObject(response2.body().string());
                                String rc2 = json2.getString("resultCode");
                                String resultMsg2 = json2.getString("resultMsg");

                                if (rc2.equals("200"))
                                {
                                    JSONArray arr2 = json2.getJSONArray("orderOptionItems");

                                    for (int k = 0; k < arr2.length(); k++)
                                    {
                                        item_name = arr2.getJSONObject(k).getString("optionName");
                                        item_value = arr2.getJSONObject(k).getString("optionItemName");

                                        mListOrderItem.add(new orderItem("Option", item_name, item_value));
                                    }
                                }
                                else
                                {
                                    runOnUiThread(new Runnable() {
                                        @Override
                                        public void run()
                                        {
                                            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                            builder.setMessage(resultMsg2).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                                public void onClick(DialogInterface dialog, int id) { }
                                            });
                                            AlertDialog alert = builder.create();
                                            alert.show();
                                        }
                                    });
                                }
                            }

                            runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    mListViewItem.invalidateViews();
                                }
                            });




                        }
                        else
                        {
                            runOnUiThread(new Runnable() {
                                @Override
                                public void run()
                                {
                                    AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                    builder.setMessage(resultMsg1).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) { }
                                    });
                                    AlertDialog alert = builder.create();
                                    alert.show();
                                }
                            });
                        }


                    }
                    catch (Exception ex) {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run()
                            {
                                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                builder.setMessage(ex.getMessage().toString()).setTitle("시스템오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int id) { }
                                });
                                AlertDialog alert = builder.create();
                                alert.show();
                            }
                        });
                    }

                }
            });
            thread.start();

        }
    };

    Button.OnClickListener mGetListener = new View.OnClickListener() {
        public void onClick(View v) {
            load_order_shop_data();
        }
    };

    private void load_order_shop_data()
    {
        //
        mListOrderShop.clear();
        mListViewShop.invalidateViews();

        mListOrderItem.clear();
        mListViewItem.invalidateViews();


        ((Button)findViewById(R.id.btn_allim)).setEnabled(false);
        ((Button)findViewById(R.id.btn_finish)).setEnabled(false);

        //
        Thread thread = new Thread(new Runnable() {
            public void run()
            {
                try
                {
                    Request request = new Request.Builder().url(mGlobal.mUri + "orderShop?siteId=" + mGlobal.mSiteId + "&bizDt=" + mGlobal.mBizDt + "&shopCode=" + mGlobal.mShopCode + "&allim=Y").get().build();
                    Response response = okHttpClient.newCall(request).execute();

                    JSONObject json = new JSONObject(response.body().string());
                    String rc = json.getString("resultCode");
                    String resultMsg = json.getString("resultMsg");

                    if (rc.equals("200"))
                    {
                        JSONArray arr = json.getJSONArray("orderShops");

                        for (int i = 0; i < arr.length(); i++)
                        {
                            String orderAllimStatus = arr.getJSONObject(i).getString("orderAllimStatus");
                            String time = arr.getJSONObject(i).getString("orderTime");
                            String shopOrderNo = arr.getJSONObject(i).getString("shopOrderNo");
                            String cnt = arr.getJSONObject(i).getString("cnt");
                            String orderAllimMemo = arr.getJSONObject(i).getString("orderAllimMemo");
                            String orderAllimType = arr.getJSONObject(i).getString("orderAllimType");
                            String isCancel = arr.getJSONObject(i).getString("isCancel");

                            String theNo = arr.getJSONObject(i).getString("theNo");



                            String orderTime = time;

                            if (time.length() == 6)
                            {
                                orderTime = time.substring(0,2) + ":" + time.substring(2,4) + ":" +time.substring(4,6);
                            }

                            mListOrderShop.add(new orderShop(orderAllimStatus, shopOrderNo, orderTime, cnt, orderAllimMemo, orderAllimType, isCancel, theNo));

                            runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    mListViewShop.invalidateViews();
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
                                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                builder.setMessage(resultMsg).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int id) { }
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


    Button.OnClickListener mAllimListener = new View.OnClickListener() {
        public void onClick(View v) {

            //
            Thread thread = new Thread(new Runnable() {
                public void run()
                {
                    try
                    {
                        String t_the_no = mListOrderShop.get(mSelectedPosition).the_no;

                        Request request = new Request.Builder().url(mGlobal.mUri + "allim?siteId=" + mGlobal.mSiteId + "&bizDt=" + mGlobal.mBizDt + "&theNo=" + t_the_no + "&shopCode=" + mGlobal.mShopCode).get().build();
                        Response response = okHttpClient.newCall(request).execute();

                        JSONObject json = new JSONObject(response.body().string());
                        String rc = json.getString("resultCode");
                        String resultMsg = json.getString("resultMsg");

                        if (rc.equals("200")) {
                            JSONArray arr = json.getJSONArray("allims");

                            if (arr.length() > 0)
                            {
                                String biz_dt = arr.getJSONObject(0).getString("bizDt");
                                String the_no = arr.getJSONObject(0).getString("theNo");
                                String sender_profile = arr.getJSONObject(0).getString("senderProfile");

                                String allim_tel_no = arr.getJSONObject(0).getString("allimTelNo");

                                String site_name = arr.getJSONObject(0).getString("siteName");
                                String order_date = arr.getJSONObject(0).getString("orderDate");
                                String order_time = arr.getJSONObject(0).getString("orderTime");
                                String order_no = arr.getJSONObject(0).getString("orderNo");
                                String order_detail = " " + arr.getJSONObject(0).getString("orderDetail");

                                MediaType JSON = MediaType.parse("application/json; charset=utf-8");

                                JSONObject jsonObject = new JSONObject();

                                jsonObject.put("siteId", mGlobal.mSiteId);
                                jsonObject.put("bizDt", biz_dt);
                                jsonObject.put("posNo", mGlobal.mPosNo);
                                jsonObject.put("shopCode", mGlobal.mShopCode);

                                jsonObject.put("theNo", the_no);
                                jsonObject.put("senderProfile", sender_profile);

                                jsonObject.put("allimType", "CP");
                                jsonObject.put("allimTelNo", allim_tel_no);
                                jsonObject.put("siteName", site_name);
                                jsonObject.put("orderDate", order_date);
                                jsonObject.put("orderTime", order_time);
                                jsonObject.put("orderNo", order_no);
                                jsonObject.put("orderDetail", order_detail);

                                RequestBody requestBody = RequestBody.create(JSON, jsonObject.toString());

                                Request request2 = new Request.Builder().url(mGlobal.mUri + "allim").post(requestBody).build();

                                Response response2 = okHttpClient.newCall(request2).execute();
                                JSONObject json2 = new JSONObject(response2.body().string());

                                String rc2 = json2.getString("resultCode");
                                String resultMsg2 = json2.getString("resultMsg");

                                if (rc2.equals("200")) {
                                    // orderShop 테이블 상태변경요청
                                    JSONObject jsonObject3 = new JSONObject();
                                    jsonObject3.put("siteId", mGlobal.mSiteId);
                                    jsonObject3.put("bizDt", mGlobal.mBizDt);
                                    jsonObject3.put("theNo", the_no);
                                    jsonObject3.put("shopOrderNo", order_no);
                                    jsonObject3.put("orderAllimStatus", "1");

                                    RequestBody requestBody3 = RequestBody.create(JSON, jsonObject3.toString());
                                    Request request3 = new Request.Builder().url(mGlobal.mUri + "orderShop").patch(requestBody3).build();
                                    Response response3 = okHttpClient.newCall(request3).execute();

                                    JSONObject json3 = new JSONObject(response3.body().string());
                                    String rc3 = json3.getString("resultCode");
                                    String resultMsg3 = json.getString("resultMsg");

                                    if (rc3.equals("200")) {
                                        // listview 갱신
                                        orderShop os = mListOrderShop.get(mSelectedPosition);
                                        os.flow_step = "1";
                                        mListOrderShop.set(mSelectedPosition, os);
                                    }

                                    // status 0 -> 1,2
                                    runOnUiThread(new Runnable() {
                                        @Override
                                        public void run() {
                                            //
                                            mListViewShop.invalidateViews();
                                        }
                                    });
                                }
                                else
                                {
                                    runOnUiThread(new Runnable() {
                                        @Override
                                        public void run()
                                        {
                                            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                            builder.setMessage(resultMsg2).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                                public void onClick(DialogInterface dialog, int id) { }
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
                                        AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                        builder.setMessage("해당 주문건을 찾을수 없는 오류입니다.").setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialog, int id) { }
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
                                    AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                    builder.setMessage(resultMsg).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) { }
                                    });
                                    AlertDialog alert = builder.create();
                                    alert.show();
                                }
                            });
                        }
                    }
                    catch (Exception e)
                    {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run()
                            {
                                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                builder.setMessage(e.getMessage()).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int id) { }
                                });
                                AlertDialog alert = builder.create();
                                alert.show();
                            }
                        });
                    }
                }
            });



            //
            String t_flow_step = mListOrderShop.get(mSelectedPosition).flow_step;
            String t_order_no = mListOrderShop.get(mSelectedPosition).order_no;


            if (t_flow_step.equals("0"))
            {
                //
                thread.start();
            }
            else if (t_flow_step.equals("1") | t_flow_step.equals("2"))
            {
                AlertDialog.Builder myAlertBuilder = new AlertDialog.Builder(MainActivity.this);
                myAlertBuilder.setTitle("알림발송");
                myAlertBuilder.setMessage("주문번호: " + t_order_no + " 알림발송하시겠습니까?");
                myAlertBuilder.setPositiveButton("발송",new DialogInterface.OnClickListener(){
                    public void onClick(DialogInterface dialog,int which){
                        // OK 버튼을 눌렸을 경우
                        thread.start();
                    }
                });
                myAlertBuilder.setNegativeButton("취소", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // Cancle 버튼을 눌렸을 경우
                    }
                });
                myAlertBuilder.show();
            }

        }
    };


    Button.OnClickListener mFinishListener = new View.OnClickListener() {
        public void onClick(View v) {
            //
            Thread thread = new Thread(new Runnable() {
                public void run()
                {
                    try {
                        String the_no = mListOrderShop.get(mSelectedPosition).the_no;
                        String order_no = mListOrderShop.get(mSelectedPosition).order_no;


                        // orderShop 테이블 상태변경요청
                        JSONObject jsonObject = new JSONObject();
                        jsonObject.put("siteId", mGlobal.mSiteId);
                        jsonObject.put("bizDt", mGlobal.mBizDt);
                        jsonObject.put("theNo", the_no);
                        jsonObject.put("shopOrderNo", order_no);
                        jsonObject.put("orderAllimStatus", "2");   // 완료

                        MediaType JSON = MediaType.parse("application/json; charset=utf-8");
                        RequestBody requestBody = RequestBody.create(JSON, jsonObject.toString());
                        Request request = new Request.Builder().url(mGlobal.mUri + "orderShop").patch(requestBody).build();
                        Response response = okHttpClient.newCall(request).execute();

                        JSONObject json = new JSONObject(response.body().string());
                        String rc = json.getString("resultCode");
                        String resultMsg = json.getString("resultMsg");

                        if (rc.equals("200")) {
                            // listview 갱신은 어떻게..
                            orderShop os = mListOrderShop.get(mSelectedPosition);
                            os.flow_step = "2";
                            mListOrderShop.set(mSelectedPosition, os);
                        }

                        // status 0 -> 1,2
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                //
                                mListViewShop.invalidateViews();
                            }
                        });

                    }
                    catch (Exception e)
                    {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run()
                            {
                                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                builder.setMessage(e.getMessage()).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int id) { }
                                });
                                AlertDialog alert = builder.create();
                                alert.show();
                            }
                        });
                    }
                }
            });

            //
            String t_flow_step = mListOrderShop.get(mSelectedPosition).flow_step;
            String t_order_no = mListOrderShop.get(mSelectedPosition).order_no;


            if (t_flow_step.equals("1"))
            {
                thread.start();
            }
            else if (t_flow_step.equals("0") | t_flow_step.equals("2"))
            {
                AlertDialog.Builder myAlertBuilder = new AlertDialog.Builder(MainActivity.this);
                myAlertBuilder.setTitle("완료");
                myAlertBuilder.setMessage("주문번호: " + t_order_no + " 완료처리하시겠습니까?");
                myAlertBuilder.setPositiveButton("완료",new DialogInterface.OnClickListener(){
                    public void onClick(DialogInterface dialog,int which){
                        // OK
                        thread.start();
                    }
                });
                myAlertBuilder.setNegativeButton("취소", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        //
                    }
                });
                myAlertBuilder.show();
            }

        }
    };


    //
    private void init_thepos_site()
    {
        Thread thread = new Thread(new Runnable() {
            public void run()
            {
                try
                {
                    Request request = new Request.Builder().url(mGlobal.mUri + "site?siteId=" + mGlobal.mSiteId).get().build();
                    Response response = okHttpClient.newCall(request).execute();

                    JSONObject json = new JSONObject(response.body().string());
                    String rc = json.getString("resultCode");
                    String resultMsg = json.getString("resultMsg");

                    if (rc.equals("200"))
                    {
                        mGlobal.mSiteName = json.getJSONArray("sites").getJSONObject(0).getString("siteAlias");

                        runOnUiThread(new Runnable() {
                            @Override
                            public void run()
                            {
                                TextView tv = (TextView) findViewById(R.id.tvTitle);
                                tv.setText(mGlobal.mSiteName + " | " + mGlobal.mShopName);
                            }
                        });

                    }
                    else
                    {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run()
                            {
                                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                builder.setMessage(resultMsg).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialog, int id) { }
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


    private void init_thepos_pos()
    {
        Thread thread = new Thread(new Runnable() {
            public void run()
            {
                try
                {

                    Request request = new Request.Builder().url(mGlobal.mUri + "pos?siteId=" + mGlobal.mSiteId + "&posNo=" + mGlobal.mPosNo).get().build();
                    Response response = okHttpClient.newCall(request).execute();

                    JSONObject json = new JSONObject(response.body().string());
                    String rc = json.getString("resultCode");
                    String resultMsg = json.getString("resultMsg");

                    if (rc.equals("200"))
                    {
                        mGlobal.mShopCode = json.getJSONArray("pos").getJSONObject(0).getString("shopCode");

                        init_thepos_shop();
                    }
                    else
                    {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run()
                            {
                                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                                builder.setMessage(resultMsg).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int id) { }
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


    private void init_thepos_shop()
    {
        try
        {
            Request request = new Request.Builder().url(mGlobal.mUri + "shop?siteId=" + mGlobal.mSiteId + "&shopCode=" + mGlobal.mShopCode).get().build();
            Response response = okHttpClient.newCall(request).execute();

            JSONObject json = new JSONObject(response.body().string());
            String rc = json.getString("resultCode");
            String resultMsg = json.getString("resultMsg");

            if (rc.equals("200"))
            {
                JSONArray arr = json.getJSONArray("shops");

                mGlobal.mShopName = "[미정]";
                for (int i = 0; i < arr.length(); i++)
                {
                    if (arr.getJSONObject(i).getString("shopCode").equals(mGlobal.mShopCode))
                    {
                        mGlobal.mShopName = arr.getJSONObject(i).getString("shopName");
                    }
                }

                runOnUiThread(new Runnable() {
                    @Override
                    public void run()
                    {
                        TextView tv = (TextView) findViewById(R.id.tvTitle);
                        tv.setText(mGlobal.mSiteName + " | " + mGlobal.mPosNo + " | " + mGlobal.mShopName);
                    }
                });
            }
            else
            {
                runOnUiThread(new Runnable() {
                    @Override
                    public void run()
                    {
                        AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                        builder.setMessage(resultMsg).setTitle("오류").setPositiveButton("확인", new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) { }
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




    private class ListViewAdapterShop extends BaseAdapter {

        Context mContext;
        LayoutInflater Inflater;
        int layout;

        private ArrayList<orderShop> mListOrderShop = new ArrayList<orderShop>();

        public ListViewAdapterShop(Context context, int alayout, ArrayList<orderShop> aarSrc) {
            mContext = context;
            Inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            mListOrderShop = aarSrc;
            layout = alayout;
        }

        @Override
        public int getCount() {
            return mListOrderShop.size();
        }

        @Override
        public long getItemId(int position) {
            return position;
        }

        @Override
        public Object getItem(int position) {
            return mListOrderShop.get(position);
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {

            if (convertView == null) {
                LayoutInflater inflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                convertView = Inflater.inflate(layout, parent, false);
            }

            orderShop myItemInfo = mListOrderShop.get(position);

            //
            if (myItemInfo.flow_step.equals("0"))  // 접수
            {
                ((ImageView) convertView.findViewById(R.id.flow_step)).setImageResource(R.drawable.ic_step_order);
                ((TextView) convertView.findViewById(R.id.allim_status_name)).setText("주문");

                ((TextView) convertView.findViewById(R.id.allim_status_name)).setTextColor(Color.BLUE);
                ((TextView) convertView.findViewById(R.id.order_no)).setTextColor(Color.BLUE);
                ((TextView) convertView.findViewById(R.id.order_time)).setTextColor(Color.BLUE);
                ((TextView) convertView.findViewById(R.id.order_cnt)).setTextColor(Color.BLUE);
                ((TextView) convertView.findViewById(R.id.order_memo)).setTextColor(Color.BLUE);
                ((TextView) convertView.findViewById(R.id.is_cancel)).setTextColor(Color.BLUE);

            }
            else if (myItemInfo.flow_step.equals("1")) // 전송
            {
                ((ImageView) convertView.findViewById(R.id.flow_step)).setImageResource(R.drawable.ic_step_allim);
                ((TextView) convertView.findViewById(R.id.allim_status_name)).setText("발송");

                ((TextView) convertView.findViewById(R.id.allim_status_name)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.order_no)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.order_time)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.order_cnt)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.order_memo)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.is_cancel)).setTextColor(Color.BLACK);

            }
            else if (myItemInfo.flow_step.equals("2")) // 완료
            {
                ((ImageView) convertView.findViewById(R.id.flow_step)).setImageResource(R.drawable.ic_step_finish);
                ((TextView) convertView.findViewById(R.id.allim_status_name)).setText("완료");

                ((TextView) convertView.findViewById(R.id.allim_status_name)).setTextColor(Color.GRAY);
                ((TextView) convertView.findViewById(R.id.order_no)).setTextColor(Color.GRAY);
                ((TextView) convertView.findViewById(R.id.order_time)).setTextColor(Color.GRAY);
                ((TextView) convertView.findViewById(R.id.order_cnt)).setTextColor(Color.GRAY);
                ((TextView) convertView.findViewById(R.id.order_memo)).setTextColor(Color.GRAY);
                ((TextView) convertView.findViewById(R.id.is_cancel)).setTextColor(Color.GRAY);

            }
            else
            {
                ((ImageView) convertView.findViewById(R.id.flow_step)).setImageResource(0);
                ((TextView) convertView.findViewById(R.id.allim_status_name)).setText(" ");

                ((TextView) convertView.findViewById(R.id.allim_status_name)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.order_no)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.order_time)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.order_cnt)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.order_memo)).setTextColor(Color.BLACK);
                ((TextView) convertView.findViewById(R.id.is_cancel)).setTextColor(Color.BLACK);

            }

            ((ImageView) convertView.findViewById(R.id.flow_step)).setTag(myItemInfo.flow_step);



            ((TextView) convertView.findViewById(R.id.order_time)).setText(myItemInfo.order_time);
            ((TextView) convertView.findViewById(R.id.order_no)).setText(myItemInfo.order_no);
            ((TextView) convertView.findViewById(R.id.order_cnt)).setText(myItemInfo.order_cnt);
            ((TextView) convertView.findViewById(R.id.order_memo)).setText(myItemInfo.order_memo);


            //
            if (myItemInfo.allim_type.equals("AT"))
            {
                ((ImageView) convertView.findViewById(R.id.allim_type)).setImageResource(R.drawable.ic_allim_talk);
            }
            else
            {
                ((ImageView) convertView.findViewById(R.id.allim_type)).setImageResource(0);
            }

            ((ImageView) convertView.findViewById(R.id.allim_type)).setTag(myItemInfo.allim_type);



            if (myItemInfo.is_cancel.equals("Y"))
            {
                ((ImageView) convertView.findViewById(R.id.flow_step)).setImageResource(R.drawable.ic_step_cancel);

                ((TextView) convertView.findViewById(R.id.is_cancel)).setText("취소");
                ((TextView) convertView.findViewById(R.id.is_cancel)).setTag("Y");

            }
            else {
                ((TextView) convertView.findViewById(R.id.is_cancel)).setText("");
                ((TextView) convertView.findViewById(R.id.is_cancel)).setTag("");
            }

            ((TextView) convertView.findViewById(R.id.the_no)).setText(myItemInfo.the_no);



            return convertView;
        }
    }

    class orderShop {
        String flow_step;
        String order_time;
        String order_no;
        String order_cnt;
        String order_memo;
        String allim_type;
        String is_cancel;
        String the_no;

        public orderShop(String flow_step, String order_no, String order_time, String order_cnt, String order_memo, String allim_type, String is_cancel, String the_no) {
            this.flow_step = flow_step;
            this.order_time = order_time;
            this.order_no = order_no;
            this.order_cnt = order_cnt;
            this.order_memo = order_memo;
            this.allim_type = allim_type;
            this.is_cancel = is_cancel;
            this.the_no = the_no;
        }
    }

    //
    private class ListViewAdapterItem extends BaseAdapter {

        Context mContext;
        LayoutInflater Inflater;
        int layout;

        private ArrayList<orderItem> mListOrderItem = new ArrayList<orderItem>();

        public ListViewAdapterItem(Context context, int alayout, ArrayList<orderItem> aarSrc) {
            mContext = context;
            Inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            mListOrderItem = aarSrc;
            layout = alayout;
        }

        @Override
        public int getCount() {
            return mListOrderItem.size();
        }

        @Override
        public long getItemId(int position) {
            return position;
        }

        @Override
        public Object getItem(int position) {
            return mListOrderItem.get(position);
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {

            if (convertView == null) {
                LayoutInflater inflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                convertView = Inflater.inflate(layout, parent, false);
            }

            orderItem myItemInfo = mListOrderItem.get(position);

            if (myItemInfo.item_type.equals("Goods"))
            {

                ((LinearLayout) convertView.findViewById(R.id.one_item)).setPadding(10, 20, 20, 10);
                ((ImageView) convertView.findViewById(R.id.item_type)).setImageResource(R.drawable.ic_goods);
                ((TextView) convertView.findViewById(R.id.item_name)).setText(myItemInfo.item_name);

                ((TextView) convertView.findViewById(R.id.item_name)).setTextSize(24);
                ((TextView) convertView.findViewById(R.id.item_value)).setTextSize(24);
            }
            else
            {
                ((LinearLayout) convertView.findViewById(R.id.one_item)).setPadding(10, 1, 20, 5);
                ((ImageView) convertView.findViewById(R.id.item_type)).setImageResource(0);
                ((TextView) convertView.findViewById(R.id.item_name)).setText("  - " + myItemInfo.item_name);

                ((TextView) convertView.findViewById(R.id.item_name)).setTextSize(18);
                ((TextView) convertView.findViewById(R.id.item_value)).setTextSize(18);
            }

            ((TextView) convertView.findViewById(R.id.item_value)).setText(myItemInfo.item_value);


            return convertView;
        }
    }

    class orderItem {
        String item_type;
        String item_name;
        String item_value;

        public orderItem(String item_type, String item_name, String item_value) {
            this.item_type = item_type;
            this.item_name = item_name;
            this.item_value = item_value;
        }
    }


}