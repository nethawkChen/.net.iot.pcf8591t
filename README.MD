# PCF8591t AD/DA 轉換器

.Net IoT Library API 中找不到 PCF8591t 的driver,但可使用 Pcx857x 來代替
PCF8591t 本身已有光敏電阻, 這個實驗在額外加一個光敏電阻, 兩者都可以感應

```
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
```
![Pcf8591t](https://github.com/nethawkChen/.net.iot.pcf8591t/blob/main/img/pcf8591t.jpg)

![接線圖](https://github.com/nethawkChen/.net.iot.pcf8591t/blob/main/img/pcf8591t_bb.jpg)