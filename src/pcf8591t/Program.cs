/*
 *  Description:
 *     Raspberry pi 光敏電阻, 使用 .Net 6 開發 PCF8591t AD/DA 轉換器
 *     在 .Net IoT Library API 中找不到 PCF8591t 的driver, 但可使用 Pcx857x 來代替
 *     https://learn.microsoft.com/zh-tw/dotnet/api/iot.device.pcx857x.pcx857x?view=iot-dotnet-latest
 *     https://github.com/dotnet/iot/blob/main/src/devices/Pcx857x/Pcx857x.cs
 *     
*/
using System.Device.I2c;
using Iot.Device.Pcx857x;

// PCF8591t default address 0x48
var connectionSettings = new I2cConnectionSettings(1, 0x48);
var i2cDevice = I2cDevice.Create(connectionSettings);
var pcf8591t = new Pcf8574(i2cDevice);  // 使用Pcf8574 driver

while(true){
  double value = pcf8591t.ReadByte();
  Console.WriteLine($"{value}%");
  Thread.Sleep(200);
}