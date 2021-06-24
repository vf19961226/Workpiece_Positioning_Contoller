# Workpiece_Positioning_Contoller
## 簡介
本專案為澄德基金會「[**2021 大專校院機電暨智慧創意實作競賽**](https://www.chengde.org.tw/page.php?menu_id=16&p_id=77)」以及109學年第2學期國立成功大學機械系「[**物聯網與大數據於智慧製造應用**](http://class-qry.acad.ncku.edu.tw/syllabus/online_display.php?syear=0108&sem=2&co_no=E134300&class_code=)」課程之期末專題的控制程式，其主程式為[**Workpiece_Positioning**](https://github.com/vf19961226/Workpiece_Positioning)。

## 程式概述
本專案之程式使用C#撰寫，並搭配MQTT接收定位資訊與發佈控制指令。

## 實作環境
本程式使用Visual Studio 2019 Professional於Windows 10中進行開發，其.NET framework為4.5、M2mqtt為4.3版。

## 如何操作
1. 將Broker的IP位置與Port輸入相應欄位，並按下Connect進行連線    
2. 選擇欲監控的設備
3. 可於介面中監控Webcam的即時影像
4. 按下Identify發送指令予Nano開始定位
5. 確認Nano回傳之定位資訊
6. 按下Start發送指令予雷雕機控制電腦開始加工
![How use](https://github.com/vf19961226/Workpiece_Positioning_Contoller/blob/main/figure/Workpiece_Positioning_Contoller.png)
