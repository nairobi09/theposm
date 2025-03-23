package kr.co.theposm;

import android.app.Activity;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.media.Ringtone;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Build;
import android.util.Log;
import android.widget.Toast;

import androidx.core.app.NotificationCompat;
import com.google.firebase.messaging.FirebaseMessagingService;
import com.google.firebase.messaging.RemoteMessage;


public class MyFirebaseMessagingService extends FirebaseMessagingService {

    @Override
    public void onNewToken(String token) {
        super.onNewToken(token);

        Toast myToast = Toast.makeText(this.getApplicationContext(),"onNewToken()", Toast.LENGTH_SHORT);
        myToast.show();

        //sendTokenToServer(token);
    }

    @Override
    public void onMessageReceived(RemoteMessage remoteMessage) {
        super.onMessageReceived(remoteMessage);


        try {
            //알람 사운드
            Uri notification = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
            Ringtone r = RingtoneManager.getRingtone(getApplicationContext(), notification);
            r.play();


            // MainActivity 리스트뷰 갱신
            String body = remoteMessage.getNotification().getBody();
            Intent myIntent = new Intent("INTENT_ORDER_SHOP");
            myIntent.putExtra("action",body);
            sendBroadcast(myIntent);

        } catch (Exception e) {
            e.printStackTrace();
        }


        //String title = remoteMessage.getNotification().getTitle();
        //String message = remoteMessage.getNotification().getBody();

        //showNotification(title, message);
    }

    private void sendTokenToServer(String token) {

    }



}