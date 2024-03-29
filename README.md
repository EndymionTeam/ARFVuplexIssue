# Issue
On Android device, while ARFoundation is active, when creating a Canvas Webview using `CanvasWebViewPrefab.Instantiate` api causes the app to crash with the following error:

```
#00 pc 0000000000095190  /apex/com.android.runtime/lib64/bionic/libc.so (abort+168) (BuildId: 1e3ca19bcae05c01b019c85f3f422e56)
#01 pc 0000000000fdb5a8  /vendor/lib64/libllvm-qgl.so (BuildId: 919a8f75abc47cad3f5efd546c1a6b21)
#02 pc 00000000000fee50  /apex/com.android.runtime/lib64/bionic/libc.so (pthread_once+136) (BuildId: 1e3ca19bcae05c01b019c85f3f422e56)
#03 pc 0000000000fdb404  /vendor/lib64/libllvm-qgl.so (__emutls_get_address+152) (BuildId: 919a8f75abc47cad3f5efd546c1a6b21)
#04 pc 0000000000a1ba84  /vendor/lib64/libllvm-qgl.so (BuildId: 919a8f75abc47cad3f5efd546c1a6b21)
#05 pc 0000000000fd4bbc  /vendor/lib64/libllvm-qgl.so (BuildId: 919a8f75abc47cad3f5efd546c1a6b21)
#06 pc 0000000000ec5718  /vendor/lib64/libllvm-qgl.so (BuildId: 919a8f75abc47cad3f5efd546c1a6b21)
#07 pc 000000000029956c  /vendor/lib64/egl/libGLESv2_adreno.so (BuildId: 44ffe54a265d4bec0c74e44304ea6c42)
#08 pc 00000000002990ec  /vendor/lib64/egl/libGLESv2_adreno.so (BuildId: 44ffe54a265d4bec0c74e44304ea6c42)
#09 pc 00000000044e1638  /data/app/~~EkAgpktBGwmdzNBc7nRpSw==/com.google.android.trichromelibrary_626112033-vMMoAF-ysGQxOg-fZ65SGA==/base.apk (BuildId: decd21b292482c13bf0c3bf9997c41544b8d11a6)
```

> Full stacktrace of the error is available [here](./stacktrace.md). This include all logging since the App has been launched.

NOTE: this behaviour seems specific for some device (listed below), but seems working properly for other devices.

# Environment

## Development 
- Unity: 2022.3.17f1 (for Windows)
- Vuplex: 4.7.1  (Standalone + Android)
- ARFoundation: 5.1.3
- Google ARCore XR Plugin: 5.1.3

## Device Specs
- Model: Xiaomi 14
- Android: 14
- Android System Webview: 122.0.6261.120

# Example
Reference scene is [Assets/Scenes/SampleScene](./Assets/Scenes/SampleScene.unity). In thee scene are added `XOrigin` and `ARSession`, just to activate ARFoundation and the related camera background behaviour. No other specific ARFoundation features were used.

In the middle of the scene, there is a `Button` that when touched execute simple Canvas Webview creation implemented in [CrashTest.cs](Assets/Scenes/CrashTest.cs) script.

# Steps 
Steps to reproduce the issue:
1. Add Vuplex library to Unity project
2. Build for Android device
3. Launch the app `ARTest`
4. Click on `Button` to spawn the canvas webview
5. The application should crash

> NOTE: Crash can be random. Sometimes the application work properly.