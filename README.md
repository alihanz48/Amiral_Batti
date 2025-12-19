# ⚓ Amiral Battı (Battleship) - C# Windows Forms

Bu proje, C# ve Windows Forms teknolojileri kullanılarak geliştirilmiş, klasik **Amiral Battı** strateji oyununun masaüstü versiyonudur.

## 🎮 Proje Hakkında

Amiral Battı, rakip donanmaya ait gemilerin koordinatlarını tahmin ederek onları batırmaya dayalı bir strateji oyunudur. Bu projede kullanıcı, görsel bir arayüz (Grid yapısı) üzerinden tahminlerini yapar ve bilgisayara karşı mücadele eder.

### ✨ Özellikler

* **İnteraktif Arayüz:** Butonlar/Kutucuklar (Grid) üzerinden kolay oynanış.
* **Görsel Geri Bildirim:**
    * 🎯 **İsabet (Hit):** Doğru tahminlerde kutucuk rengi değişir.
    * 🌊 **Iskalama (Miss):** Yanlış tahminlerde kutucuk rengi değişir.
* **Oyun Mantığı:** Gemilerin rastgele veya manuel yerleştirilmesi ve batırılma durumlarının kontrolü.
* **Puan/Durum Takibi:** Kalan gemi sayısı veya hamle sayısının gösterimi.

## 🛠️ Teknolojiler

Projede kullanılan teknoloji yığını:

* **Programlama Dili:** C#
* **Arayüz:** Windows Forms Application (WinForms)
* **Framework:** .NET Framework
* **IDE:** Visual Studio

## 🕹️ Nasıl Oynanır?

1.  Uygulamayı başlattığınızda karşınıza bir oyun alanı (harita) gelir.
2.  Rakip gemilerin gizlendiği kareleri bulmak için kutucuklara tıklayın.
3.  Eğer bir gemiyi vurursanız, kutucuk **Kırmızı** (veya belirlediğin vurulma rengi) olur.
4.  Eğer boş suya atış yaparsanız, kutucuk **Mavi** (veya boş renk) olur.
5.  Amaç, en az hamle ile rakibin tüm gemilerini batırmaktır.

## ⚙️ Kurulum ve Çalıştırma

Projeyi bilgisayarınızda çalıştırmak için:

1.  **Projeyi İndirin:**
    ```bash
    git clone [https://github.com/alihanz48/Amiral_Batti.git](https://github.com/alihanz48/Amiral_Batti.git)
    ```
2.  **Projeyi Açın:**
    İndirdiğiniz klasördeki `.sln` uzantılı dosyayı Visual Studio ile açın.
3.  **Çalıştırın:**
    Visual Studio üst menüsündeki **Start** butonuna basın (veya `F5` tuşuna basın).

## 📂 Dosya Yapısı

* **Form1.cs:** Oyunun ana mantığının döndüğü, arayüz kontrollerinin ve olayların (click events) yönetildiği temel dosya.

## 📸 Ekran Görüntüleri

![](Images/1.png)